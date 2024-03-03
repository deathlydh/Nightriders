using UnityEngine;
using YG;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class CoinText : MonoBehaviour
{
    public Text coinText;  // <-- Добавлено новое публичное поле

    public int currentCoins = 0;
    [SerializeField] private Button FirstButtonReward;

    private void Start()
    {
        if (coinText == null)
        {
            Debug.LogError("CoinText: Text component not assigned in the inspector!");
            return;
        }

        currentCoins = PlayerPrefs.GetInt("SavedPoints", 0);
        UpdateCoins(currentCoins);
        YandexGame.FullscreenShow();
        FirstButtonReward.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });

        if (YandexGame.SDKEnabled)
        {
            LoadSaveCloud();
        }
    }
    public void LoadSaveCloud()
    {
        if (coinText != null)
        {
            coinText.text = YandexGame.savesData.coins.ToString(); 
        }
        else
        {
            Debug.LogError("CoinText component not found in the same GameObject or its children!");
        }
    }

    public void UpdateCoins(int coins)
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
            MySave();
        }
        else
        {
            Debug.LogError("CoinText component not found in the same GameObject or its children!");
        }
    }

    private void Rewarded(int id)
    {
        if (id == 1)
        {
            AddMoney(1000);
        }
    }

    public void AddMoney(int coins)
    {
        currentCoins += coins;
        PlayerPrefs.SetInt("SavedPoints", currentCoins);
        UpdateCoins(currentCoins);
    }

    private void ExampleOpenRewardAd(int id)
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

    private void MySave()
    {
        if (YandexGame.savesData != null)
        {
            YandexGame.savesData.coins = currentCoins;
            YandexGame.SaveProgress();
        }
        else
        {
            Debug.LogError("YandexGame.savesData is null. Unable to save progress.");
        }
    }
}
