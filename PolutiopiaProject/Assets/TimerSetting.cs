using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    [SerializeField] Image timerImage;
    [SerializeField] GameObject settingPanel;
    // public Gradient gradient;
    public int duration;
    private int remainingDuration;
    public TimerFill timerFill;

    private void Start()
    {
        Being(duration);
        settingPanel.SetActive(false);
    }

    private void Being(int Seconds)
    {
        remainingDuration = Seconds;
        // timerImage.color = gradient.Evaluate(timerImage.fillAmount);
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
        print("Time is up!");
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
        settingPanel.SetActive(true);
    }
}
