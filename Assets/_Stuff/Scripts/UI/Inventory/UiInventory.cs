using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiInventory : MonoBehaviour
{
    [SerializeField] private Text goldText;
    [SerializeField] public InventoryList inventoryList;
    private int goldAmount = 15000;


    private void Start()
    {
        goldText.text = goldAmount.ToString();
    }

    public void IncreaseGold(int amount)
    {
        goldAmount += amount;
        goldText.text = goldAmount.ToString();
    }

    public void DecreaseGold(int amount)
    {
        goldAmount -= amount;
        goldText.text = goldAmount.ToString();
    }
}

