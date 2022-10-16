using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyTargetManager : MonoBehaviour
{
    public LayerMask lm;
    public float radius;
    public GameObject target;
    Vector3 pos;
    public float distance;
    
    //private Color colorGizmos;

    //public LayerMask _lmTarget;
    public List<GameObject> enemyes;
    public Material matTarget, matNoTarget;
    /* private void FixedUpdate()
     {
         return;
         if (enemyes.Count > 0)
         {
             GameObject oldtarget = target;
             target = (from t in enemyes.ToArray<GameObject>()
                       orderby ((t.transform.position - transform.position).sqrMagnitude)
                       where t.gameObject.activeInHierarchy
                       select t).ToList()[0].gameObject;
             if(oldtarget != null && oldtarget != target)
             {
                 oldtarget.GetComponent<MeshRenderer>().material = matNoTarget;
             }
             target.GetComponent<MeshRenderer>().material = matTarget;
         }
         else
         {
             colorGizmos = Color.red;
             target = null;
         }
     }
     private void OnDrawGizmos()
     {
         Gizmos.DrawWireSphere(transform.position, radius);
     }
     private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.CompareTag("Target"))
         {
             enemyes.Add(other.gameObject);
         }
     }
     private void OnTriggerExit(Collider other)
     {
         if (other.gameObject.CompareTag("Target"))
         {
             other.gameObject.GetComponent<MeshRenderer>().material = matNoTarget;
             enemyes.Remove(other.gameObject);
         }
     }*/
    private void Update()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position + Vector3.up * 0.5f, radius, transform.forward* distance, out hitInfo, 10f, lm))
        {
            pos = hitInfo.collider.gameObject.transform.position;
            target = hitInfo.collider.gameObject;
            
        }
        else
        {
            pos = Vector3.zero;
            target = null;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pos, 0.5f);
    }

}
