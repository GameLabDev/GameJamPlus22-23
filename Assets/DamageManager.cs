using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DamageManager : MonoBehaviour
{
    public Transform positionAtack1, positionAtack2, positionAtack3;
    public float radiusAtack1, punch1Force;
    public LayerMask Enemy;
    public GameObject sphere;
    public void Atack1()
    {
       Collider[] col = Physics.OverlapSphere(positionAtack1.position, radiusAtack1, Enemy);
       if(col.Length > 0)
       {
            Debug.Log("oi");
            col[0].GetComponent<EnemyScript>().health--;
       }
    }
    public void Atack2()
    {
        Debug.Log("ola");
        Instantiate(sphere, positionAtack1.position, positionAtack1.rotation);
    }
    public void Atack3()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(positionAtack1.position, radiusAtack1);
    }
}
