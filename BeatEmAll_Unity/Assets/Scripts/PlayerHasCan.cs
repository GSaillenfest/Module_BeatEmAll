using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasCan : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        WithCan();
    }
    public void WithCan()
    {

        if (animator.GetBool("isWalking") == true && animator.GetBool("HasCan") == true)
        {
            animator.SetBool("WalkWCan", true);
        }

        if (animator.GetBool("isJumping") == true && animator.GetBool("HasCan") == true)
        {
            animator.SetTrigger("JumpWCan");
        }

        if (animator.GetBool("HasCan") == true && animator.GetBool("isWalking") == false && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("WalkWCan", true);
        }

        if (animator.GetBool("HasCan") == true && Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("LaunchCan");
            animator.SetBool("HasCan", false);
            CanLaunch();
        }
        





        }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("can") && Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("HasCan", true);
            animator.SetTrigger("PickUpCan");
            CanLift();
        }
        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("HasCan") == true && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("HasCan", false);
            animator.SetBool("LoseCan", true);
            animator.SetTrigger("IsHurt");
        }
        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("HasCan") == true && animator.GetBool("isJumping") == true)
        {
            animator.SetBool("HasCan", false);
            animator.SetBool("LoseCan", true);
            animator.SetTrigger("JumpHurt");
        }


    }
    public void CanLaunch()
    {

    }//to do
    public void CanLift()
    {
    }//to do
 }
