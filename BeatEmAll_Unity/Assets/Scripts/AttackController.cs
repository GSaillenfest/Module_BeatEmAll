using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] PlayerPickUp playerPickUp;
    [SerializeField] PlayerController playerController;
    [SerializeField] Animator animator;



    public void Launch()
    {
        playerPickUp.ProjectileLaunch();
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
        playerPickUp.objectPickedUp = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))// && !collision.gameObject.GetComponent<HealthEnemies>().isAttacking)
        {
            collision.gameObject.GetComponent<EnemyHealth>().Hit(playerController.simpleCombo, playerController.superAttack);
        }
    }

}
