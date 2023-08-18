using UnityEngine;

public class Slide : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        bool isSlide = animator.GetComponentInParent<Movement>().slide;
        if (!isSlide) {
            animator.SetBool("IsSlide",false);
        }
    }
}
