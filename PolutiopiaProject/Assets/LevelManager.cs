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

    [Header("Timer Setting")]
    public Image timerImage;
    public GameObject pausePanel;
    public int duration;
    private int remainingDuration;
    public TimerFill timerFill;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CountingPollution(0);
        Being(duration);
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

    private void Being(int Seconds)
    {
        remainingDuration = Seconds;
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            timerFill.UpdateFill((float)remainingDuration / duration);
            timerImage.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        GameOver(true);
        print("times Up");
    }

    public void PauseGame()
    {
        // Time.timeScale = 0;
        StopAllCoroutines();
    }

    public void ResumeGame()
    {
        // Time.timeScale = 1;
        StartCoroutine(UpdateTimer());
        pausePanel.SetActive(true);
    }

    public void GameOver(bool lose)
    {
        if (lose)
        {
            if (CurrentPolution <= TargetPolutions[3])//Bintang 4
            {
                endGamePanel.SetActive(true);
                Debug.Log("Bintang 4");
                endText.text = "You Win";
                var score = TargetPolutions[3] - CurrentPolution;
                endScoreText.text = "Score : " + score.ToString();
                endButton.gameObject.SetActive(true);
            }
            else if (CurrentPolution <= TargetPolutions[2])//Bintang 3
            {
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                var score = TargetPolutions[2].ToString();
                endScoreText.text = $"Score : {score}";
                endButton.gameObject.SetActive(true);
            }
            else if (CurrentPolution <= TargetPolutions[1])//Bintang 2
            {
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                var score = TargetPolutions[1].ToString();
                endScoreText.text = $"Score : {score}";
                endButton.gameObject.SetActive(true);
            }
            else if (CurrentPolution <= TargetPolutions[0])//Bintang 1
            {
                endGamePanel.SetActive(true);
                endText.text = "You Win";
                var score = TargetPolutions[0].ToString();
                endScoreText.text = $"Score : {score}";
                endButton.gameObject.SetActive(true);
            }
            else
            {
                endGamePanel.SetActive(true);
                endText.text = "You Lose";
                endButton.gameObject.SetActive(false);

            }
        }
    }
}
