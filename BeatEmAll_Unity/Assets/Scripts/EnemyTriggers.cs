using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggers : MonoBehaviour
{

    [SerializeField] EnemiesBehaviour enemiesBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemiesBehaviour.ChangeBehaviour(2);
            enemiesBehaviour.jumpTriggered = false;
        }

        if (collision.gameObject.CompareTag("Projectiles"))
        {
            Debug.Log("isHurt");
            gameObject.GetComponent<EnemyHealth>().Hit(false, false);
        }
    }
}
