using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void startGame(){
    	print("startGame()");
    	SceneManager.LoadScene(1); 
    }
    public void quitGame(){
    	print("quitGame()");
    	Application.Quit();
    }
}
