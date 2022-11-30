using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPerTime : MonoBehaviour
{
    public bool running = true;
    public float MoneyCount;
    public float interval;

    private void Start()
    {
        InvokeRepeating("Increasing", interval, interval);
    }

    public void Increasing()
    {
        if (!running || LevelManager.Instance.GridManager.IsPlacingGridObject)
            return;
        LevelManager.Instance.money += MoneyCount;
    }
}
