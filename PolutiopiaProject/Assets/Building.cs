using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int BuildingID;
    public int BuildingCountLimit;
    public string name;
    public double MoneyPrice;
    public int moneySellBonus;
    public double WoodPrice;
    public int woodSellBonus;
    public float PollutionReduction;

    public Sprite UIImage; 
    [TextArea]
    public string description;
    
    
    private void OnMouseDown()
    {
        LevelManager.Instance.OpenBuildingStatPanel(this);
    }
}
