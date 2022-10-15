using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DashPunch : MonoBehaviour
{
    public GameObject target;
    private Color colorGizmos;

    [SerializeField] public LayerMask _lmTarget;
    [SerializeField] public float radius;
    public List<GameObject> enemyes;

    //[SerializeField] public FollowTarget followTarget;
    private void FixedUpdate()
    {

    }
}
