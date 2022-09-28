using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform shadow;


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
        }

        shadow.localScale = ((player.position.y - transform.position.y) - 3.33f) / -3.33f * startShadowScale;
    }


}

