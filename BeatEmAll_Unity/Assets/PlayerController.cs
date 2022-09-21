using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float speedForce = 30f;
    [SerializeField] Animator animator;
    [SerializeField] float jumpForce;
    [SerializeField] float maxVelocity = 3f;
    [SerializeField] float minVelocity = 2.5f;
    [SerializeField] float verticalInputFactor = 0.7f;

    Vector2 direction;
    float horizontalInput;
    float verticalInput;
    bool isWalking = false;
    bool isJumping = false;
    bool doJump = false;



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
        if (Input.GetButtonDown("Jump")) doJump = true;

    }

    private void FixedUpdate()
    {
        playerRb.AddForce(speedForce * direction, ForceMode2D.Force);
        if (!isJumping)
        {
            playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, maxVelocity);
        }
        // TODO : change clamping behaviour when jumping
        
        if (doJump)
        {
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            playerRb.gravityScale = 10f;
            doJump = false;
        }

        if (playerRb.velocity.magnitude < minVelocity && direction.magnitude == 0f)
        {
            playerRb.drag = 50f;
        }
        else playerRb.drag = 3f;
    }

    public void SetGravityToZero()
    {
        playerRb.gravityScale = 0f;
    }
}

