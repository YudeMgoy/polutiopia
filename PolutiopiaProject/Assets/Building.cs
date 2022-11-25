using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public double moneyPrice;
    public double woodPrice;

    private void OnMouseDown()
    {
        LevelManager.Instance.OpenBuildingStatPanel(this);
    }
}
