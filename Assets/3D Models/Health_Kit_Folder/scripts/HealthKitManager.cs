using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitManager : MonoBehaviour
{
    [SerializeField] private GameObject _healthKitPrefab;
    [SerializeField] private GameObject _healthKitContainer;
    [SerializeField] private float _delay = 15.0f;

    private GameObject newKit1;
    private GameObject newKit2;
    private GameObject newKit3;
    private GameObject newKit4;
    private GameObject newKit5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 posToSpawn = new Vector3(0, 0, 0); // Default Position
            int value = Random.Range(1, 6);

            switch (value)
            {
                case 1:
                    posToSpawn = new Vector3(-20.5f, -4.45f, -29.5f); // Position 1 = (-20.5, -4.45, -29.5) 
                    if (newKit1 != null)
                    {
                        Destroy(newKit1);
                        //Debug.Log("1 destroyed");
                    }

                    newKit1 = (GameObject)Instantiate(_healthKitPrefab, posToSpawn, Quaternion.identity);
                    newKit1.transform.parent = _healthKitContainer.transform;
                    if (newKit1 != null)
                    {
                        //Debug.Log("1 created");
                    }

                    break;

                case 2:
                    posToSpawn = new Vector3(-21f, -4.45f, 29f); // Position 2 = (-21, -4.45, 29)
                    if (newKit2 != null)
                    {
                        Destroy(newKit2);
                        //Debug.Log("2 destroyed");
                    }

                    newKit2 = (GameObject)Instantiate(_healthKitPrefab, posToSpawn, Quaternion.identity);
                    newKit2.transform.parent = _healthKitContainer.transform;
                    if (newKit2 != null)
                    {
                        //Debug.Log("2 created");
                    }

                    break;

                case 3:
                    posToSpawn = new Vector3(21.7f, -4.45f, 8.5f); // Position 3 = (21.7, -4.45, 8.5)
                    if (newKit3 != null)
                    {
                        Destroy(newKit3);
                        //Debug.Log("3 destroyed");
                    }

                    newKit3 = (GameObject)Instantiate(_healthKitPrefab, posToSpawn, Quaternion.identity);
                    newKit3.transform.parent = _healthKitContainer.transform;
                    if (newKit3 != null)
                    {
                        //Debug.Log("3 created");
                    }

                    break;

                case 4:
                    posToSpawn = new Vector3(5f, -4.45f, -13f); // Position 4 = (5, -4.45, -13)
                    if (newKit4 != null)
                    {
                        Destroy(newKit4);
                        //Debug.Log("4 destroyed");
                    }

                    newKit4 = (GameObject)Instantiate(_healthKitPrefab, posToSpawn, Quaternion.identity);
                    newKit4.transform.parent = _healthKitContainer.transform;
                    if (newKit4 != null)
                    {
                        //Debug.Log("4 created");
                    }

                    break;

                case 5:
                    posToSpawn = new Vector3(21.36f, -4.3f, -28.37f); // Position 5 = (21.36, -4.3, -28.37)
                    if (newKit5 != null)
                    {
                        Destroy(newKit5);
                        //Debug.Log("5 destroyed");
                    }

                    newKit5 = (GameObject)Instantiate(_healthKitPrefab, posToSpawn, Quaternion.identity);
                    newKit5.transform.parent = _healthKitContainer.transform;
                    if (newKit5 != null)
                    {
                        //Debug.Log("5 created");
                    }

                    break;
            }
            yield return new WaitForSeconds(_delay);
        }

    }
}
