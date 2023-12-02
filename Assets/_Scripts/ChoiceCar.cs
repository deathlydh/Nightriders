using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCar : MonoBehaviour
{
    [SerializeField] public GameObject[] AllCar;
    public Text carSpeedText; // ������ �� ��������� ������� ��� ��������
    public Text driftPointsText; // ������ �� ��������� ������� ��� ����� ������
    public Text savedScore; // ������ �� ��������� ������� ��� ����������� �����

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
            float carSpeed = 0f; // �������� ������� �������� ����� ������
            float driftPoints = 0f; // �������� ������� ���� ������
            float savedPoints = 0f; // �������� ������� ����������� ����

            // ��������� ������ ��������� UI
            float absoluteCarSpeed = Mathf.Abs(carSpeed);
            carSpeedText.text = Mathf.RoundToInt(absoluteCarSpeed).ToString();

            float roundedPoints = Mathf.RoundToInt(driftPoints);
            driftPointsText.text = Mathf.RoundToInt(roundedPoints).ToString();

            float savedPointsUI = Mathf.RoundToInt(savedPoints);
            savedScore.text = Mathf.RoundToInt(savedPointsUI).ToString();
        }
    }
}
