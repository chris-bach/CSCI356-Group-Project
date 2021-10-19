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
    public int enemiesToSpawn = 10;
    public int enemySpawnIncrement = 5;
    public float spawnTime = 15;

    void Awake(){
    	UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene aScene, LoadSceneMode aMode){
        if(aScene.name == "Warehouse - Copy" && this != null) StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies(){
        //print("Spawning");
        try{
            for(int x = 0;x < enemiesToSpawn;x++){
                int randSpawn = Mathf.RoundToInt(Random.Range(0f,m_SpawnPoints.Length-1));
                enemy = (GameObject) Instantiate(m_EnemyPrefab,m_SpawnPoints[randSpawn].transform.position,Quaternion.identity);
                enemy.transform.parent = _enemyContainer.transform;
            }   
            enemiesToSpawn += enemySpawnIncrement;
        }
        catch{
            //We should probably fix this issue rather than just catching it, lol 
            print("Error caught");
        }
        yield return new WaitForSeconds(spawnTime);
        spawnTime -= 2;
        StartCoroutine(SpawnEnemies());
        
    }
}
