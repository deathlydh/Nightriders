using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public List<GameObject> boxes; // Список всех коробок на сцене
   

    private void Start()
    {
        ActivateRandomBoxes();
    }

    public void ActivateRandomBoxes()
    {
        int minBoxesToActivate = 5; // Минимальное количество коробок для активации
        int numberOfBoxesToActivate = Random.Range(minBoxesToActivate, boxes.Count + 1); // Выбираем случайное количество коробок для активации
        for (int i = 0; i < numberOfBoxesToActivate; i++)
        {
            if (boxes.Count > 0)
            {
                int randomIndex = Random.Range(0, boxes.Count); // Выбираем случайный индекс из списка
                GameObject randomBox = boxes[randomIndex];
                randomBox.SetActive(true); // Активируем выбранную коробку
                boxes.RemoveAt(randomIndex); // Удаляем активированную коробку из списка
            }
        }

       
    }
}
