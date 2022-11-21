using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Resources")]
    public double money;
    public double wood;

    [Header("Managers")]
    public ShopManager ShopManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
}
