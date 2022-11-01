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
    [SerializeField] EnemyGroundCollider groundCollider;
    [SerializeField] GravityController gravityController;
    [SerializeField] float moveTimer = 3f;
    [SerializeField] float idleTimer = 3f;


    public Transform player;
    Vector2 randomPos;
    public bool move = true; // used for hurt state when false 
    public int behaviour = 0;
    public bool isAttacking;
    public bool attackTriggered = false;
    public bool isJumping;
    public bool jumpTriggered = false;
    bool isHurt;
    public bool playerIsAttacking;
    float drag;
    bool firstPath = true;
    bool isDead;
    private float yPosBeforeJump;

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

        if (isHurt) ChangeBehaviour(5);

        playerIsAttacking = player.GetComponent<Animator>().GetBool("isAttacking");
        if ((behaviour == 2 && !isJumping) || behaviour == 5) enemiesRb.drag = dragWhenIsHurt;
        else enemiesRb.drag = drag;

        if (isDead) move = false;

        if (move)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //if (!isJumping) enemiesRb.velocity = new Vector2(enemiesRb.velocity.x, 0f);

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
                    gravityController.SetGravity(0f);
                    move = false;
                    break;
                default:
                    break;
            }
            switch (groundCollider.clampHori)
            {
                case "LeftBorder":
                case "RightBorder":
                    randomPos = player.position;
                    break;
                default:
                    break;
            }
        }

        switch (behaviour)
        {
            case 0:
                move = true;
                Movement(randomPos);
                break;
            case 1:
                move = true;
                Movement(player.position);
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
        if (!isHurt) ChangeBehaviour(4);
    }

    private void Idle()
    {
        if (!isJumping)
        {
            if (idleTimer >= 0)
            {
                idleTimer -= Time.fixedDeltaTime;
            }
            else
            {
                idleTimer = 3f;
                ChangeBehaviour(0, 4);
            }
        }
    }

    private void Jump()
    {
        if (!isAttacking && !jumpTriggered)
        {
            yPosBeforeJump = transform.position.y; 
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

    void Movement(Vector2 destination)
    {
        if (move && !isJumping)
        {
            if ((destination - enemiesRb.position).magnitude > 0.05f && (firstPath || moveTimer >= 0))
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

    public void ChangeBehaviour(int min, int max = -1)
    {
        if (max == -1)
        {
            behaviour = min;
            attackTriggered = false;
            jumpTriggered = false;
        }
        else
        {
            behaviour = Random.Range(min, max + 1);
            attackTriggered = false;
            jumpTriggered = false;
        }
    }

    void Jumping()
    {
        if (isJumping)
            Debug.Log(transform.position.y + "   " + yPosBeforeJump);
        {
            if (transform.position.y < yPosBeforeJump)
            {
                enemiesRb.gravityScale = 0f;
                enemiesRb.velocity = new Vector2(enemiesRb.velocity.x, 0);
                animator.SetBool("isJumping", false);
            }
        }
    }


}
