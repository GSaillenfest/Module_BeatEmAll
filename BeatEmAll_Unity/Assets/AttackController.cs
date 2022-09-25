using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] PlayerHasCan playerHasCan;
    [SerializeField] PlayerController playerController;
    [SerializeField] Animator animator;



    public void Launch()
    {
        playerHasCan.CanLaunch();
    }

    public void IsStreakTrue()
    {
        if (playerController.streakCount == 0)
        {
            animator.SetBool("isAttacking", false);
        }

        playerController.streakCount = 0;

    }

    public void EndStreak()
    {
        animator.SetBool("isAttacking", false);
        playerController.streakCount = 0;

    }

    public void SetCanPickedTrue()
    {
        playerHasCan.canPicked = true;
    }
}
