using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSet : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Interaction", true);
    }
}
