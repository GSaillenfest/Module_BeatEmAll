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
    [SerializeField] float vertInputMultiplier = 0.7f;

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
        if (Input.GetButtonDown("Jump") && !isJumping) doJump = true;

        if (horizontalInput < 0)
        {
            transform.parent.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }

    }

    private void FixedUpdate()
    {
        playerRb.AddForce(speedForce * direction, ForceMode2D.Force);
        if (!isJumping)
        {
            playerRb.velocity = new Vector2(
                Mathf.Clamp(playerRb.velocity.x, -maxVelocity / 2, maxVelocity / 2),
                Mathf.Clamp(playerRb.velocity.y, -maxVelocity / 2 * vertInputMultiplier, maxVelocity / 2 * vertInputMultiplier)
                );
        }
        else playerRb.velocity = new Vector2(
            Mathf.Clamp(playerRb.velocity.x, -maxVelocity / 2, maxVelocity / 2),
            Mathf.Clamp(playerRb.velocity.y, -maxVelocity / 2 * vertInputMultiplier, maxVelocity / 2 * vertInputMultiplier + 1f)
            );

        Jumping();
        ChangeDrag();
    }

    private void ChangeDrag()
    {
        if (!isJumping)
        {
            if (playerRb.velocity.magnitude < minVelocity && direction.magnitude == 0f)
            {
                playerRb.drag = 50f;
            }
            else playerRb.drag = 3f;
        }
    }

    private void Jumping()
    {
        if (doJump)
        {
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            playerRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            doJump = false;
        }
    }

}

