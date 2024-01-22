using UnityEngine;
using YG;
using UnityEngine.UI;
using System;

public class CoinText : MonoBehaviour
{
    Text coinTexts;
    public int currentCoins = 0; // переменная для хранения текущего количества монет

    [SerializeField] private Button FirstButtonReward;

    void Start()
    {

        coinTexts = GetComponentInChildren<Text>();

   
        currentCoins = PlayerPrefs.GetInt("SavedPoints", 0);
        UpdateCoins(currentCoins);
        YandexGame.FullscreenShow();
        FirstButtonReward.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
        

        if (YandexGame.SDKEnabled == true)
        {
         //   LoadSaveCloud();
        }
    }

    //public void LoadSaveCloud()
    //{
      //  if (coinTexts != null)
     //   {
     //       coinTexts.text = YandexGame.savesData.coins.ToString();
      //  }
     //   else
      //  {
       //     Debug.LogError("CoinTexts is null. Unable to update text.");
      //  }
   // }

    public void UpdateCoins(int coins)
    {
        if (coinTexts != null)
        {
            coinTexts.text = coins.ToString();
            MySave();
        }
        else
        {
            Debug.LogError("CoinTexts is null. Unable to update text.");
        }
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
        currentCoins += coins; // увеличиваем текущее количество монет на значение coins
        PlayerPrefs.SetInt("SavedPoints", currentCoins); // Сохраняем значение монет в PlayerPrefs
        UpdateCoins(currentCoins); // Обновляем текст с количеством монет
    }

    void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
      //  YandexGame.GetDataEvent += LoadSaveCloud;

    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
      //  YandexGame.GetDataEvent -= LoadSaveCloud;

    }
    public void MySave()
    {
        YandexGame.savesData.coins = currentCoins;
        YandexGame.SaveProgress();
    }
    


}