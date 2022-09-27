using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpAttackBehaviour : StateMachineBehaviour
{
    float yPosBeforeJump;
    Rigidbody2D rb2D;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //rb2D = animator.gameObject.GetComponentInChildren<Rigidbody2D>();

        //yPosBeforeJump = animator.gameObject.GetComponentInChildren<EnemyShadow>().yPosBeforeJump;
        //rb2D.gravityScale = 0.7f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (rb2D.transform.localPosition.y < yPosBeforeJump)
        //{
        //    rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
        //    rb2D.gravityScale = 0f;
        //    rb2D.transform.localPosition = new Vector2(rb2D.transform.localPosition.x, yPosBeforeJump);

        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
