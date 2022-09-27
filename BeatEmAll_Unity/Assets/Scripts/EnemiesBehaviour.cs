using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemiesRb;
    [SerializeField] float speed = 0.05f;
    [SerializeField] Animator animator;
    [SerializeField] float dragWhenIsHurt;

    public Transform player;
    Vector2 randomPos;
    public bool move = true; // used for hurt state when false 
    public int behaviour = 0;
    float moveTimer = 3f;
    public bool isAttacking;
    public bool attackTriggered = false;
    bool isJumping;
    public bool jumpTriggered = false;
    bool isHurt;
    public bool playerIsAttacking;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = animator.GetBool("isAttacking");
        isHurt = animator.GetBool("isHurt");
        isJumping = animator.GetBool("isJumping");

        if (isHurt) behaviour = 5;

        playerIsAttacking = player.GetComponent<Animator>().GetBool("isAttacking");
        if (behaviour == 4 || behaviour == 5) enemiesRb.drag = dragWhenIsHurt;
        else enemiesRb.drag = 1;

        if (move) animator.SetBool("isWalking", true);
        else animator.SetBool("isWalking", false);


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
        if (moveTimer >= 0)
        {
            moveTimer -= Time.fixedDeltaTime;
        }
        else
        {
            moveTimer = 3f;
            behaviour = Random.Range(0, 5);
        }
    }

    private void Jump()
    {
        if (!isAttacking && !jumpTriggered)
        {
            animator.SetTrigger("Jump");
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
        if (move)
        {

            if ((destination - enemiesRb.position).magnitude > 0.2f && moveTimer >= 0)
            {
                moveTimer -= Time.fixedDeltaTime;
                enemiesRb.MovePosition((destination - enemiesRb.position).normalized * speed + enemiesRb.position);
            }
            else
            {
                moveTimer = 3f;
                RandomPos();
                behaviour = Random.Range(0, 5);
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

    

    
}
