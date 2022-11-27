using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hypertonic.GridPlacement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Resources")]
    public double money;
    public double wood;
    public TMP_Text woodText;
    public TMP_Text moneyText;

    [Header("Managers")]
    public ShopManager ShopManager;
    public GridManager GridManager;

    [Header("UI")]
    public GameObject BuildingStatPanel;
    public Image ProgressImage;
    public StatPanelScript StatPanelScript;

    [Header("Runtime Variable")]
    public Building SelectedBuilding;

    [Header("Level Progress")]
    public float MaxPolution;
    public float CurrentPolution;
    public float[] TargetPolutions;
    float pollutionInPercent;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {        
        CountingPollution(0);
    }

    private void Update()
    {
        woodText.text = "Wood  : " + wood.ToString();
        moneyText.text = "Money : " + money.ToString();        
    }

    public void OpenBuildingStatPanel(Building _building)
    {
        if (GridManager.IsPlacingGridObject)
            return;
        SelectedBuilding = _building;
        BuildingStatPanel.SetActive(true);
        StatPanelScript.UpdateUI();
    }

    public void CountingPollution(float _pollution)
    {
        CurrentPolution -= _pollution;
        if (CurrentPolution <= 0f)
            CurrentPolution = 0f;
        pollutionInPercent = CurrentPolution / MaxPolution * 100;
        ProgressImage.fillAmount = pollutionInPercent * 0.01f;
    }

    public void GameOver(bool lose)
    {
        if (lose)
        {
            return;
        }
        else
        {
            if (CurrentPolution <= TargetPolutions[3])//Bintang 4
            {

            }
            if(CurrentPolution <= TargetPolutions[2])//Bintang 3
            {

            }
            if(CurrentPolution <= TargetPolutions[1])//Bintang 2
            {

            }
            if(CurrentPolution <= TargetPolutions[0])//Bintang 1
            {

            }
        }
    }
}
