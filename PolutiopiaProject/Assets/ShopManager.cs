using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Sell(int woodBonus = 0, int moneyBonus = 0)
    {
        LevelManager.Instance.CountingPollution(-LevelManager.Instance.SelectedBuilding.PollutionReduction);
        Building _building = LevelManager.Instance.SelectedBuilding;

        if (moneyBonus == 0)
            LevelManager.Instance.money += _building.MoneyPrice * .5;
        else
            LevelManager.Instance.money += moneyBonus;
        if(woodBonus == 0)
            LevelManager.Instance.wood += _building.WoodPrice*.5;
        else
            LevelManager.Instance.wood += woodBonus;

        Destroy(_building.gameObject);
        LevelManager.Instance.BuildingStatPanel.SetActive(false);
    }
}
