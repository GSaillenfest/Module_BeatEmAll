using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //public GameObject record;
    //public GameObject tape;
    public float healthinit;
    public Animator enemyAnimator;
    public ParticleSystem blood;
    [SerializeField] Transform player;
    public Image enemyHealthBar;

    public bool isAttacking;
    bool simpleCombo;
    bool superAttack;
    public float health;
    float pauseTimer;

    private void Awake()

    {
        health = healthinit;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = enemyAnimator.GetBool("isAttacking");
        blood.transform.localScale = new Vector3(player.position.x - transform.position.x, 1f, 1f);
        enemyHealthBar.fillAmount = Mathf.Clamp(health / healthinit, 0, 1f);
        pauseTimer += Time.unscaledDeltaTime;
        if (pauseTimer > 0.5f) PauseAnimation(false);
    }


    public void Hit(bool simpleCombo, bool superAttack)
    {

        if (!simpleCombo && !superAttack)
        {
            if (health > (healthinit / 2) && !isAttacking)
            {
                blood.Play();
                health -= 7.5f;
                enemyAnimator.SetTrigger("Hurt");
                PauseAnimation(true);
            }

            else if (health <= (healthinit / 2) && health > (healthinit / 6) && !isAttacking)
            {
                health -= 7.5f;

                if (health > 0 && health >= (healthinit / 4))
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                PauseAnimation(true);
                }
                else if (health > 0 && health <= (healthinit / 4))
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                PauseAnimation(true);
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    blood.Play();
                    health = 0;
                    enemyAnimator.SetBool("isDead", true);
                PauseAnimation(true);
                    DropCollectibles();
                }

            }
            else if (health <= (healthinit / 6) && !isAttacking)
            {
                health -= 7.5f;
                if (health > 0)
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                PauseAnimation(true);
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    health = 0;
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                PauseAnimation(true);
                    enemyAnimator.SetBool("isDead", true);
                    DropCollectibles();
                }
            }
        }


        if (simpleCombo)
        {
            if (health > (healthinit / 2) && !isAttacking)
            {
                health -= 20f;
                blood.Play();
                enemyAnimator.SetTrigger("Hurt");
            }

            else if (health <= (healthinit / 2) && health > (healthinit / 6) && !isAttacking)
            {
                health -= 20f;

                if (health > 0 && health >= (healthinit / 4))
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    DropCollectibles();
                }
                else if (health > 0 && health <= (healthinit / 4))
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    health = 0;
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    enemyAnimator.SetBool("isDead", true);
                    DropCollectibles();
                }

            }
            else if (health <= (healthinit / 6) && !isAttacking)
            {
                health -= 20f;
                if (health > 0)
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    health = 0;
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    enemyAnimator.SetBool("isDead", true);
                    DropCollectibles();
                }
            }
        }

        if (superAttack)
        {
            if (health > (healthinit / 2) && !isAttacking)
            {
                health -= 50f;
                blood.Play();
                enemyAnimator.SetTrigger("Hurt");
            }

            else if (health <= (healthinit / 2) && health > (healthinit / 6) && !isAttacking)
            {
                health -= 50f;

                if (health > 0 && health >= (healthinit / 4))
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    DropCollectibles();
                }
                else if (health > 0 && health <= (healthinit / 4))
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    health = 0;
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    enemyAnimator.SetBool("isDead", true);
                    DropCollectibles();
                }

            }
            else if (health <= (health / 6) && !isAttacking)
            {
                health -= 50f;
                if (health > 0)
                {
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    DropCollectibles();
                }
                else if (health <= 0)
                {
                    health = 0;
                    blood.Play();
                    enemyAnimator.SetTrigger("Hurt");
                    enemyAnimator.SetBool("isDead", true);
                    DropCollectibles();
                }

            }
        }
    }

    private void PauseAnimation(bool isPause)
    {
        if (isPause)
        {
            enemyAnimator.speed = 0.1f;
            pauseTimer = 0;
            Debug.Log("TimePaused");
        }
        else
        {
            enemyAnimator.speed = 1;
        }
    }

    public void DropCollectibles()
    {
        Debug.Log("Drops");
    }

}

