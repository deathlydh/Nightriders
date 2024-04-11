using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void Restart()
    {
        // Получаем индекс текущей активной сцены
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Перезагружаем текущую сцену
        SceneManager.LoadScene(activeSceneIndex);
    }
}
