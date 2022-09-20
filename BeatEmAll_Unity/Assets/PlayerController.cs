using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float speed = 5f;
    [SerializeField] Animator animator;

    Vector2 direction;
    float horizontalInput;
    float verticalInput;
    bool isWalking = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2 (horizontalInput, verticalInput).normalized;
        if (direction.magnitude > 0) isWalking = true;
        else isWalking = false;

        animator.SetBool("isWalking", isWalking);

    }

    private void FixedUpdate()
    {
        playerRb.velocity = speed * direction;
    }
}
