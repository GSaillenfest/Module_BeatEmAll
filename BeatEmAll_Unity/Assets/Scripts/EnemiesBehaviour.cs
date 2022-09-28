using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemiesRb;
    [SerializeField] float speed = 0.05f;
    [SerializeField] Animator animator;
    [SerializeField] float dragWhenIsHurt;
    [SerializeField] float jumpForce;
    [SerializeField] GroundCollider groundCollider;


    public Transform player;
    Vector2 randomPos;
    public bool move = true; // used for hurt state when false 
    public int behaviour = 0;
    float moveTimer = 3f;
    public bool isAttacking;
    public bool attackTriggered = false;
    public bool isJumping;
    public bool jumpTriggered = false;
    bool isHurt;
    public bool playerIsAttacking;
    float drag;
    bool firstPath = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        RandomPos();
        drag = enemiesRb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = animator.GetBool("isAttacking");
        isHurt = animator.GetBool("isHurt");
        isJumping = animator.GetBool("isJumping");

        if (isHurt) behaviour = 5;

        playerIsAttacking = player.GetComponent<Animator>().GetBool("isAttacking");
        if ((behaviour == 2 && !isJumping) || behaviour == 5) enemiesRb.drag = dragWhenIsHurt;
        else enemiesRb.drag = drag;

        if (move)
        {
            animator.SetBool("isWalking", true);
            enemiesRb.gravityScale = 0f;
        }
        else
        {
            animator.SetBool("isWalking", false);
            enemiesRb.gravityScale = 1.1f;
        }


    }

    private void FlipSprite(Vector2 destination)
    {
        if (destination.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (destination.x - transform.position.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (!firstPath)
        {
            switch (groundCollider.clampVert)
            {
                case "TopBorder":
                case "DownBorder":
                    
                    break;
                default:
                    break;
            }
            switch (groundCollider.clampHori)
            {
                case "LeftBorder":
                case "RightBorder":
                    break;
                default:
                    break;
            }
        }

        switch (behaviour)
        {
            case 0:
                move = true;
                Movevement(randomPos);
                break;
            case 1:
                move = true;
                Movevement(player.position);
                break;
            case 2:
                move = false;
                Attack();
                break;
            case 3:
                move = false;
                Jump();
                break;
            case 4:
                move = false;
                Idle();
                break;
            case 5:
                move = false;
                Hurt();
                break;
            default:
                move = false;
                break;
        }

    }

    private void Hurt()
    {
        if (!isHurt) behaviour = 4;
    }

    private void Idle()
    {
        if (!isJumping)
        {
            if (moveTimer >= 0)
            {
                moveTimer -= Time.fixedDeltaTime;
            }
            else
            {
                moveTimer = 3f;
                ChangeBehaviour(0, 4);
            }
        }
    }

    private void Jump()
    {
        if (!isAttacking && !jumpTriggered)
        {
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            enemiesRb.AddRelativeForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            enemiesRb.gravityScale = 0.5f;
            jumpTriggered = true;
        }

    }

    private void Attack()
    {
        if (!isAttacking && !attackTriggered)
        {
            animator.SetTrigger("Attack");
            attackTriggered = true;
        }
    }

    void Movevement(Vector2 destination)
    {
        if (move && !isJumping)
        {
            if ((destination - enemiesRb.position).magnitude > 0.2f && moveTimer >= 0)
            {
                moveTimer -= Time.fixedDeltaTime;
                transform.parent.Translate((destination - new Vector2(transform.parent.position.x, transform.parent.position.y)).normalized * speed);
            }
            else
            {
                moveTimer = 3f;
                firstPath = false;
                RandomPos();
                ChangeBehaviour(0, 4);
            }
            FlipSprite(destination);
        }

    }

    void RandomPos()
    {
        randomPos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.5f), 10));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is close");
            behaviour = 2;
            jumpTriggered = false;
        }

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Projectiles"))
        {
            Debug.Log("isHurt");
            gameObject.GetComponent<HealthEnemies>().Hit(false, false);
        }
    }

    public void ChangeBehaviour(int min, int max)
    {
        behaviour = Random.Range(min, max + 1);
        attackTriggered = false;
        jumpTriggered = false;
    }

    //void Jumping()
    //{
    //    if (isJumping)
    //    Debug.Log(transform.position.y + "   " + yPosBeforeJump);
    //    {
    //        if (transform.position.y < yPosBeforeJump)
    //        {
    //            enemiesRb.gravityScale = 0f;
    //            enemiesRb.velocity = new Vector2(enemiesRb.velocity.x, 0);
    //            transform.position = new Vector2(transform.position.x, yPosBeforeJump);
    //            animator.SetBool("isJumping", false);
    //        }
    //    }
    //}


}
