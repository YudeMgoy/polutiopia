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
    public TimerManager TimerManager;

    [Header("UI")]
    public GameObject BuildingStatPanel;
    public Image ProgressImage;
    public StatPanelScript StatPanelScript;
    public GameObject endGamePanel;
    public TMP_Text endText;
    public TMP_Text endScoreText;
    public Button endButton;

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
        endButton.gameObject.SetActive(false);
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

        if (pollutionInPercent <= TargetPolutions[0])
        {
            if (endButton.gameObject.activeSelf == false)
            {
                endButton.gameObject.SetActive(true);
                // GameOver()
            }

            // endButton.gameObject.SetActive(true);
            // GameOver(true);

        }
    }

    public void GameOver(bool lose)
    {
        if (lose)
        {
            TimerManager.OnEnd();
            if (CurrentPolution <= TargetPolutions[3])//Bintang 4
            {
                endGamePanel.SetActive(true);
                Debug.Log("Bintang 4");
                endText.text = "You Win";
                var score = TargetPolutions[3] - CurrentPolution;
                endScoreText.text = "Score : " + score.ToString();
            }
            else if (CurrentPolution <= TargetPolutions[2])//Bintang 3
            {
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                var score = TargetPolutions[2].ToString();
                endScoreText.text = $"Score : {score}";
                Debug.Log("Bintang 3");
            }
            else if (CurrentPolution <= TargetPolutions[1])//Bintang 2
            {
                Debug.Log("Bintang 2");
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                var score = TargetPolutions[1].ToString();
                endScoreText.text = $"Score : {score}";
            }
            else if (CurrentPolution <= TargetPolutions[0])//Bintang 1
            {
                Debug.Log("Bintang 1");
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                var score = TargetPolutions[0].ToString();
                endScoreText.text = $"Score : {score}";
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
}
