using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainHealth : MonoBehaviour
{
    [SerializeField] private int health = 120;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("The UIManager is NULL.");
        }

        _uiManager.UpdateBrainHealth(health);
    }

    void dealDamage(float damage){
        health -= (int) damage;
        _uiManager.UpdateBrainHealth(health);
        if(health <= 0) SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
        
    }
    
}
