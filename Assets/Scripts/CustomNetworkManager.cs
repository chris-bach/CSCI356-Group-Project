using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
	public void StartupHost(){
		NetworkServer.Reset();
		SetPort();
		//NetworkManager.singleton.StartHost();
		base.StartHost();
	}
	void SetPort(){
		base.networkPort = 7777;
	}
	public void JoinGame(){
		SetIPAddress();
		SetPort();
		base.StartClient();
	}
	void SetIPAddress(){
		string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
		base.networkAddress = ipAddress;
	}
	/*
	void OnLevelWasLoaded(int level){
		print("Level " + level + " has loaded");
		if(level == 0){
			SetupMenuSceneButtons();
			print("SetupMenuSceneButtons();");
		}
		else{
			SetupOtherSceneButtons();
			print("SetupOtherSceneButtons()");
		}
	}*/
	
	void SetupMenuSceneButtons(){
		GameObject.Find("StartHost").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("StartHost").GetComponent<Button>().onClick.AddListener(StartupHost);

		GameObject.Find("JoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("JoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
	}
	void SetupOtherSceneButtons(){
		GameObject.Find("Disconnect").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("Disconnect").GetComponent<Button>().onClick.AddListener(base.StopHost);
	}

	 void OnEnable(){
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	  }

	 void OnDisable(){
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	 }
	 void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
		if(scene.buildIndex == 0){
			SetupMenuSceneButtons();
			print("SetupMenuSceneButtons();");
		}
		else{
			SetupOtherSceneButtons();
			print("SetupOtherSceneButtons()");
		}
	}
			 
	public void QuitGame()
    {
		Application.Quit();
	}

}
