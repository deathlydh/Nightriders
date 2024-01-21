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
    }

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectCar(currentCar);
    }
}
