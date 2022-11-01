using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{

    [SerializeField] int maxEnemiesLvl;
    [SerializeField] GameObject enemies1;


    public int nbEnemiesLvl = 0;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, Random.Range(0f, 0.5f), 10f)));
    }

    public void Spawn()
    {

        if (nbEnemiesLvl < maxEnemiesLvl)
        {
            int LorR = Random.Range(0, 2);
            Vector3 spawnpos;
            if (LorR == 0)
            {
                spawnpos = Camera.main.ViewportToWorldPoint(new Vector3(-0.2f, Random.Range(0f, 0.5f), 10f));
            }
            else
            {
                spawnpos = Camera.main.ViewportToWorldPoint(new Vector3(1.2f, Random.Range(0f, 0.5f), 10f));
            }

            Instantiate(enemies1, spawnpos, Quaternion.identity, transform);
            nbEnemiesLvl++;
        }
    }
}
