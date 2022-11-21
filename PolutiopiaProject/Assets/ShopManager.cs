using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public bool Buy(Building _building)
    {
        if(_building.moneyPrice <= LevelManager.Instance.money && _building.woodPrice <= LevelManager.Instance.wood)
        {
            return true;
        }
        return false;
    }
}
