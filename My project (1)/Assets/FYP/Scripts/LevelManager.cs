using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    int wave;
    int enemyValue = 5;
    public GameObject[] deplyableObjects;
    int objectslection;
    Vector3 worldPosition;
    public GameObject cam1, cam2, cam3, cam4;
    public Transform superWeaponSpawn;
    // Start is called before the first frame update
    void Start()
    {
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        objectslection = 0;
        wave = 1;
        SpawnEnemy();
        superWeaponSpawn = cam1.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        for(int i = 0; i <= enemyValue; i ++)
        {
            Instantiate(enemyPrefabs[wave - 1], spawnPoints[i]);
        }
    }
    

    public void DeployObject()
    {
        //Instantiate(deplyableObjects[objectslection],worldPosition,new Quaternion(0,0,0,0));
        Instantiate(deplyableObjects[objectslection], superWeaponSpawn);



    }
    public void selectNone ()
    {
        objectslection = 0;
    }
    public void O1()
    {
        objectslection = 1;
    }
    public void O2()
    {
        objectslection = 2;
    }
    public void O3()
    {
        objectslection = 3;
    }
    public void O4()
    {
        objectslection = 4;
    }
    public void O5()
    {
        objectslection = 5;
    }
    public void Cam1On()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        superWeaponSpawn = cam1.transform;

    }
    public void Cam2On()
    {
        cam1.SetActive(false);
        cam1.SetActive(true);
        cam3.SetActive(false);
        cam4.SetActive(false);
        superWeaponSpawn = cam2.transform;

    }
    public void Cam3On()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);
        cam4.SetActive(false);
        superWeaponSpawn = cam3.transform;
    }
    public void Cam4On()
    {
        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(true);
        superWeaponSpawn = cam4.transform;

    }
}
