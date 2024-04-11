using UnityEngine;

public class ParentBoxCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �������� ��� �������� �������
            Transform[] children = GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                // �������� ���������� BoxCollider � Target ��� ������� �������� �������
                BoxCollider boxCollider = child.GetComponent<BoxCollider>();
                Target target = child.GetComponent<Target>();

                // ���� � ������� ������� ���� ���������� BoxCollider � Target, ������� ��
                if (boxCollider != null && target != null)
                {
                    Destroy(boxCollider);

                    // ��������� ��������� ����
                    if (target.indicator != null)
                    {
                        target.indicator.Activate(false);
                    }

                    // ��������� ��������� Target
                    target.enabled = false;
                }
            }
        }
    }
}
