using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public double MoneyPrice;
    public double WoodPrice;
    public float PollutionReduction;

    private void OnMouseDown()
    {
        LevelManager.Instance.OpenBuildingStatPanel(this);
    }
}
