using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    private GameObject enemy;
    public int initalEnemies = 20;

    void Awake(){
    	UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene aScene, LoadSceneMode aMode){
    	for(int x = 0;x < initalEnemies;x++) SpawnNewEnemy();
   
    }

  
    void SpawnNewEnemy(){
        int randSpawn = Mathf.RoundToInt(Random.Range(0f,m_SpawnPoints.Length-1));
        enemy = (GameObject) Instantiate(m_EnemyPrefab,m_SpawnPoints[randSpawn].transform.position,Quaternion.identity);
        enemy.transform.parent = _enemyContainer.transform;
    }
}
