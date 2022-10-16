using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PuchDash : Ability
{
    private EnemyTargetManager _targetManager;
    [SerializeField] private float _duration;
    [SerializeField] private float distance;
    LocomotionManager locomotionManager;
    [SerializeField] private float TimeAbility;
    private void Awake()
    {
        
    }
    private void Start()
    {
        _targetManager = GetComponentInChildren<EnemyTargetManager>();
        locomotionManager = GetComponent<LocomotionManager>();
    }
    public void OnCombat()
    {
        if (!locomotionManager.enabled) return;

        tw.Kill();
        OnStartAction.Invoke();
        locomotionManager.enabled = false;

            tw = transform.DOMove(TargetOffset(transform.forward * distance + transform.position), _duration).OnComplete(() => {
                DOVirtual.DelayedCall(TimeAbility, () =>
                {
                    locomotionManager.enabled = true;
                });
            });
     }
    private void FixedUpdate()
    {

    }
    public void SetTimeUsing()
    {
        timeUsing = 30f;
        this.enabled = true;
    }
    public void ResetTimeUsing()
    {
        timeUsing = 0f;
        this.enabled = false;
    }
    private void LookAtNoYAxis(GameObject target)
    {
        Vector3 motion = target.transform.position;
        motion.y = transform.position.y;
        transform.DOLookAt(motion, .2f);
    }
    private Vector3 TargetOffset(GameObject target)
    {
        Vector3 position;
        position = target.transform.position;
        position.y = transform.position.y;
        return Vector3.MoveTowards(position, transform.position, .5f);
    }
    private Vector3 TargetOffset(Vector3 target)
    {
        Vector3 position;
        position = target;
        position.y = transform.position.y;
        return Vector3.MoveTowards(position, transform.position, .5f);
    }
}
