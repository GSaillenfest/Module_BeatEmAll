using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShadowScript : MonoBehaviour
{
    [SerializeField] Transform enemy;
    [SerializeField] EnemiesBehaviour enemyScript;
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
        Debug.Log((enemy.position.y - transform.position.y));

        //if (transform.position.y > enemy.position.y) transform.position = new Vector2(enemy.position.x, enemy.position.y);
        if (enemyScript.behaviour != 3 && !enemyScript.isJumping) transform.position = new Vector2(enemy.position.x, enemy.position.y);
        else
        {
            transform.position = new Vector2(enemy.position.x, transform.position.y);
        }

        shadow.localScale = ((enemy.position.y - transform.position.y) - 3.33f) / -3.33f * startShadowScale;

    }


}

