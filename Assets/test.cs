using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public LayerMask lm;
    public float radius;
    private void FixedUpdate()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position + Vector3.up*0.5f,radius,transform.forward,out hitInfo,10f,lm))
        {
            Debug.DrawLine(transform.position, hitInfo.point);
        }

    }
}
