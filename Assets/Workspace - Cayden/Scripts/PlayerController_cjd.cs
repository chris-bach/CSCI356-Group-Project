using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_cjd : MonoBehaviour
{
    private const float SPEED = 5.0F;
    [SerializeField] private int health = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mvX = Input.GetAxis("Horizontal") * Time.deltaTime * SPEED;
        float mvZ = Input.GetAxis("Vertical") * Time.deltaTime * SPEED;

        transform.Translate(mvX, 0, mvZ);

    }

    public void GainedHealthKit()
    {
        health += 10;

        if (health >= 91)
        {
            health = 100;
        }
    }
}