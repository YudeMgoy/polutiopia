using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        woodText.text = "Wood  : " + wood.ToString();
        moneyText.text = "Money : " + money.ToString();
    }
}
