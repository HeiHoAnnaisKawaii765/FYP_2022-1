using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelManager : MonoBehaviour
{
    public Button Start;
    public string SceneName;
    string bossLevelTicket = PlayerPrefs.GetString("L9");
public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void OnClickSceneChange(string loadSceneName)
    {
        //int Sceneindex = SceneManager.GetActiveScene().buildIndex;
        //if (Sceneindex != SceneManager.sceneCount)
        {
            if (loadSceneName == "Level10(Final boss)")
            {
                if(bossLevelTicket == "L9")
                {
                    SceneManager.LoadScene(loadSceneName);
                }
                else
                {
                    //remind player finish L9 first
                }
            }
            else
            {
                SceneManager.LoadScene(loadSceneName);
            }
            
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

