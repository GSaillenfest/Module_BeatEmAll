using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadow : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] Transform shadow;
    [SerializeField] Animator animator;
    [SerializeField] Animator shadowAnimator;

    public float yPosBeforeJump;
    public bool isJumping = false;
    Vector3 startShadowScale;


    // Start is called before the first frame update
    void Start()
    {
        startShadowScale = shadow.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        isJumping = animator.GetBool("isJumping");
        shadowAnimator.SetBool("isJumping", isJumping);

        if (!isJumping) yPosBeforeJump = rb2D.transform.position.y;

        shadow.localScale = ((rb2D.position.y - shadow.position.y) - 3.33f) / -3.33f * startShadowScale;

        shadow.transform.position = new Vector2(rb2D.transform.position.x, yPosBeforeJump + .45f);
    }


}
