using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    void Start()
    {
    	//for(int x = 0;x < 11;x++) SpawnNewEnemy();
        
    }

    void OnEnable(){
    	//EnemyAI.OnEnemyKilled += SpawnNewEnemy;
    }
    // Update is called once per frame
    void SpawnNewEnemy(){
    	int randSpawn = Mathf.RoundToInt(Random.Range(0f,m_SpawnPoints.Length-1));
        Instantiate(m_EnemyPrefab,m_SpawnPoints[randSpawn].transform.position,Quaternion.identity);
    }
}
