using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadow : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Transform shadow;
    [SerializeField] Animator animator;
    [SerializeField] Animator shadowAnimator;

    float yPosBeforeJump;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isJumping = animator.GetBool("isJumping");
        shadowAnimator.SetBool("isJumping", isJumping);

        if (!isJumping) yPosBeforeJump = rb2D.transform.localPosition.y;
        
        shadow.transform.localPosition = new Vector2(rb2D.transform.localPosition.x, yPosBeforeJump);
    }


}
