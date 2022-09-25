using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;

    

    public void SetGravity(float gravityScaleFactor)
    {
        playerRb.gravityScale = gravityScaleFactor;
    }

    
}
