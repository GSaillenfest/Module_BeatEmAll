using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
   
    

    public bool isAttacking;
    public float health =100;

    private void Awake()

    {
      
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = gameObject.GetComponent<Animator>().GetBool("isAttacking");
     
    }


    public void Hit()
    {
        Debug.Log(" Player HIT is called");

        if (health > 0 && !isAttacking)
        {
            health -= 7.5f;
            gameObject.GetComponent<Animator>().SetTrigger("IsHurt");
        }

        else if (health <= 0)
        {
            health = 0;
            gameObject.GetComponent<Animator>().SetTrigger("IsHurt");
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            Destroy(gameObject);

        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hit();
        }
    }

}
