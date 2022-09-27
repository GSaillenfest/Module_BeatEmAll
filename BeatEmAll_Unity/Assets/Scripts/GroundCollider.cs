using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    [SerializeField] Animator animator;

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("isJumping", false);
        Debug.Log(collision.gameObject.name);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collision");
        switch (collision.gameObject.tag)
        {
            case "TopBorder":
                clampVert = "Top";
                break;
            case "DownBorder":
                clampVert = "Down";
                break;
            case "LeftBorder":
                clampHori = "Left";
                break;
            case "RightBorder":
                clampHori = "Right";
                break;
            default:
                break;
        }
        if (collision.gameObject.CompareTag("TopBorder"))
        {
            Debug.Log("You Shall Not Pass !!!!!!!!!");
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
