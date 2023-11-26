using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text CoinTexts;

    void Start()
    {
        CoinTexts = GetComponent<Text>();
        UpdateCoins(PlayerPrefs.GetInt("SavedPoints", 0)); // ���������� ���������� ����� � ������� ����
    }

    public void UpdateCoins(int coins)
    {
        CoinTexts.text = coins.ToString();
    }
}
