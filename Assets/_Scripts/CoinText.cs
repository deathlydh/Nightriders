using UnityEngine;
using YG;
using UnityEngine.UI;
using System;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    public int currentCoins = 0; // ���������� ��� �������� �������� ���������� �����

    [SerializeField] private Button FirstButtonReward;

    void Start()
    {
        CoinTexts = GetComponent<Text>();
        currentCoins = PlayerPrefs.GetInt("SavedPoints", 0); // �������� ����������� ���������� �����
        UpdateCoins(currentCoins); // ��������� ����� � ����������� �����
        YandexGame.FullscreenShow();
        FirstButtonReward.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });

        if(YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }
    }

    private void LoadSaveCloud()
    {
        CoinTexts.text = YandexGame.savesData.coins.ToString();
    }

    public void UpdateCoins(int coins)
    {
        CoinTexts.text = coins.ToString();
        MySave();
    }

    void Rewarded(int id)
    {
        if (id == 1)
        {
            AddMoney(1000);
        }
    }

    public void AddMoney(int coins)
    {
        currentCoins += coins; // ����������� ������� ���������� ����� �� �������� coins
        PlayerPrefs.SetInt("SavedPoints", currentCoins); // ��������� �������� ����� � PlayerPrefs
        UpdateCoins(currentCoins); // ��������� ����� � ����������� �����
    }

    void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.GetDataEvent += LoadSaveCloud;
        
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.GetDataEvent -= LoadSaveCloud;
        
    }
    public void MySave()
    {
        YandexGame.savesData.coins = currentCoins;
        YandexGame.SaveProgress();
    }


}
