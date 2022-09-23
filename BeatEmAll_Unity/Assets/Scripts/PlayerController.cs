using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] ShadowScript shadow;
    [SerializeField] Transform graphics;
    [SerializeField] Transform playerParent;
    [SerializeField] public float speedForce = 30f;
    [SerializeField] Animator animator;
    [SerializeField] float jumpForce;
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
        isJumping = animator.GetBool("isJumping");
        MovementInputs();
        FlipSprite();

    }

    private void MovementInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        switch (shadow.clampVert)
        {
            case "Top":
                verticalInput = Mathf.Clamp(verticalInput, -1f, 0f);
                break;
            case "Down":
                verticalInput = Mathf.Clamp01(verticalInput);
                break;
            default:
                break;
        }
        switch (shadow.clampHori)
        { 
            case "Left":
                horizontalInput = Mathf.Clamp01(horizontalInput);
                break;
            case "Right":
                horizontalInput = Mathf.Clamp(horizontalInput, -1f, 0f);
                break;
            default:
                break;
        }
        direction = new Vector2(horizontalInput, verticalInput).normalized;
        
        if (direction.magnitude > 0) isWalking = true;
        else isWalking = false;
        
        animator.SetBool("isWalking", isWalking);
        
        if (Input.GetButtonDown("Jump") && !isJumping) doJump = true;
    }

    private void FlipSprite()
    {
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
        Move();
        Jump();
    }

    private void Move()
    {
        if (!contact || verticalInput != 0)
        {
            playerParent.Translate(new Vector2(direction.x, direction.y * vertInputMultiplier) * speedForce);
        }
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


}

