using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class TargetManager : MonoBehaviour
{
    public GameObject target;
    private Color colorGizmos;

    [SerializeField] public LayerMask _lmTarget;
    [SerializeField] public float radius;
    public List<GameObject> enemyes;

    private void FixedUpdate()
    {

        if (enemyes.Count > 0)
        {
            target = (from t in enemyes.ToArray<GameObject>()
                      orderby ((t.transform.position - transform.position).sqrMagnitude)
                      select t).ToList()[0].gameObject;
        }
        else
        {
            colorGizmos = Color.red;
            target = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = colorGizmos;
        Gizmos.DrawSphere(transform.position, radius);
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
            enemyes.Remove(other.gameObject);
        }
    }
}
