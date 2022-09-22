using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHasCan: MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void WithCan()
    {
        void OncollisionEnterCan(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("can")
            { 
                animator.SetBool(HasCan,true)
            }
        }
    }
}
