using UnityEngine;

public class ParentBoxCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Получаем все дочерние объекты
            Transform[] children = GetComponentsInChildren<Transform>();

            foreach (Transform child in children)
            {
                // Получаем компоненты BoxCollider и Target для текущей дочерней коробки
                BoxCollider boxCollider = child.GetComponent<BoxCollider>();
                Target target = child.GetComponent<Target>();

                // Если у текущей коробки есть компоненты BoxCollider и Target, удаляем их
                if (boxCollider != null && target != null)
                {
                    Destroy(boxCollider);

                    // Отключаем индикатор цели
                    if (target.indicator != null)
                    {
                        target.indicator.Activate(false);
                    }

                    // Отключаем компонент Target
                    target.enabled = false;
                }
            }
        }
    }
}
