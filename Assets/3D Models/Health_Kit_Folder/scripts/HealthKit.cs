using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealth player = other.transform.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.GainedHealthKit();
            }

            Destroy(this.gameObject);
        }
    }

    public void OnHealthCreated()
    {
        Debug.Log("OnHealthCreated called");
        Destroy(this.gameObject);
    }
}
