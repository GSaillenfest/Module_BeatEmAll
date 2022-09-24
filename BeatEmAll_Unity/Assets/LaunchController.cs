using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    [SerializeField] PlayerHasCan playerHasCan;


    public void Launch()
    {
        playerHasCan.CanLaunch();
    }
}
