using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Hypertonic.GridPlacement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Resources")]
    public double money;
    public double wood;
    public TMP_Text woodText;
    public TMP_Text moneyText;

    [Header("Managers")]
    public ShopManager ShopManager;
    public GridManager GridManager;

    [Header("UI")]
    public GameObject BuildingStatPanel;

    [Header("Runtime Variable")]
    public Building SelectedBuilding;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        woodText.text = "Wood  : " + wood.ToString();
        moneyText.text = "Money : " + money.ToString();
    }

    public void OpenBuildingStatPanel(Building _building)
    {
        if (GridManager.IsPlacingGridObject)
            return;
        SelectedBuilding = _building;
        BuildingStatPanel.SetActive(true);
    }
}
