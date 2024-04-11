using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxController : MonoBehaviour
{
    public static int destroyedBoxesCount;
    public int totalBoxesCount; // Общее количество коробок на карте
    public Text destroyedBoxesText;
    public GameObject gameOverPanel;

    private bool isDestroyed = false;
    private Collider boxCollider;
    private Target target;

    private void Start()
    {
        destroyedBoxesCount = 0;

        if (destroyedBoxesText == null)
        {
            destroyedBoxesText = GameObject.Find("DestroyedBoxesText").GetComponent<Text>();
        }

        boxCollider = GetComponent<Collider>();

        // Подсчет общего количества коробок на карте
        totalBoxesCount = GameObject.FindGameObjectsWithTag("Crash").Length;

        // Обновление текста в UI
        UpdateDestroyedBoxesText();
    }

    public void SetTarget(Target newTarget)
    {
        target = newTarget;
        Debug.Log("Target set: " + (target != null ? target.name : "null"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDestroyed)
        {
            isDestroyed = true;
            destroyedBoxesCount++;
            UpdateDestroyedBoxesText();

            // Удаление BoxCollider
            Destroy(boxCollider);

            // Если у этой коробки есть скрипт Target
            if (GetComponent<Target>() != null)
            {
                // Получаем компонент Target
                Target targetComponent = GetComponent<Target>();

                // Если у компонента Target есть индикатор
                if (targetComponent.indicator != null)
                {
                    // Отключаем индикатор
                    targetComponent.indicator.Activate(false);
                }
            }

            // Проверяем, разрушены ли все коробки
            if (destroyedBoxesCount == totalBoxesCount)
            {
                // Если все коробки разрушены, запускаем корутину для задержки перед активацией UI панели
                if (gameOverPanel != null)
                {
                    StartCoroutine(ShowGameOverPanelAfterDelay(1f)); // Задержка в 1 секунду
                }
            }
        }
    }

    private IEnumerator ShowGameOverPanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void UpdateDestroyedBoxesText()
    {
        destroyedBoxesText.text = destroyedBoxesCount + "/" + totalBoxesCount;
    }
}
