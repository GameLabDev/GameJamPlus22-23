using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyTargetManager target;
    public EnemyTargetManager target2;
    public GameObject player;
    public Rigidbody controller;
    private Coroutine MovementCoroutine;
    [Header("Stats")]
    public int health = 3;
    public Material[] mat;
    [SerializeField]private float moveSpeed = 1;
    private Vector3 moveDirection;

    [Header("States")]
    [SerializeField] private bool isPreparingAttack;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isRetreating;
    [SerializeField] private bool isLockedTarget;
    [SerializeField] private bool isStunned;
    [SerializeField] private bool isWaiting = true;

    private void Start()
    {
        MovementCoroutine = StartCoroutine(EnemyMovement());
    }
    IEnumerator EnemyMovement()
    {
        //Waits until the enemy is not assigned to no action like attacking or retreating
        yield return new WaitUntil(() => isWaiting == true);

        int randomChance = Random.Range(0, 2);

        if (randomChance == 1)
        {
            int randomDir = Random.Range(0, 2);
            moveDirection = randomDir == 1 ? Vector3.right : Vector3.left;
            isMoving = true;
        }
        else
        {
            StopMoving();
        }

        yield return new WaitForSeconds(1);

        MovementCoroutine = StartCoroutine(EnemyMovement());
    }
    public void StopMoving()
    {
        isMoving = false;
        moveDirection = Vector3.zero;
    }

    void Update()
    {
        
        if (health <= 0)
        {
            
            gameObject.SetActive(false);
        }
        else
        {
            GetComponent<MeshRenderer>().material = mat[health - 1];
        }

        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        MoveEnemy(moveDirection);
    }
    void MoveEnemy(Vector3 direction)
    {
        controller.velocity = (moveDirection * moveSpeed * Time.deltaTime);
    }
}
