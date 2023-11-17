using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Restart : MonoBehaviour
{
    private void Start()
    {
        YandexGame.FullscreenShow();
    }
    public void RestartLevel()
  {
        SceneManager.LoadScene("SimplePoly City - Low Poly Assets_Demo Scene");
  }
}
