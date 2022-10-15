using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class Ability : MonoBehaviour
{
    public UnityEvent OnStartAction;
    public Tween tw;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "Target")
        {
            tw.Kill();
        }
    }
}
