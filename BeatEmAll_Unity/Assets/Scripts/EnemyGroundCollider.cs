using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundCollider : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D enemyRb;

    public string clampVert = "";
    public string clampHori = "";


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("Ground ? " + collision.gameObject.name);

        if (collision.transform.parent.Equals(transform.parent.parent))
        {
            Debug.Log("ok");
            animator.SetBool("isJumping", false);
            enemyRb.gravityScale = 0f;
            enemyRb.velocity = new Vector2(enemyRb.velocity.x, 0f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "TopBorder":
            case "DownBorder":
                clampVert = collision.gameObject.tag;
                break;
            case "LeftBorder":
            case "RightBorder":
                clampHori = collision.gameObject.tag;
                break;
            default:
                break;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopBorder") || collision.gameObject.CompareTag("DownBorder"))
        {
            clampVert = "";
        }
        if (collision.gameObject.CompareTag("LeftBorder") || collision.gameObject.CompareTag("RightBorder"))
        {
            clampHori = "";
        }
    }
}
