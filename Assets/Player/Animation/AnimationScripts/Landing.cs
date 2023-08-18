using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float y_Axis = animator.GetFloat("y_Axis");
       if (y_Axis == 0f){
        animator.SetBool("IsGround", true);
       }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
