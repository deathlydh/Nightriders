using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomePanel : MonoBehaviour
{
    public GameObject welcomePanel;

    // ����� ��� ��������� TimeScale � 0 ��� �������� ������
    public void SetTimeScaleToZero()
    {
        Time.timeScale = 0f;
    }

    // ����� ��� ��������� TimeScale � 1 ��� �������� ������
    public void SetNormalTimeScale()
    {
        Time.timeScale = 1f;
    }

    // ��������� ��������� ������ ����������� ������ ����
    private void Update()
    {
        // ���� ������ ����������� �������, ������������� TimeScale � 0
        if (welcomePanel.activeSelf)
        {
            SetTimeScaleToZero();
        }
        
    }
}
