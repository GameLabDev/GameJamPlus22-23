using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReset : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsJumping", false);
    }

}