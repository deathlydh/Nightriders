using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public List<GameObject> boxes; // ������ ���� ������� �� �����
   

    private void Start()
    {
        ActivateRandomBoxes();
    }

    public void ActivateRandomBoxes()
    {
        int minBoxesToActivate = 5; // ����������� ���������� ������� ��� ���������
        int numberOfBoxesToActivate = Random.Range(minBoxesToActivate, boxes.Count + 1); // �������� ��������� ���������� ������� ��� ���������
        for (int i = 0; i < numberOfBoxesToActivate; i++)
        {
            if (boxes.Count > 0)
            {
                int randomIndex = Random.Range(0, boxes.Count); // �������� ��������� ������ �� ������
                GameObject randomBox = boxes[randomIndex];
                randomBox.SetActive(true); // ���������� ��������� �������
                boxes.RemoveAt(randomIndex); // ������� �������������� ������� �� ������
            }
        }

       
    }
}
