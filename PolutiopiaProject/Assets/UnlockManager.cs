using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockManager : MonoBehaviour
{
    
    //unlock
    int Levelsunlocked;

    // public Button[] buttons;
    [SerializeField]Button buttonVillage;
    [SerializeField]Button buttonBazaar;
    void Start()
    {
        Levelsunlocked = PlayerPrefs.GetInt("Levelunlocked");
        Debug.Log("Level: "+Levelsunlocked);

        // for(int i = 0; i < buttons.Length; i++)
        // {
        //     buttons[i].interactable = false;
        // }

        // for(int i = 0; i < Levelsunlocked; i++)
        // {
        //     buttons[i].interactable = true;
        // }
        // else if(Levelsunlocked == 0)
        //     buttons[0].interactable = true;

        
    }
    void Update()
    {
        if(Levelsunlocked == 2)
        {
            buttonBazaar.interactable = true;
            buttonVillage.interactable = true;
        }
        else if(Levelsunlocked == 1)
        {
            buttonVillage.interactable = true;
            Debug.Log("Village Status : "+ buttonVillage.interactable);
        }
    }
    public void SetLevelPref()
    {
        if(Levelsunlocked>0)
            PlayerPrefs.SetInt("Levelunlocked",0);
    }
    
}
