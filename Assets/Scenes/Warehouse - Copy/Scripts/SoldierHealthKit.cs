using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SoldierHealthKit : NetworkBehaviour
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
            SoldierHealth player = other.transform.GetComponent<SoldierHealth>();

            if (player != null)
            {
                player.ChangeHealth(12);
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
