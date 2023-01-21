using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelManager : MonoBehaviour
{
    public Button Start;
    public string SceneName;

public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void OnClickSceneChange()
    {
        //int Sceneindex = SceneManager.GetActiveScene().buildIndex;
        //if (Sceneindex != SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

