using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public LevelManager LevelManager;

    [Header("Timer Setting")]
    public Image timerImage;
    public GameObject pausePanel;
    public int duration;
    private int remainingDuration;
    public TimerFill timerFill;

    private void Start()
    {
        Being(duration);
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
        LevelManager.GameOver(true);
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

    public void EndGame()
    {
        // Time.timeScale = 1;
        StopAllCoroutines();
        LevelManager.GameOver(true);

    }

}
