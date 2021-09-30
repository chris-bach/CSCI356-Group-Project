using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _timerText;
    [SerializeField] private RectTransform _playerHealth;
    [SerializeField] private Image _brainHealth;
    [SerializeField] private Image _borderHealth;
    [SerializeField] private Sprite[] _bloodBorders;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "SCORE: " + 0;
        _timerText.text = "TIME LEFT: " + 300;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBorders(int currentHealth)
    {
        if(currentHealth > 90)
        {
            _borderHealth.sprite = _bloodBorders[3];
        }
        else if (currentHealth < 91 && currentHealth > 60)
        {
            _borderHealth.sprite = _bloodBorders[2];
        }
        else if (currentHealth < 61 && currentHealth > 30)
        {
            _borderHealth.sprite = _bloodBorders[1];
        }
        else if (currentHealth < 31 && currentHealth > 0)
        {
            _borderHealth.sprite = _bloodBorders[0];
        }
    }

    public void UpdateSoldierHealth(int currentHealth)
    {
        _playerHealth.sizeDelta = new Vector2(currentHealth, _playerHealth.sizeDelta.y);
    }
}
