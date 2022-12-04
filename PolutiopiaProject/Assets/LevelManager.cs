using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hypertonic.GridPlacement;
using UnityEngine.UI;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Resources")]
    public double money;
    public double wood;
    public TMP_Text woodText;
    public TMP_Text moneyText;

    [Header("WoodCenter")]
    public double woodCost = 1;
    public double moneyCostperWood = 100;
    public int countIncrmant = 0;
    int countTred = 0;


    [Header("Managers")]
    public ShopManager ShopManager;
    public GridManager GridManager;
    public TimerManager TimerManager;

    [Header("UI")]
    public GameObject BuildingStatPanel;
    public Image ProgressImage;
    public StatPanelScript StatPanelScript;
    public GameObject WoodCenterPanel;
    public TMP_Text ExchangeNum;

    [Header("Runtime Variable")]
    public Building SelectedBuilding;

    [Header("Level Progress")]
    public float MaxPolution;
    public float CurrentPolution;
    public float[] TargetPolutions;
    float pollutionInPercent;

    [Header("Audio")]
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip sfxClick;
    [SerializeField] AudioClip sfxTrade;
    [SerializeField] AudioClip sfxTradeFail;
    [SerializeField] AudioClip sfxEndGame;
    private bool winStat;

    [Header("End Game")]
    public Image[] endGameStars;
    public Button endButton;
    public GameObject endGamePanel;
    public TMP_Text endText;


    [Header("Camera UI")]
    public CameraController cameraPivot;
    public GameObject Objectselector;


    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {

        CountingPollution(0);
        endButton.gameObject.SetActive(false);
        winStat = false;


    }

    private void Update()
    {

        if (CurrentPolution > MaxPolution)
            CurrentPolution = MaxPolution;
        Debug.Log("current pollution number: " + CurrentPolution);
        woodText.text = "Wood  : \n" + wood.ToString();
        moneyText.text = "Money : \n" + money.ToString();

        if (endGamePanel.activeSelf && winStat == false)
        {
            //play audio win
            sfx.PlayOneShot(sfxEndGame, sfx.volume);
            winStat = true;
        }

        if (Objectselector.gameObject.activeSelf)
        {
            cameraPivot.enabled = false;
        }
        else
        {
            cameraPivot.enabled = true;
        }
    }

    public void OpenBuildingStatPanel(Building _building)
    {
        if (GridManager.IsPlacingGridObject)
            return;
        SelectedBuilding = _building;
        BuildingStatPanel.SetActive(true);
        //play audio click
        sfx.PlayOneShot(sfxClick, sfx.volume);
        //========
        StatPanelScript.UpdateUI();
        if (SelectedBuilding.tag == "WoodCenter")
            WoodCenterPanel.SetActive(true);
        else
            WoodCenterPanel.SetActive(false);
    }

    public void CountingPollution(float _pollution)
    {

        CurrentPolution -= _pollution;
        if (CurrentPolution <= 0f)
            CurrentPolution = 0f;
        pollutionInPercent = CurrentPolution / MaxPolution * 100;
        ProgressImage.fillAmount = pollutionInPercent * 0.01f;

        if (pollutionInPercent <= TargetPolutions[3])
            GameOver(true);

        if (pollutionInPercent <= TargetPolutions[2])
        {
            if (endButton.gameObject.activeSelf == false)
            {
                endButton.gameObject.SetActive(true);
            }
        }
    }

    public void GameOver(bool lose)
    {
        if (lose)
        {
            if (CurrentPolution <= TargetPolutions[3])//Bintang 4
            {
                Debug.Log("Bintang 4");
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                endGameStars[0].gameObject.SetActive(true);
                endGameStars[1].gameObject.SetActive(true);
                endGameStars[2].gameObject.SetActive(true);
                endGameStars[3].gameObject.SetActive(true);
            }
            else if (CurrentPolution <= TargetPolutions[2])//Bintang 3
            {
                Debug.Log("Bintang 3");
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                endGameStars[0].gameObject.SetActive(true);
                endGameStars[1].gameObject.SetActive(true);
                endGameStars[2].gameObject.SetActive(true);
            }
            else if (CurrentPolution <= TargetPolutions[1])//Bintang 2
            {
                Debug.Log("Bintang 2");
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                endGameStars[0].gameObject.SetActive(true);
                endGameStars[1].gameObject.SetActive(true);
            }
            else if (CurrentPolution <= TargetPolutions[0])//Bintang 1
            {
                Debug.Log("Bintang 1");
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                endGameStars[0].gameObject.SetActive(true);
            }
            else
            {
                endGamePanel.SetActive(true);
                endText.text = "You Lose";
            }
        }
        else
        {


        }
    }

    public void WoodExchange()
    {
        if (wood < woodCost)
        {
            //play audio sfx cant trade
            sfx.PlayOneShot(sfxTradeFail, sfx.volume);
            return;
        }
        money += moneyCostperWood;
        wood -= woodCost;
        //play audio trade
        sfx.PlayOneShot(sfxTrade, sfx.volume);
        IncreaseWoodCost();
        UpdateExchangeNum();
    }

    public void IncreaseWoodCost()
    {
        if (countTred >= countIncrmant)
        {
            woodCost *= 2;
            countTred = 0;
        }

        countTred++;
    }
    public void UpdateExchangeNum()
    {
        ExchangeNum.text = woodCost + "Wood = " + moneyCostperWood + "$";
    }

    public void CheckCost(BuildingCost cost)
    {
        cost.button.interactable = true;

        if (money < cost.moneyPrice || wood < cost.woodPrice)
        {
            cost.button.interactable = false;
        }
    }
}
