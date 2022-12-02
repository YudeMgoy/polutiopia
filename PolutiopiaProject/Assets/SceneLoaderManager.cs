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
    // int Levelsunlocked;

    // // public Button[] buttons;
    // [SerializeField]Button buttonVillage;
    // [SerializeField]Button buttonBazaar;

    // void Start()
    // {
    //     Levelsunlocked = PlayerPrefs.GetInt("Levelsunlocked");
    //     Debug.Log("Level: "+Levelsunlocked);

    //     // for(int i = 0; i < buttons.Length; i++)
    //     // {
    //     //     buttons[i].interactable = false;
    //     // }

    //     // for(int i = 0; i < Levelsunlocked; i++)
    //     // {
    //     //     buttons[i].interactable = true;
    //     // }
    //     if(Levelsunlocked == 2)
    //         buttonVillage.interactable = true;
    //     else if(Levelsunlocked == 1)
    //         buttonBazaar.interactable = true;
    //     // else if(Levelsunlocked == 0)
    //     //     buttons[0].interactable = true;

        
    // }
    // public void SetLevelPref()
    // {
    //     PlayerPrefs.SetInt("Levelunlocked",0);
    // }
    
}
