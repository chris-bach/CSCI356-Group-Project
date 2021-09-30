using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnimateSoldier : NetworkBehaviour
{
    Animator charAnim;
    private bool walkState = false;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer) return;

        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        float mvY = Input.GetAxis("Horizontal");
        float mvX = Input.GetAxis("Vertical");

        if (mvX != 0 || mvY != 0)
        {
            if (walkState == false)
            {
                GetComponent<NetworkAnimator>().SetTrigger("run");
                walkState = true;
                //Debug.Log("Set to walk");  
            }
        }
        else
        {
            if (walkState == true)
            {
                GetComponent<NetworkAnimator>().SetTrigger("stop");
                walkState = false;
                //Debug.Log("Set to stop");
            }
        }
    }
}