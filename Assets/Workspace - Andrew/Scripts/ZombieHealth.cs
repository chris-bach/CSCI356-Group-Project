using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ZombieHealth : NetworkBehaviour
{
    public int health = 75;
    private Rigidbody target;
    private NetworkStartPosition[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
            target = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HitByBullet(int damage) // process a message HitByBullet
    {
        if(!isServer)
        {
            return;
        }
        
        health -= damage;

        if (health < 1)
        {
            Destroy(gameObject);
        }
        else
        {
            health = 75;
            RpcRespawn();
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;

            if(spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            transform.position = spawnPoint;
        }
    }
}
