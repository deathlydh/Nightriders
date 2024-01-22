using UnityEngine;
using UnityEngine.UI;

public class CarSelector1 : MonoBehaviour
{
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;
    private int currentCar;

    [SerializeField] private ShopButton[] shopButtons; // Массив кнопок ShopButton

    private void Start()
    {
        int savedCarIndex = PlayerPrefs.GetInt("CurrentCar", 0);
        currentCar = savedCarIndex;
        SelectCar(currentCar);
    }

    private void SelectCar(int _index)
    {
        prevButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }

        // Передаем информацию в ShopButton при смене машины
        if (_index >= 0 && _index < shopButtons.Length)
        {
            for (int i = 0; i < shopButtons.Length; i++)
            {
                shopButtons[i].gameObject.SetActive(i == _index);
            }
        }

        // Обновляем состояние всех кнопок магазина
        UpdateShopButton();
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);
    }

    private void UpdateShopButton()
    {
        // Обновляем состояние всех кнопок магазина
        foreach (var shopButton in shopButtons)
        {
            shopButton.UpdateInfo();
        }
    }
}
