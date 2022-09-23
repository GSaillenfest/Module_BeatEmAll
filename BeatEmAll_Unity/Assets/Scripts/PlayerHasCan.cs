using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasCan : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;

    GameObject can;

    bool canPicked = false;
    bool hasCan = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        WithCan();
        Debug.Log(canPicked);
        hasCan = animator.GetBool("HasCan");
    }
    public void WithCan()
    {

        if (animator.GetBool("isWalking") == true && canPicked)
        {
            animator.SetBool("WalkWCan", true);
        }
        else animator.SetBool("WalkWCan", false);

        if (animator.GetBool("isJumping") == true && canPicked)
        {
            animator.SetTrigger("JumpWCan");
        }

        if (animator.GetBool("isWalking") == false && animator.GetBool("isJumping") == false && canPicked)
        {
            animator.SetBool("IdleWCan", true);
        }
        else animator.SetBool("IdleWCan", false);

        if (Input.GetButtonDown("Fire1") && canPicked)
        {
            animator.SetTrigger("LaunchCan");
            CanLaunch();
        }

        if (hasCan && Input.GetButtonDown("Fire1") && !canPicked)
        {
            animator.SetTrigger("PickUpCan");
            canPicked = true;
            can.transform.SetParent(gameObject.transform.GetChild(0));
            can.GetComponent<Collider2D>().enabled = false;
            can.transform.localPosition = Vector2.zero;
        }


    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (!canPicked)
        {

            if (collision.gameObject.CompareTag("can"))
            {
                animator.SetBool("HasCan", true);
                can = collision.gameObject;
            }

        }

        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("HasCan") == true && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("HasCan", false);
            animator.SetBool("LoseCan", true);
            animator.SetTrigger("IsHurt");
        }
        else animator.SetBool("LoseCan", false);


        if (collision.gameObject.CompareTag("Enemy") && animator.GetBool("HasCan") == true && animator.GetBool("isJumping") == true)
        {
            animator.SetBool("HasCan", false);
            animator.SetBool("LoseCan", true);
            animator.SetTrigger("JumpHurt");
        }
        else animator.SetBool("LoseCan", false);


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("can"))
        {
            //animator.SetBool("HasCan", false);
        }
    }
    public void CanLaunch()
    {
        canPicked = false;
        animator.SetBool("HasCan", false);

    }//to do
    public void CanLift()
    {


    }//to do
}
