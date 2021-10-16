using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ZombieSpawnManager : NetworkBehaviour{
	public GameObject enemyPrefab;
	public int numberOfEnemies; 
	public Transform[] zombieSpawnPoints;
	GameObject[] players;
	int playerCount;

	void Start(){
		StartCoroutine(CheckPlayerCount());
	}
	IEnumerator CheckPlayerCount(){
		while(true){
			players = GameObject.FindGameObjectsWithTag("Player");
    		if(players != null && players.Length != 0){
    			if(players.Length > playerCount) CmdSpawnZombie();
    			
    			playerCount = players.Length;
    			print("Players = " + playerCount);
    		}
    		yield return new WaitForSeconds(5F);
		}
	}

	[Command]
	public void CmdSpawnZombie(){
		int randomSpawnPoint = Mathf.RoundToInt(Random.Range(0F,zombieSpawnPoints.Length-1));
		print(randomSpawnPoint);
		Quaternion spawnRotation = Quaternion.Euler(0F,Random.Range(0F,180F),0);

        GameObject enemy = (GameObject) Instantiate(enemyPrefab,zombieSpawnPoints[randomSpawnPoint].transform.position,spawnRotation);
        NetworkServer.Spawn(enemy);
	}

    
}
