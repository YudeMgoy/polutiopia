using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionPerTime : MonoBehaviour
{
    public bool running = true;
    public float PollutionCount;
    public float interval;

    private void Start()
    {
        InvokeRepeating("Polluting", interval, interval);
    }

    public void Polluting()
    {
        if (!running || LevelManager.Instance.GridManager.IsPlacingGridObject)
            return;
        LevelManager.Instance.CountingPollution(PollutionCount);
    }
}
