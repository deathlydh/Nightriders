using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class MainMenu : MonoBehaviour
{
    public void PlayGameFreeRide()
    {
        SceneManager.LoadScene("SimplePoly City - Low Poly Assets_Demo Scene");
    }
    public void PlayGameCrashTest()
    {
        SceneManager.LoadScene("crash-test");
    }
}
