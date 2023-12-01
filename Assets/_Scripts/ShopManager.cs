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

        int coinsAmount = coinText.currentCoins; // ѕолучение текущего количества монет из CoinText
        coinText.UpdateCoins(coinsAmount); // ѕередача текущего количества монет в метод UpdateCoins() класса CoinText
    }
}

