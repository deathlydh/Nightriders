using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;
    public float maxSpeed = 0.0f; // Максимальная скорость цели ** В КМ/Ч **

    [Header("UI")]
    public Text speedLabel; // Метка, отображающая скорость

    private float speed = 0.0f;

    private void Update()
    {
        // 3.6f для преобразования в километры
        // ** Скорость должна быть ограничена контроллером автомобиля **
        speed = target.velocity.magnitude * 3.6f;

        if (speedLabel != null)
        {
            // Проверяем текущий язык и устанавливаем единицы измерения скорости соответственно
            string speedText = "";
            if (YandexGame.EnvironmentData.language == "ru")
            {
                speedText = ((int)speed) + " км/ч";
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                speedText = ((int)speed) + " km/s";
            }
            else
                speedText = ((int)speed) + " km/h";

            speedLabel.text = speedText;
        }
    }
}