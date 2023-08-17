using UnityEngine;

public class Run : StateMachineBehaviour {
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        bool isSlide = animator.GetComponentInParent<Movement>().slide;
        if (isSlide) {
            animator.SetBool("IsSlide",true);
        }
    }
}