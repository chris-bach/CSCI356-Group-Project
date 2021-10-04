using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1); // Or whichever scene is made the index of '1' in build settings
    }

    public void QuitGame()
    {
        Debug.Log("Quit only works when you build and run ;)");
        Application.Quit();
    }
    
}
