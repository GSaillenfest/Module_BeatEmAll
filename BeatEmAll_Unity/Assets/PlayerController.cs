using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Transform graphics;
    [SerializeField] Transform playerParent;
    [SerializeField] public float speedForce = 30f;
    [SerializeField] Animator animator;
    [SerializeField] float jumpForce;
    [SerializeField] float maxVelocity = 3f;
    [SerializeField] float minVelocity = 2.5f;
    [SerializeField] float vertInputMultiplier = 0.7f;

    public Vector2 direction;
    float horizontalInput;
    float verticalInput;
    bool isWalking = false;
    public bool isJumping = false;
    bool doJump = false;
    public bool contact = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticalInput).normalized;
        if (direction.magnitude > 0) isWalking = true;
        else isWalking = false;
        isJumping = animator.GetBool("isJumping");

        animator.SetBool("isWalking", isWalking);
        if (Input.GetButtonDown("Jump") && !isJumping) doJump = true;

        if (horizontalInput < 0)
        {
            graphics.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            graphics.localScale = new Vector3(1, 1, 1);
        }

    }

    private void FixedUpdate()
    {
        //seems to be unrelevant
        if (!contact || verticalInput !=0)
        {
            playerParent.Translate(new Vector2(direction.x, direction.y * vertInputMultiplier) * speedForce);
        }
        

        Jump();
    }

    private void Jump()
    {
        if (doJump)
        {

            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            playerRb.AddRelativeForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerRb.gravityScale = 0.5f;
            doJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerGroundCollider"))
        {
            playerRb.gravityScale = 0f;
            isJumping = false;
            Debug.Log("Ground");
        }
        if (collision.gameObject.CompareTag("Props"))
        {
            contact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Props"))
        {
            contact = false;
        }
    }

}

