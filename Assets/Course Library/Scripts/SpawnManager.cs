using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float startDelay = 1;
    public float repeatRate = 2;
    public GameObject[] itemPrefabs;
    private int itemIndex;
    public float spawnRangeX = 60;
    public float spawnRangeZ = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCollectable", startDelay, repeatRate);
    }

    // Update is called once per frame
    void SpawnCollectable()
    {
        Vector3 spawnPos = new Vector3(Random.Range(0, spawnRangeX), 2, Random.Range(0, spawnRangeZ));
        int itemIndex = Random.Range(0, itemPrefabs.Length);
        Debug.Log("Food eaten!");
        Instantiate(itemPrefabs[itemIndex], spawnPos, itemPrefabs[itemIndex].transform.rotation);
    }
}
