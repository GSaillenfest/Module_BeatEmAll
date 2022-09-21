using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D shadowRb;
    [SerializeField] PlayerController playerController;

    Vector2 direction;
    float horizontalInput;
    float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        shadowRb.AddForce(playerController.speedForce * playerController.direction, ForceMode2D.Force);
    }
}
