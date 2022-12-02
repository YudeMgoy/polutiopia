using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    int levelunlock;
    public void Pass()
    {
        Debug.Log(PlayerPrefs.GetInt("Levelunlocked"));
        levelunlock = PlayerPrefs.GetInt("Levelunlocked");
        int currentLevel =  SceneManager.GetActiveScene().buildIndex;

        if(currentLevel == levelunlock)
        {
            currentLevel++;
            PlayerPrefs.SetInt("Levelunlocked",currentLevel);
            Debug.Log("Level Script: "+currentLevel);
        }
    }
}
