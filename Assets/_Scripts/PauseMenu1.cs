using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject RewardPanel;
    public bool isPaused; // Переменная для хранения состояния паузы

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused && !settingsMenu.activeSelf && !RewardPanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Settings()
    {
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main menu");
    }
}