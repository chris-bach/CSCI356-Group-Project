using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ZombieAI : NetworkBehaviour{
    Animator charAnim;
    private UnityEngine.AI.NavMeshAgent nm;

    void Start(){
        charAnim = GetComponent<Animator>();
        nm = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(SearchForPlayer());
    }

    IEnumerator SearchForPlayer(){
    	//Get a list of players
    	//For each player, check which player is the most close by in regard to Euclidean distance
    	//If this player is less than 31 units away, target the player
    	//Else stay idle
    	//This proces is repeated every 0.2 seconds

    	GameObject[] players;
    	float shortestPath = 99999F;
    	Transform targetPlayer = null;

    	while(true){
    		players = GameObject.FindGameObjectsWithTag("Player");
    		if(players != null && players.Length > 0){
    			for(int x = 0;x < players.Length;x++){
    				if(Vector3.Distance(players[x].transform.position, transform.position) < shortestPath){
    					shortestPath = Vector3.Distance(players[x].transform.position, transform.position);
    					targetPlayer = players[x].transform;
    				}
    				print(Vector3.Distance(players[x].transform.position, transform.position));
    				//print("Player " + x);
    			}
    			//If the player is within a short distance, run after them!
    			if(shortestPath < 31){
    				nm.SetDestination(targetPlayer.position);
    				charAnim.SetTrigger("Running");
    			}
    			//If the zombie reaches the player, it begins attacking 
    			if(Vector3.Distance(targetPlayer.position, transform.position) < 4){
    				charAnim.SetTrigger("Attacking");
    			}
    		}
    		yield return new WaitForSeconds(1F);
    	}

    }
}
