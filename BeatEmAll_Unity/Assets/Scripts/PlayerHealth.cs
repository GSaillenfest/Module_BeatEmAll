using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] Animator animator;
    

    public bool isAttacking;
    public float health =100;
    bool isHurt = false;

    private void Awake()

    {
      
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = animator.GetBool("isAttacking");
        isHurt = animator.GetBool("isHurt");
    }


    public void Hit()
    {

        if (health > 0 && !isAttacking)
        {
            health -= 7.5f;
            animator.SetTrigger("Hurt");
        }

        else if (health <= 0)
        {
            health = 0;
            animator.SetTrigger("Hurt");
            animator.SetBool("Dead", true);

        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isAttacking)
        {
            if (!isHurt) Hit();
            GetComponentInChildren<PlayerPickUp>().DropProjectile();
        }
    }

}