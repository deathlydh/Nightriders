using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxController : MonoBehaviour
{
    public static int destroyedBoxesCount;
    public int totalBoxesCount; // ����� ���������� ������� �� �����
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

        // ������� ������ ���������� ������� �� �����
        totalBoxesCount = GameObject.FindGameObjectsWithTag("Crash").Length;

        // ���������� ������ � UI
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

            // �������� BoxCollider
            Destroy(boxCollider);

            // ���� � ���� ������� ���� ������ Target
            if (GetComponent<Target>() != null)
            {
                // �������� ��������� Target
                Target targetComponent = GetComponent<Target>();

                // ���� � ���������� Target ���� ���������
                if (targetComponent.indicator != null)
                {
                    // ��������� ���������
                    targetComponent.indicator.Activate(false);
                }
            }

            // ���������, ��������� �� ��� �������
            if (destroyedBoxesCount == totalBoxesCount)
            {
                // ���� ��� ������� ���������, ��������� �������� ��� �������� ����� ���������� UI ������
                if (gameOverPanel != null)
                {
                    StartCoroutine(ShowGameOverPanelAfterDelay(1f)); // �������� � 1 �������
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
