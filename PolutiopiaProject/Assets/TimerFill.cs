using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TimerFill : MonoBehaviour
{
    public Image image;

    public void UpdateFill(float fillAmount)
    {
        image.DOFillAmount(fillAmount, 0.5f);
        if (fillAmount > 0.6)
        {
            image.DOColor(Color.green, 0.5f);
        }
        else if (fillAmount > 0.3)
        {
            image.DOColor(Color.yellow, 0.5f);
        }
        else
        {
            image.DOColor(Color.red, 0.5f);
        }
    }
}
