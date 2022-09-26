using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemies : MonoBehaviour
{
    public Animator playerAnimator;
    public GameObject record;
    public GameObject tape;
    public float healthinit;
    public Animator victim;

    bool eAttacking;
    bool simpleCombo;
    bool superAttack;
    float health;

    private void Awake()

    {
        health = healthinit;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        simpleCombo = playerAnimator.GetBool("SimpleCombo");
        superAttack = playerAnimator.GetBool("SuperCombo");
    }


    public void Hit(bool simpleCombo, bool superAttack)
    {
        if (!simpleCombo && !superAttack)
        {
            if (health > (healthinit / 2) && !eAttacking && )
            {
                health -= 7.5f;
                victim.SetTrigger("isHurt");
            }

            else if (health <= (healthinit / 2) && health > (healthinit / 6) && !eAttacking)
            {
                health -= 7.5f;

                if (health > 0 && health >= (healthinit / 4))
                {
                    victim.SetTrigger("isHurt");

                }
                else if (health > 0 && health <= (healthinit / 4))
                {
                    victim.SetTrigger("isHurt");
                    DropCollectibles();
                }
                else if (health < 0)
                {
                    health = 0;
                    victim.SetTrigger("isDead");
                    DropCollectibles();
                }

            }
            else if (health <= (healthinit / 6) && !eAttacking)
            {
                health -= 7.5f;
                if (health > 0)
                {
                    victim.SetTrigger("isHurt");
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    health = 0;
                    victim.SetTrigger("isDead");
                    DropCollectibles();
                }

            }
        }




        if (health > (healthinit / 2) && !eAttacking && simpleCombo)
        {
            health -= 20f;
            victim.SetTrigger("isHurt");
        }

        else if (health <= (healthinit / 2) && health > (healthinit / 6) && !eAttacking && simpleCombo)
        {
            health -= 20f;

            if (health > 0 && health >= (healthinit / 4))
            {
                victim.SetTrigger("isHurt");
                DropCollectibles();
            }
            else if (health > 0 && health <= (healthinit / 4))
            {
                victim.SetTrigger("isHurt");
                DropCollectibles();
            }
            else if (health < 0)
            {
                health = 0;
                victim.SetTrigger("isDead");
                DropCollectibles();
            }

        }
        else if (health <= (healthinit / 6) && !eAttacking && simpleCombo)
        {
            health -= 20f;
            if (health > 0)
            {
                victim.SetTrigger("isHurt");
                DropCollectibles();
            }
            else if (health <= 0)
            {
                health = 0;
                victim.SetTrigger("isDead");
                DropCollectibles();
            }
        }



        if (health > (healthinit / 2) && !eAttacking && superAttack)
        {
            health -= 50f;
            victim.SetTrigger("isHurt");
        }

        else if (health <= (healthinit / 2) && health > (healthinit / 6) && !eAttacking && superAttack)
        {
            health -= 50f;

            if (health > 0 && health >= (healthinit / 4))
            {
                victim.SetTrigger("isHurt");
                DropCollectibles();
            }
            else if (health > 0 && health <= (healthinit / 4))
            {
                victim.SetTrigger("isHurt");
                DropCollectibles();
            }
            else if (health < 0)
            {
                health = 0;
                victim.SetTrigger("isDead");
                DropCollectibles();
            }

        }
        else if (health <= (health / 6) && !eAttacking && superAttack)
        {
            health -= 50f;
            if (health > 0)
            {
                victim.SetTrigger("isHurt");
                DropCollectibles();
            }
            else if (health <= 0)
            {
                health = 0;
                victim.SetTrigger("isDead");
                DropCollectibles();
            }

        }
    }


    public void DropCollectibles()
    {

    }

}

