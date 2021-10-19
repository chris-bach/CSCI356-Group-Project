using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _timerText;
    [SerializeField] private RectTransform _playerHealth;
    [SerializeField] private RectTransform _brainHealth;
    [SerializeField] private Image _borderHealth;
    [SerializeField] private Sprite[] _bloodBorders;
    public static int seconds = -1;
    public static int kills = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "TOTAL SCORE: " + 0;
        _timerText.text = "TIME SURVIVED: " + 0;
    }

    void Awake(){
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene aScene, LoadSceneMode aMode){
        if(aScene.name == "Warehouse - Copy" && this != null) {
            seconds = -1;
            kills = 0;
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer(){
        seconds++;
        _timerText.text = "TIME SURVIVED: " + seconds;
        yield return new WaitForSeconds(1F);
        StartCoroutine(Timer());
    }
    public void updateKillCount(){
        kills++;
        _scoreText.text = "TOTAL SCORE: " + kills;
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

    public void UpdateBrainHealth(int currentHealth)
    {
        _brainHealth.sizeDelta = new Vector2(currentHealth, _brainHealth.sizeDelta.y);
    }
}
