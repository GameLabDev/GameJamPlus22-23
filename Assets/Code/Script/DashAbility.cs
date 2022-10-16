using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DashAbility : Ability
{
    private CharacterController chrController;
    [SerializeField] private float _duration;
    [SerializeField] private float distance;
    [SerializeField] private float TimeAbility;
    Vector3 positionStart;
    LocomotionManager locomotionManager;
    [SerializeField] private float timer;
    [SerializeField] private float dodgeTimer;
    [SerializeField] public float speed = 10;

    private void Awake()
    {
        slider = GameObject.Find(namee).GetComponent<Slider>();
        this.enabled = false;
    }
    private void Start()
    {
        locomotionManager = GetComponent<LocomotionManager>();
        chrController = GetComponent<CharacterController>();
    }
    public IEnumerator Dash()
    {
        timer = 0f;
        while (timer < dodgeTimer)
        {
        Debug.Log("ola");
            timer += Time.fixedDeltaTime;
            Vector3 direction = (transform.forward * speed);
            chrController.Move(direction * Time.fixedDeltaTime);
            yield return null;
        }
        DOVirtual.DelayedCall(TimeAbility, () =>
        {
            locomotionManager.enabled = true;
        });
        locomotionManager.enabled = true;
        GetComponentInChildren<Animator>().SetBool("Dash", false);

    }
    public void OnCombat()
    {
        positionStart = transform.position;
        if (!locomotionManager.enabled) return;
        if (!isReady) return;
        time = 0f;
        tw.Kill();
        OnStartAction.Invoke();
        locomotionManager.enabled = false;
        StartCoroutine(Dash());


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
    private Vector3 TargetOffset(Vector3 target)
    {
        Vector3 position;
        position = target;
        position.y = transform.position.y;
        return Vector3.MoveTowards(position, transform.position, .5f);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }
}
