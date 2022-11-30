using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatPanelScript : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text moneyText;
    public TMP_Text sellMoneyText;
    public TMP_Text woodText;
    public TMP_Text sellWoodText;
    public TMP_Text descriptionText;
    public Image buildingImage;
    

    public void UpdateUI()
    {
        Building _building = LevelManager.Instance.SelectedBuilding;
        nameText.text = _building.name;
        moneyText.text = "Buy Price (Money) : "+_building.MoneyPrice.ToString();
        sellMoneyText.text = "Sell Price (Money) : "+(_building.moneySellBonus).ToString();
        woodText.text = "Buy Price (Wood) : "+_building.WoodPrice.ToString();
        sellWoodText.text = "Sell Price (Wood) : "+(_building.woodSellBonus).ToString();
        descriptionText.text = _building.description;
        buildingImage.sprite = _building.UIImage;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
