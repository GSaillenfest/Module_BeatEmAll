using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody2D enemiesRb;
    [SerializeField] float speed = 0.05f;
    [SerializeField] Animator animator;
    [SerializeField] Transform shadow;

    Transform player;
    Vector3 enemiespos;
    Vector2 randomPos;
    bool Move = true; // used for hurt state when false 
    int behaviour = 0;
    float moveTimer = 3f;
    Vector3 startShadowScale;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startShadowScale = shadow.localScale;
    }

    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        shadow.localScale = ((enemiesRb.position.y - enemiesRb.position.y) - 3.33f) / -3.33f * startShadowScale;
    }

    private void FixedUpdate()
    {
        switch (behaviour)
        {
            case 0:
                Movevement(randomPos);
                break;
            case 1:
                Movevement(player.position);
                break;
            case 2:
                Attack();
                break;
            case 3:
                Jump();
                break;
            case 4:
                Idle();
                break;

            default:
                break;
        }

        //if (enemiespos == screenCenter)



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
        animator.SetBool("isJumping", true);
        behaviour = Random.Range(0, 5);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        behaviour = Random.Range(0, 5);
    }

    void Movevement(Vector2 destination)
    {
        if ((destination - enemiesRb.position).magnitude > 0.2f && moveTimer >= 0)
        {
            moveTimer -= Time.fixedDeltaTime;
            enemiesRb.MovePosition((destination - enemiesRb.position).normalized * speed + enemiesRb.position);
            animator.SetBool("isWalking", true);
        }
        else
        {
            moveTimer = 3f;
            animator.SetBool("isWalking", false);
            RandomPos();
            behaviour = Random.Range(0, 5);
        }

        //TODO else if timer trop grand, changement de behaviour


    }

    void RandomPos()
    {
        randomPos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.2f, 0.8f), Random.Range(0.2f, 0.5f), 10));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            behaviour = 2;
        }
    }
}
