using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SoldierHealth : NetworkBehaviour
{
    [SerializeField] private int health = 50;
    private UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("The UIManager is NULL.");
        }

        _uiManager.UpdateSoldierHealth(health);
        _uiManager.UpdateBorders(health);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeHealth(int value)
    {
        health += value;

        if (health >= 109)
        {
            health = 120;
        }

        _uiManager.UpdateBorders(health);
        _uiManager.UpdateSoldierHealth(health);
    }
}
