using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack1Reset : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Index", 0);
        animator.ResetTrigger("Atack1");
    }
}
