using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FireBall : Ability
{
    private EnemyTargetManager _targetManager;
    [SerializeField] private float _duration;
    [SerializeField] private float distance;
    [SerializeField] private float TimeAbility;
    LocomotionManager locomotionManager;
    private void Awake()
    {
        slider = GameObject.Find(namee).GetComponent<Slider>();

        this.enabled = false;
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
        if (!isReady) return;
        time = 0f;
        locomotionManager.enabled = false;
        if (_targetManager.target == null)
        {
            OnStartAction.Invoke();
            tw = transform.DOMove(TargetOffset(transform.forward * distance + transform.position), _duration).OnComplete(() => {
               DOVirtual.DelayedCall(TimeAbility, () =>
                {
                    locomotionManager.enabled = true;
                });
            });
            
        }
        else
        {
            OnStartAction.Invoke();
            tw = LookAtNoYAxis(_targetManager.target).OnComplete(()=> {
                DOVirtual.DelayedCall(TimeAbility, () =>
                {
                    locomotionManager.enabled = true;
                });
            });
        }

    }

    private void FixedUpdate()
    {
        ReadyAbility();
        if (timeUsing <= 0)
        {
            this.enabled = false;
        }
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
    private Tween LookAtNoYAxis(GameObject target)
    {
        Vector3 motion = target.transform.position;
        motion.y = transform.position.y;
        return transform.DOLookAt(motion, .2f);
    }
    private Vector3 TargetOffset(Vector3 target)
    {
        Vector3 position;
        position = target;
        position.y = transform.position.y;
        return Vector3.MoveTowards(position, transform.position, .5f);
    }
}
