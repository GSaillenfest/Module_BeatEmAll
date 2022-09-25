using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator shadowAnimator;
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform shadow;

    public string clampVert = "";
    public string clampHori = "";
    Vector3 startShadowScale;

    // Start is called before the first frame update
    void Start()
    {
        startShadowScale = shadow.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > player.position.y) transform.position = new Vector2(player.position.x, player.position.y);
        else if (playerController.contact && !playerController.isJumping) transform.position = new Vector2(player.position.x, player.position.y);
        else
        {
            transform.position = new Vector2(player.position.x, transform.position.y);
            //shadowAnimator.SetBool("isJumping", playerController.isJumping);
        }

        shadow.localScale = ((player.position.y - transform.position.y) - 3.33f) / -3.33f * startShadowScale;

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
