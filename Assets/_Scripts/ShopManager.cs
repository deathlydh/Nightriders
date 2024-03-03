using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ShopButton[] AllButton;
    [SerializeField] private CoinText coinText;

    private void Start()
    {
        AllButton = GetComponentsInChildren<ShopButton>();

        for (int i = 0; i < AllButton.Length; i++)
        {
            AllButton[i].SetManager(this);
        }
    }

    public void UpdateInfoButton()
    {
        for (int i = 0; i < AllButton.Length; i++)
        {
            AllButton[i].UpdateInfo();
        }

        if (coinText != null)
        {
            int coinsAmount = coinText.currentCoins;
            coinText.UpdateCoins(coinsAmount);
        }
        else
        {
            Debug.LogError("CoinText в ShopManager не был назначен или отсутствует.");
        }
    }
}

