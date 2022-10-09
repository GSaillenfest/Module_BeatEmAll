using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFeedback : MonoBehaviour
{
    [SerializeField] Animator animator;

    public bool isShaking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void ShakeCamera()
    {
        if (!isShaking)
        {
            animator.SetTrigger("shake");
        }
    }
}
