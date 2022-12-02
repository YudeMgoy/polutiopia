using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoaderManager : MonoBehaviour
{
    //load
    public static void Load(string sceneName)
    {
        SceneLoader.Load(sceneName);
    }

    //progress load
    public static void ProgressLoad(string sceneName)
    {
        SceneLoader.ProgressLoad(sceneName);
    }
    //reload level
    public static void ReloadLevel()
    {
      SceneLoader.ReloadLevel();  
    }

    //loadnextlevel
    public static void LoadNextLevel()
    {
        SceneLoader.LoadNextLevel();
    }

    //quit
    public static void Quit()
    {
        Application.Quit();
    }

    //unlock
    int levelsunlocked;

    public Button[] buttons;

    void Start()
    {
        Levelsunlocked = PlayerPrefs.GetInt("Levelsunlocked",1);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i < Levelsunlocked; i++)
        {
            buttons[i].interactable = true;
        }

        
    }
    
}
