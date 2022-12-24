using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    int wave;
    int enemyValue = 5;


    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<Enemy>() == null)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        for(int i = 0; i <= enemyValue; i ++)
        {
            Instantiate(enemyPrefabs[wave - 1], spawnPoints[i]);
        }
    }
    IEnumerator Nextwave()
    {
        yield return new WaitForSeconds(10f);
        
    }
}
