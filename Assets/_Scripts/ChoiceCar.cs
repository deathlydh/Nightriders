using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCar : MonoBehaviour
{
    [SerializeField] public GameObject[] AllCar;
    public Text carSpeedText; // Ссылка на текстовый элемент для скорости
    public Text driftPointsText; // Ссылка на текстовый элемент для очков дрифта
    public Text savedScore; // Ссылка на текстовый элемент для сохраненных очков


    private PrometeoCarController carController;

    private void Start()
    {
        
        for (int i = 0; i < AllCar.Length; i++)
        {
            AllCar[i].SetActive(false);
        }

        int currentCarIndex = PlayerPrefs.GetInt("CurrentCar", 0);
        AllCar[currentCarIndex].SetActive(true);

        StartCoroutine(DelayedUpdateUI());
    }

   /* private void Update()
    {
        UpdateUI();
   } */
    private IEnumerator DelayedUpdateUI()
    {
        yield return new WaitForSeconds(1f); // Подождем 1 секунду перед вызовом UpdateUI()

        UpdateUI();
    }
    private void UpdateUI()
    {


        if (carSpeedText != null && driftPointsText != null && savedScore != null && carController != null)
        {
            float carSpeed = carController.GetCarSpeed();
            float driftPoints = carController.GetDriftPoints();
            float savedPoints = carController.GetSavedPoints();

            float absoluteCarSpeed = Mathf.Abs(carSpeed);
            carSpeedText.text = Mathf.RoundToInt(absoluteCarSpeed).ToString();

            float roundedPoints = Mathf.RoundToInt(driftPoints);
            driftPointsText.text = Mathf.RoundToInt(roundedPoints).ToString();

            float savedPointsUI = Mathf.RoundToInt(savedPoints);
            savedScore.text = Mathf.RoundToInt(savedPointsUI).ToString();
        }
       
    }

}
