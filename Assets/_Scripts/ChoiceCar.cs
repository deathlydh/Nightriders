using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCar : MonoBehaviour
{
    [SerializeField] public GameObject[] AllCar;
    public Text carSpeedText; // Ссылка на текстовый элемент для скорости
    public Text driftPointsText; // Ссылка на текстовый элемент для очков дрифта
    public Text savedScore; // Ссылка на текстовый элемент для сохраненных очков

    private void Start()
    {
        for (int i = 0; i < AllCar.Length; i++)
        {
            AllCar[i].SetActive(false);
        }

        int currentCarIndex = PlayerPrefs.GetInt("CurrentCar", 0);
        AllCar[currentCarIndex].SetActive(true);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (carSpeedText != null && driftPointsText != null && savedScore != null)
        {
            float carSpeed = 0f; // Получите текущую скорость вашей машины
            float driftPoints = 0f; // Получите текущие очки дрифта
            float savedPoints = 0f; // Получите текущие сохраненные очки

            // Обновляем тексты элементов UI
            float absoluteCarSpeed = Mathf.Abs(carSpeed);
            carSpeedText.text = Mathf.RoundToInt(absoluteCarSpeed).ToString();

            float roundedPoints = Mathf.RoundToInt(driftPoints);
            driftPointsText.text = Mathf.RoundToInt(roundedPoints).ToString();

            float savedPointsUI = Mathf.RoundToInt(savedPoints);
            savedScore.text = Mathf.RoundToInt(savedPointsUI).ToString();
        }
    }
}
