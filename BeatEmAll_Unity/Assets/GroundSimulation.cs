using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSimulation : MonoBehaviour
{
    [SerializeField] Transform shadow;   
    [SerializeField] Transform player;   
    


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, shadow.position.y, 0f);
    }
}
