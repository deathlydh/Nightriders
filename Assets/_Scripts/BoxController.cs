using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public static int destroyedBoxesCount; // ����������� ���������� ��� �������� ���������� �������� �������
    public Text destroyedBoxesText; // ������ �� UI-����� ��� ����������� ���������� �������� �������

    private bool isDestroyed = false;
    private Collider boxCollider;

    private void Start()
    {
        // ������������� �������� �������� �������
        destroyedBoxesCount = 0;

        // ������� UI-�����, ���� ������ �� ���� �� ���� ����������� � ����������
        if (destroyedBoxesText == null)
        {
            destroyedBoxesText = GameObject.Find("DestroyedBoxesText").GetComponent<Text>();
        }

        // �������� ������ �� ��������� Collider ��� ������� �������
        boxCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDestroyed)
        {
            isDestroyed = true;
            destroyedBoxesCount++; // ����������� ������� �������� �������
            UpdateDestroyedBoxesText(); // ��������� UI-�����
            Destroy(boxCollider);
        }
    }

    void UpdateDestroyedBoxesText()
    {
        destroyedBoxesText.text = destroyedBoxesCount.ToString(); // ��������� UI-�����
    }

    
}
