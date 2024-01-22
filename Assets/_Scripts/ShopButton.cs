using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public int carPrice = 100; // ���� �������
    public Button buyButton; // ������ �������
    public Text statusText; // ��������� ���� ��� ������ ������� �������
    public GameObject cars; // ������ ��������� �������
    public int CarIndex = 0;

    private ShopManager manager;
    private CoinText coinText; // ������ �� ������ CoinText

    private void Start()
    {
        buyButton.onClick.AddListener(BuyCar);

        // ��������� ������ �� ������ CoinText
        coinText = FindObjectOfType<CoinText>();

        PlayerPrefs.SetInt("CarBought_" + 0, 1);
        UpdateInfo();
    }

    public void SetManager(ShopManager shopManager)
    {
        manager = shopManager;
    }

    public void SetCarIndex(int newIndex)
    {
        CarIndex = newIndex;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        int currentCarIndex = PlayerPrefs.GetInt("CurrentCar", 0);

        if (currentCarIndex == CarIndex)
        {
            statusText.text = "�������";
        }
        else if (PlayerPrefs.GetInt("CarBought_" + CarIndex, 0) == 1)
        {
            statusText.text = "�������";
        }
        else
        {
            statusText.text = "���������: " + carPrice + " �����";
        }

  
    }

    public void BuyCar()
    {
        if (coinText != null)
        {
            int money = coinText.currentCoins; // �������� ���������� ����� �� CoinText

            if (PlayerPrefs.GetInt("CarBought_" + CarIndex, 0) != 1)
            {
                if (money >= carPrice)
                {
                    money -= carPrice;
                    coinText.AddMoney(-carPrice); // ��������� ���������� ����� � CoinText, ������� ��������� ������
                    PlayerPrefs.SetInt("CarBought_" + CarIndex, 1);

                    // ��������� ������ ��� ���������, ���� ������ ��� �������
                    PlayerPrefs.SetInt("CurrentCar", CarIndex);

                    // ��������� ���������� � ������
                    UpdateInfo();

                    if (manager != null)
                    {
                        manager.UpdateInfoButton();
                    }
                }
                else
                {
                    Debug.Log("�� ������� �����");
                }
            }
            else
            {
                Debug.Log("������ ��� �������, ��������� ��������");
                PlayerPrefs.SetInt("CurrentCar", CarIndex);
                UpdateInfo();

                if (manager != null)
                {
                    manager.UpdateInfoButton();
                }
            }
        }
        else
        {
            Debug.LogError("CoinText script reference is missing!");
        }
    }
}
