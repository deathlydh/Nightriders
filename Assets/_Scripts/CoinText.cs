using UnityEngine;
using YG;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    private int currentCoins = 0; // переменная для хранения текущего количества монет

    [SerializeField] private Button FirstButtonReward;

    void Start()
    {
        CoinTexts = GetComponent<Text>();
        currentCoins = PlayerPrefs.GetInt("SavedPoints", 0); // Получаем сохраненное количество монет
        UpdateCoins(currentCoins); // Обновляем текст с количеством монет
        YandexGame.FullscreenShow();
        FirstButtonReward.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
    }

    public void UpdateCoins(int coins)
    {
        CoinTexts.text = coins.ToString();
    }

    void Rewarded(int id)
    {
        if (id == 1)
        {
            AddMoney(1000);
        }
    }

    private void AddMoney(int coins)
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
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
}
