using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hypertonic.GridPlacement;

public class ShopManager : MonoBehaviour
{
    public bool Buy(Building _building)
    {
        if(_building.MoneyPrice <= LevelManager.Instance.money && _building.WoodPrice <= LevelManager.Instance.wood)
        {
            LevelManager.Instance.CountingPollution(LevelManager.Instance.SelectedBuilding.PollutionReduction);
            LevelManager.Instance.money -= _building.MoneyPrice;
            LevelManager.Instance.wood -= _building.WoodPrice;
            return true;
        }
        return false;
    }

    public void Sell()
    {
        LevelManager.Instance.CountingPollution(-LevelManager.Instance.SelectedBuilding.PollutionReduction);
        Building _building = LevelManager.Instance.SelectedBuilding;

        LevelManager.Instance.money += _building.moneySellBonus;
        LevelManager.Instance.wood += _building.woodSellBonus;        

        //Destroy(_building.gameObject);
        GridManagerAccessor.GridManager.DeleteObject(_building.gameObject);
        LevelManager.Instance.BuildingStatPanel.SetActive(false);
    }
}
