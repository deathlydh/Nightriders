using UnityEngine;
using YG;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;
    private int currentCoins = 0; // ���������� ��� �������� �������� ���������� �����

    [SerializeField] private Button FirstButtonReward;

    void Start()
    {
        CoinTexts = GetComponent<Text>();
        currentCoins = PlayerPrefs.GetInt("SavedPoints", 0); // �������� ����������� ���������� �����
        UpdateCoins(currentCoins); // ��������� ����� � ����������� �����
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
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
}
