using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public LocomotionManager player;

    public LayerMask lmGround, lmPlayer;

    public int health = 5;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public bool atacking;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public GameObject EnemyFloatingText;
    public float offsetFloatText;
    private void Awake()
    {
        //player = FindObjectsOfType<LocomotionManager>()[Random.Range(0,2)];
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        LookAtNoYAxis(player.gameObject);
        if (!atacking) return;
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, lmPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, lmPlayer);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, lmGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);


        if (!alreadyAttacked)
        {
            Vector3 oldpos = transform.position;
            Collider[] col = Physics.OverlapSphere(transform.position + transform.forward*1.3f, 0.3f, lmPlayer);
            if (col.Length > 0)

                
                transform.DOMove(col[0].GetComponent<PlayerManager>().transform.position, 0.2f).OnComplete(() => {
                    col[0].GetComponent<PlayerManager>().TakeDamage(1);
                    transform.DOMove(oldpos, 0.2f);
                    FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().gameObject.transform.DOShakePosition(0.2f);
                });
                
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 1);
        }
    }
    public void LookAtNoYAxis(GameObject target)
    {
        Vector3 motion = target.transform.position;
        motion.y = transform.position.y;
        transform.DOLookAt(motion, .1f);
    }
    private void ResetAttack()
    {
        atacking = false;
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0) {

            Invoke(nameof(DestroyEnemy), 0f);
            GameObject gmo = Instantiate(EnemyFloatingText, transform.position + transform.forward * offsetFloatText, Quaternion.Euler(Vector3.down * 90f)) as GameObject;
            gmo.GetComponent<TextMesh>().text = "0";
            Destroy(gmo, 0.3f);
        }
        else
        {
            GameObject gmo = Instantiate(EnemyFloatingText, transform.position + transform.forward * offsetFloatText, Quaternion.Euler(Vector3.down * 90f)) as GameObject;
            gmo.GetComponent<TextMesh>().text = (health * 10).ToString();
            Destroy(gmo, 0.3f);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
