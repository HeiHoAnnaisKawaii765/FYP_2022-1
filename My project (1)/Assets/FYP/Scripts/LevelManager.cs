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
    public GameObject LeftUP, LeftDown, RightUP, RightDown;
    public Transform WeaponSpawnLeftUP, WeaponSpawnLeftDown, WeaponSpawnRightUP, WeaponSpawnRightDown;
    public GameObject bombLeftUP, bombLeftDown, bombRightUP, bombRightDown;
    // Start is called before the first frame update
    void Start()
    {
        LeftDown.SetActive(false);
        RightUP.SetActive(false);
        RightDown.SetActive(false);
        objectslection = 0;
        wave = 1;
        SpawnEnemy();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (FindObjectOfType<Enemy>() == null)
        {
            SpawnEnemy();
        }
        if(Input.GetMouseButtonDown(0))
        {
            DeployObject();
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

    public void DeployObject()
    {
        //Instantiate(deplyableObjects[objectslection],worldPosition,new Quaternion(0,0,0,0));
        Instantiate(deplyableObjects[objectslection], WeaponSpawnLeftUP);



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
    public void LeftUP_On()
    {
        LeftUP.SetActive(true);
        LeftDown.SetActive(false);
        RightUP.SetActive(false);
        RightDown.SetActive(false);

    }
    public void LeftDown_ON()
    {
        LeftUP.SetActive(false);
        LeftDown.SetActive(true);
        RightUP.SetActive(false);
        RightDown.SetActive(false);

    }
    public void RightUP_ON()
    {
        LeftUP.SetActive(false);
        LeftDown.SetActive(false);
        RightUP.SetActive(true);
        RightDown.SetActive(false);

    }
    public void RightDown_ON()
    {
        LeftUP.SetActive(false);
        LeftDown.SetActive(false);
        RightUP.SetActive(false);
        RightDown.SetActive(true);

    }

    public void SpawnBombLeftUP()
    {
        Instantiate(bombLeftUP, WeaponSpawnLeftUP);
    }

    public void SpawnBombLeftDown()
    {
        Instantiate(bombLeftDown, WeaponSpawnLeftDown);
    }
    public void SpawnBombRightUP()
    {
        Instantiate(bombRightUP, WeaponSpawnRightUP);
    }
    public void SpawnBombRightDown()
    {
        Instantiate(bombRightDown, WeaponSpawnRightDown);
    }
}
