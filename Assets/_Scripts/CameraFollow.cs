using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public ChoiceCar choiceCarScript;
    public Transform carTransform;
    [Range(1, 10)]
    public float followSpeed = 2;
    [Range(1, 10)]
    public float lookSpeed = 5;
    Vector3 initialCameraPosition;
    Vector3 initialCarPosition;
    Vector3 absoluteInitCameraPosition;

    void Start()
    {
        initialCameraPosition = gameObject.transform.position;
        initialCarPosition = carTransform.position;
        absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;
    }

    void FixedUpdate()
    {
        int chosenCarIndex = PlayerPrefs.GetInt("CurrentCar", 0); // Получение выбранной машины из PlayerPrefs

        if (chosenCarIndex < choiceCarScript.AllCar.Length && chosenCarIndex >= 0) // Проверка на корректный индекс
        {
            Transform chosenCarTransform = choiceCarScript.AllCar[chosenCarIndex].transform; // Получение выбранной машины

            // Look at the chosen car
            Vector3 _lookDirection = chosenCarTransform.position - transform.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);

            // Move to the chosen car
            Vector3 _targetPos = absoluteInitCameraPosition + chosenCarTransform.position;
            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
        }
    }
}

