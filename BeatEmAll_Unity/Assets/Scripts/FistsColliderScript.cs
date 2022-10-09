using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistsColliderScript : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Animator animator;
    [SerializeField] Animator fistsAnimator;
    [SerializeField] Transform player;
    [SerializeField] CameraFeedback cameraFb;

    public bool simpleCombo;

    private void Update()
    {
        transform.position = player.position;
        fistsAnimator.SetBool("isAttacking", animator.GetBool("isAttacking"));
        if (!animator.GetBool("simpleCombo")) simpleCombo = false;
        if (animator.GetBool("simpleCombo") && !playerController.isJumping && !simpleCombo)
        {
            
            fistsAnimator.SetTrigger("ComboAttackCollider");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))// && !collision.gameObject.GetComponent<HealthEnemies>().isAttacking)
        {
            collision.gameObject.GetComponent<EnemyHealth>().Hit(playerController.simpleCombo, playerController.superAttack);
            cameraFb.ShakeCamera();
        }
    }
}
