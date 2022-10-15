using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack1Set : StateMachineBehaviour
{
    public int value;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Index", value);
    }
}
