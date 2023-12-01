using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private Text MoneyText;
    private int currentMoney;


    private void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        currentMoney = PlayerPrefs.GetInt("Money", 10000);
        MoneyText.text = currentMoney.ToString();
    }




}