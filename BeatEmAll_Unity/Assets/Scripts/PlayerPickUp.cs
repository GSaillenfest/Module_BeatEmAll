using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;
    [SerializeField] Transform launchedObjects;
    [SerializeField] PlayerController playerController;


    Animator pickUpAnimator;
    GameObject pickUp;

    public bool objectPickedUp = false;
    public bool detectsPickUp = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        WithProjectile();

    }
    public void WithProjectile()
    {


        if (Input.GetButtonDown("Fire1") && objectPickedUp && !animator.GetBool("isJumping"))
        {
            animator.SetTrigger("LaunchCan");
        }

        if (detectsPickUp && Input.GetButtonUp("Fire1") && !objectPickedUp && !animator.GetBool("isJumping") && !animator.GetBool("isAttacking"))
        {
            PickUpObject();
        }


    }

    private void PickUpObject()
    {
        animator.SetTrigger("PickUpCan");
        if (playerController.isFlipped) pickUp.transform.localScale = new Vector3(-1, 1, 1);
        pickUp.transform.SetParent(gameObject.transform.GetChild(0));
        pickUp.tag = "Projectiles";
        pickUp.GetComponent<Collider2D>().enabled = false;
        pickUp.transform.localPosition = Vector2.zero;
        pickUpAnimator = pickUp.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!objectPickedUp)
        {

            if (collision.gameObject.CompareTag("PickUp") && !animator.GetBool("isJumping"))
            {
                detectsPickUp = true;
                pickUp = collision.gameObject;
            }

        }




    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(pickUp))
        {
            detectsPickUp = false;
        }
    }
    public void ProjectileLaunch()
    {
        objectPickedUp = false;
        pickUp.transform.SetParent(launchedObjects, true);
        animator.SetBool("HasCan", false);
        pickUpAnimator.SetTrigger("Launch");

    }

    public void Drop()
    {
        if (objectPickedUp)
        {
            objectPickedUp = false;
            pickUp.transform.SetParent(launchedObjects, true);
            animator.SetBool("HasCan", false);
            pickUpAnimator.SetTrigger("Drop");
        }
    }

}
