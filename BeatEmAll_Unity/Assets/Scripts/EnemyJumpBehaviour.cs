using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpBehaviour : StateMachineBehaviour
{
    float yPosBeforeJump;
    Rigidbody2D rb2D;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isJumping", true);
        rb2D = animator.gameObject.GetComponentInChildren<Rigidbody2D>();

        yPosBeforeJump = rb2D.transform.localPosition.y;
        rb2D.AddForce(new Vector2(0, 650));
        rb2D.gravityScale = 1.5f;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rb2D.transform.localPosition.y < yPosBeforeJump - 0.1f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.gravityScale = 0f;
            rb2D.transform.localPosition = new Vector2(rb2D.transform.localPosition.x, yPosBeforeJump);
            animator.SetBool("isJumping", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
