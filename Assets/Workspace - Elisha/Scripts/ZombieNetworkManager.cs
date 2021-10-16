using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ZombieNetworkManager : NetworkManager{
	public int numberOfEnemies; 

	public override void OnClientConnect(NetworkConnection conn){
		base.OnClientConnect(conn);
		print("Player connected");
		
		
		
	}
	
    
}
