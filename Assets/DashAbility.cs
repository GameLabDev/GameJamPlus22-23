using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DashAbility : Ability
{
    [SerializeField] private float _duration;
    [SerializeField] private float distance;
    [SerializeField] private float TimeAbility;
    LocomotionManager locomotionManager;
    private void Start()
    {
        locomotionManager = GetComponent<LocomotionManager>();
    }
    public void OnCombat()
    {
        if (!locomotionManager.enabled) return;
        tw.Kill();
        OnStartAction.Invoke();
        locomotionManager.enabled = false;
        tw = transform.DOMove(TargetOffset(transform.forward * distance + transform.position), TimeAbility).OnComplete(() => {
            locomotionManager.enabled = true;
            GetComponentInChildren<Animator>().SetBool("Dash", false);
        });

    }
    private Vector3 TargetOffset(Vector3 target)
    {
        Vector3 position;
        position = target;
        position.y = transform.position.y;
        return Vector3.MoveTowards(position, transform.position, .5f);
    }
}
