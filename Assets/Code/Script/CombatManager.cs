using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CombatManager : Ability
{
    private EnemyTargetManager _targetManager;
    [SerializeField] private float _duration;
    [SerializeField] private float distance;
    LocomotionManager locomotionManager;
    private void Start()
    {
        _targetManager = GetComponent<EnemyTargetManager>();
        locomotionManager = GetComponent<LocomotionManager>();
    }
    public void OnCombat()
    {
        if (!locomotionManager.enabled) return;
        tw.Kill();
        locomotionManager.enabled = false;
        if (_targetManager.target == null) {
            tw = transform.DOMove(TargetOffset(transform.forward * distance + transform.position), _duration).OnComplete(() => {
                locomotionManager.enabled = true;
            });
        }
        else
        {
            LookAtNoYAxis(_targetManager.target);
            tw = transform.DOMove(TargetOffset(_targetManager.target), _duration).OnComplete(()=> {
                locomotionManager.enabled = true;
            });
        }
        
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
