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
    public GameObject cam1, cam2, cam3, cam4, WLT, timeTXT,remindTXT;
    public Transform superWeaponSpawn;
    [SerializeField]
    TMP_Text WinLoseText,timeText;
    [SerializeField]
    bool bossLevel,tutorial,L9;
    [SerializeField]
    float timeLimit;
    [SerializeField]
    string[] endgameDialog;
    string[] sceneName = { "Special Reward Scene Type 2", "Special Reward Scene Type 3", "Special Reward Scene" };
    int n = 0;

    // Start is called before the first frame update

    void Start()
    {
        if(timeTXT!=null)
        {
            timeTXT.SetActive(false);
            
        }
        if(bossLevel)
        {
            WLT.SetActive(false);
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
           else if(bossLevel)
            {
                remindTXT.SetActive(false);
                WLT.SetActive(true);
                WinLoseText.text = endgameDialog[n];
                StartCoroutine("BossWinLevel");
                
            }
           else
            {
                WinLoseText.text = "You Win";
                StartCoroutine("WinLevel");
                if(L9)
                {
                    PlayerPrefs.SetString("L9", "L9");
                }
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
                remindTXT.SetActive(false);
                WLT.SetActive(true);
                WinLoseText.text = "The great time war begins,is over";
                StartCoroutine("LoseLevel");
            }
        }
    }



    public void DeployObject()
    {
        //Instantiate(deplyableObjects[objectslection],worldPosition,new Quaternion(0,0,0,0));
        GameObject spawnBomb = Instantiate(deplyableObjects[0], WeaponSpawnLeftUP);



    }
    
  
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

    IEnumerator BossWinLevel()
    {
        
        
        for (int i = 0; i <= endgameDialog.Length; i++)
        {
            n = i;
            
            yield return new WaitForSeconds(2);
            
        }
        SceneManager.LoadScene("Main Menu");
    }


}
