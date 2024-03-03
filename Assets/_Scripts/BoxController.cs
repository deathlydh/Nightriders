using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public static int destroyedBoxesCount; // Статическая переменная для хранения количества снесённых коробок
    public Text destroyedBoxesText; // Ссылка на UI-текст для отображения количества снесённых коробок

    private bool isDestroyed = false;
    private Collider boxCollider;

    private void Start()
    {
        // Инициализация счётчика снесённых коробок
        destroyedBoxesCount = 0;

        // Находим UI-текст, если ссылка на него не была установлена в инспекторе
        if (destroyedBoxesText == null)
        {
            destroyedBoxesText = GameObject.Find("DestroyedBoxesText").GetComponent<Text>();
        }

        // Получаем ссылку на компонент Collider при запуске скрипта
        boxCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDestroyed)
        {
            isDestroyed = true;
            destroyedBoxesCount++; // Увеличиваем счётчик снесённых коробок
            UpdateDestroyedBoxesText(); // Обновляем UI-текст
            Destroy(boxCollider);
        }
    }

    void UpdateDestroyedBoxesText()
    {
        destroyedBoxesText.text = destroyedBoxesCount.ToString(); // Обновляем UI-текст
    }

    
}
