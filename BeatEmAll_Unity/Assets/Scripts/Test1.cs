using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Transform shadow;
    [SerializeField] float ySpeed;

    float horizontalInput;
    float verticalInput;
    bool isJumping = false;
    bool doJump;
    float yPosBeforeJump;
    Vector2 direction;



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

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            doJump = true;
        }
        
        if (!isJumping) yPosBeforeJump = rb2D.transform.localPosition.y;
        if (isJumping && verticalInput != 0) yPosBeforeJump += ySpeed * verticalInput * Time.deltaTime;

        shadow.transform.localPosition = new Vector2(rb2D.transform.localPosition.x, yPosBeforeJump - 0.51f);

        if (rb2D.velocity.magnitude < 0.5f && direction.magnitude == 0 && !isJumping) rb2D.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (isJumping && rb2D.transform.localPosition.y < yPosBeforeJump - 0.1f)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.gravityScale = 0f;
            rb2D.transform.localPosition = new Vector2(rb2D.transform.localPosition.x, yPosBeforeJump);
            isJumping = false;
        }

        if (!isJumping) rb2D.AddForce(direction * 10f);
        else rb2D.AddForce(new Vector2(direction.x, 0f) * 10f);

        if (doJump)
        {
            //rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
            yPosBeforeJump = rb2D.transform.localPosition.y;
            isJumping = true;
            rb2D.AddRelativeForce(new Vector2(0, 7), ForceMode2D.Impulse);
            rb2D.gravityScale = 0.7f;
            doJump = false;
        }
    }
}
