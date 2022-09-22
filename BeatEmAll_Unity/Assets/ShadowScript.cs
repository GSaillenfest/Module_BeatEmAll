using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator shadowAnimator;
    [SerializeField] PlayerController playerController;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > player.position.y) transform.position = new Vector2(player.position.x, player.position.y);
        else if (playerController.contact /*&& !playerController.isJumping*/) transform.position = new Vector2(player.position.x, player.position.y);
        else
        {
            transform.position = new Vector2(player.position.x, transform.position.y);
            shadowAnimator.SetBool("isJumping", playerController.isJumping);
        }
    }

  
}
