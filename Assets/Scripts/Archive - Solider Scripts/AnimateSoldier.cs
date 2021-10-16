using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSoldier : MonoBehaviour
{
    Animator charAnim;
    private bool walkState = false;

    // Use this for initialization
    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mvY = Input.GetAxis("Horizontal");
        float mvX = Input.GetAxis("Vertical");

        if (mvX != 0 || mvY != 0)
        {
            if (walkState == false)
            {
                charAnim.SetTrigger("run");
                walkState = true;
            }
        }
        else
        {
            if (walkState == true)
            {
                charAnim.SetTrigger("stop");
                walkState = false;
            }
        }
    }
}