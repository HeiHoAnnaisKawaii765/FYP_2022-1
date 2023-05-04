using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject cam1, cam2, cam3, cam4, WLT, timeTXT;
    public Transform superWeaponSpawn;
    [SerializeField]
    TMP_Text WinLoseText,timeText;
    [SerializeField]
    bool bossLevel,tutorial;
    [SerializeField]
    float timeLimit;
    
    string[] sceneName = { "Special Reward Scene Type 2", "Special Reward Scene Type 3", "Special Reward Scene" };

    // Start is called before the first frame update
    
    void Start()
    {
        if(timeTXT!=null)
        {
            timeTXT.SetActive(false);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
        //superWeaponSpawn = cam1.transform;
        if (FindObjectOfType<Enemy>()== null && FindObjectOfType<BossScript>() == null)
        {
           if(tutorial)
            {
                GameObject enemy = Instantiate(enemyPrefabs[0], spawnPoints[Random.Range( 0, spawnPoints.Length)]);
            }
           else
            {
                WinLoseText.text = "You Win";
                StartCoroutine("WinLevel");
            }
            
        }
        else if(FindObjectOfType<MainCharacter>()==null)
        {
            WinLoseText.text = "You lose";
            StartCoroutine("LoseLevel");
        }
        else
        {
            WinLoseText.text = "Help the wizard to win the fight!";
            
        }
        if(bossLevel)
        {
            timeTXT.SetActive(true);
            timeLimit -= Time.deltaTime;
            timeText.text = "Time" + timeLimit.ToString();
            if (timeLimit <=0)
            {
                WinLoseText.text = "You lose";
                StartCoroutine("LoseLevel");
            }
        }
    }



    public void DeployObject()
    {
        //Instantiate(deplyableObjects[objectslection],worldPosition,new Quaternion(0,0,0,0));
        GameObject spawnBomb = Instantiate(deplyableObjects[objectslection], WeaponSpawnLeftUP);



    }
    #region BTN
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

        cam1.SetActive(true);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(false);
        superWeaponSpawn = cam1.transform;

        LeftUP.SetActive(true);
        LeftDown.SetActive(false);
        RightUP.SetActive(false);
        RightDown.SetActive(false);


    }
    public void LeftDown_ON()
    {

        cam1.SetActive(false);
        cam1.SetActive(true);
        cam3.SetActive(false);
        cam4.SetActive(false);
        superWeaponSpawn = cam2.transform;

        


    }
    public void RightUP_ON()
    {

        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(true);
        cam4.SetActive(false);
        superWeaponSpawn = cam3.transform;



    }
    public void RightDown_ON()
    {

        cam1.SetActive(false);
        cam2.SetActive(false);
        cam3.SetActive(false);
        cam4.SetActive(true);
        superWeaponSpawn = cam4.transform;


    }

    public void SpawnBombLeftUP()
    {
        DeployObject();
    }

    public void SpawnBombLeftDown()
    {
        DeployObject();
    }
    public void SpawnBombRightUP()
    {
        DeployObject();
    }
    public void SpawnBombRightDown()
    {
        DeployObject();
    }
    #endregion
    IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName[Random.Range(0, sceneName.Length)]);
    }

    IEnumerator LoseLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Gameover");
    }




}
