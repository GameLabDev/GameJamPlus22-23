using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator anim;
    private InputManager inputManager;
    private LocomotionManager locomotionManager;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        inputManager = GetComponent<InputManager>();
        locomotionManager = GetComponent<LocomotionManager>();
    }

    private void FixedUpdate()
    {
        float movementQt = Mathf.Abs(inputManager.MovementInput.x);
        movementQt += Mathf.Abs(inputManager.MovementInput.y);
        anim.SetFloat("MovementQuantity", Mathf.Clamp01(movementQt));
    }
    private void LateUpdate()
    {
        locomotionManager.IsJumping = anim.GetBool("IsJumping");
        locomotionManager.IsInteracting = anim.GetBool("Interaction");
        anim.SetBool("IsGrounded", locomotionManager.IsGrounded);
    }
    public void OnJump()
    {
        anim.CrossFade("Jump", 0.2f);
    }
    public void OnFall()
    {
        anim.CrossFade("Fall", 0.2f);
    }
    public void OnAtack1()
    {
        anim.SetTrigger("Atack1");
    }
    public void OnAtack2()
    {
        anim.SetTrigger("Atack2");
    }
    public void OnAtack3()
    {
        anim.SetBool("Dash", true);
    }

}
