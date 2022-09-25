using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasCan : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;
    [SerializeField] Transform launchedObjects;
    [SerializeField] PlayerController playerController;
    

    Animator canAnimator;
    GameObject can;

    public bool canPicked = false;
    public bool hasCan = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        WithCan();
        Debug.Log(canPicked);

    }
    public void WithCan()
    {


        if (Input.GetButtonDown("Fire1") && canPicked && !animator.GetBool("isJumping"))
        {
            animator.SetTrigger("LaunchCan");
        }

        if (hasCan && Input.GetButtonDown("Fire1") && !canPicked && !animator.GetBool("isJumping") && !animator.GetBool("isAttacking"))
        {
            PickUpCan();
        }


    }

    private void PickUpCan()
    {
        animator.SetTrigger("PickUpCan");
        if (playerController.isFlipped) can.transform.localScale = new Vector3(-1,1,1);
        can.transform.SetParent(gameObject.transform.GetChild(0));
        can.GetComponent<Collider2D>().enabled = false;
        can.transform.localPosition = Vector2.zero;
        canAnimator = can.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!canPicked)
        {

            if (collision.gameObject.CompareTag("can") && !animator.GetBool("isJumping"))
            {
                hasCan = true;
                can = collision.gameObject;
            }

        }

        if (collision.gameObject.CompareTag("Enemy") && canPicked)
        {
            canPicked = false;
            canAnimator.SetTrigger("Drop");
            animator.SetTrigger("IsHurt");
        }


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(can))
        {
            hasCan = false;
        }
    }
    public void CanLaunch()
    {
        canPicked = false;
        can.transform.SetParent(launchedObjects, true);
        animator.SetBool("HasCan", false);
        canAnimator.SetTrigger("Launch");

    }//to do
    public void CanLift()
    {


    }//to do
}
