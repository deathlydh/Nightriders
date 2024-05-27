using UnityEngine;
using UnityEngine.UI;
using YG;

public class ShopButton : MonoBehaviour
{
    public int carPrice = 100; // Цена машинки
    public Button buyButton; // Кнопка покупки
    public Text statusText; // Текстовое поле для вывода статуса покупки
    public GameObject cars; // Массив доступных машинок
    public int CarIndex = 0;

    private ShopManager manager;
    private CoinText coinText; // Ссылка на скрипт CoinText

    private void Start()
    {
        buyButton.onClick.AddListener(BuyCar);

        // Получение ссылки на скрипт CoinText
        coinText = FindObjectOfType<CoinText>();

        if (coinText == null)
        {
            Debug.LogError("CoinText script not found in the scene!");
            return;
        }

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
            statusText.text = GetLocalizedString("Выбрано", "Selected", "Seçildi");
        }
        else if (PlayerPrefs.GetInt("CarBought_" + CarIndex, 0) == 1)
        {
            statusText.text = GetLocalizedString("Куплено", "Purchased", "Satın Alındı");
        }
        else
        {
            string priceText = GetLocalizedString("Цена: ", "Price: ", "Fiyat: ") + carPrice + GetLocalizedString(" монет", " coins", " madeni para");
            statusText.text = priceText;
        }
    }

    private string GetLocalizedString(string englishText, string russianText, string turkishText)
    {
        string localizedText = russianText;

        if (YandexGame.EnvironmentData.language == "en")
        {
            localizedText += englishText;
        }
        else if (YandexGame.EnvironmentData.language == "tr")
        {
            localizedText = turkishText;
        }

        return localizedText;
    }

    public void BuyCar()
    {
        if (coinText != null)
        {
            int money = coinText.currentCoins; // Получаем количество монет из CoinText

            if (PlayerPrefs.GetInt("CarBought_" + CarIndex, 0) != 1)
            {
                if (money >= carPrice)
                {
                    money -= carPrice;
                    coinText.AddMoney(-carPrice); // Обновляем количество монет в CoinText, вычитая стоимость машины
                    PlayerPrefs.SetInt("CarBought_" + CarIndex, 1);

                    // Установка машины как выбранной, если только что куплена
                    PlayerPrefs.SetInt("CurrentCar", CarIndex);

                    // Обновляем информацию о кнопке
                    UpdateInfo();

                    if (manager != null)
                    {
                        manager.UpdateInfoButton();
                    }
                }
                else
                {
                    Debug.Log("Не хватает денег");
                }
            }
            else
            {
                Debug.Log("Машина уже куплена, назначить основной");
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
