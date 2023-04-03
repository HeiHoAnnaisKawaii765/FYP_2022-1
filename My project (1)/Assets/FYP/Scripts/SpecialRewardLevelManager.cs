using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SpecialRewardLevelManager : MonoBehaviour
{
    int currentLV;
    int currentXP;
    public Slider sliderXP;

    public Collider ballCollider;
    

    
   
    // Start is called before the first frame update
    void Start()
    {
        currentXP = PlayerPrefs.GetInt("EXP");
        currentLV = PlayerPrefs.GetInt("LV");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EndLevel()
    {
        PlayerPrefs.SetInt("EXP", currentXP);
        PlayerPrefs.SetInt("LV", currentLV);
        SceneManager.LoadScene("Level Select");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == ballCollider)
        {
            EndLevel();
        }
        if (other.tag == "Present")
        {
            currentXP += 30000;
        }
    }

    public void AddExp(int n)
    {
        currentXP += n;
    }
    
}
