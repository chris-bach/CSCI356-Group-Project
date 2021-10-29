using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private bool isMoving;
    public AudioSource walkAudio;

    void Update()
    {
        walk();
    }
    void walk()
    {

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) isMoving = true;
        else isMoving = false;
        if (!walkAudio.isPlaying && isMoving) walkAudio.Play();
        else if(!isMoving) walkAudio.Stop();
    }
}
