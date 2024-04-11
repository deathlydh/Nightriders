using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomePanel : MonoBehaviour
{
    public GameObject welcomePanel;

    // ћетод дл€ установки TimeScale в 0 при открытии панели
    public void SetTimeScaleToZero()
    {
        Time.timeScale = 0f;
    }

    // ћетод дл€ установки TimeScale в 1 при закрытии панели
    public void SetNormalTimeScale()
    {
        Time.timeScale = 1f;
    }

    // ѕровер€ем состо€ние панели приветстви€ каждый кадр
    private void Update()
    {
        // ≈сли панель приветстви€ открыта, устанавливаем TimeScale в 0
        if (welcomePanel.activeSelf)
        {
            SetTimeScaleToZero();
        }
        
    }
}
