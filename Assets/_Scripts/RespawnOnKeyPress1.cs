using UnityEngine;

public class RespawnOnKeyPress1 : MonoBehaviour
{
    public KeyCode respawnKey = KeyCode.R;
    public string roadTag = "road"; // тег объекта дороги
    public float maxDistance = 100f; // максимальное расстояние, на котором искать дорогу
    public LayerMask roadLayer; // слой объекта дороги
    public float teleportDelay = 3f; // задержка телепортации в секундах
    private float lastTeleportTime;

    private void Update()
    {
        if (Input.GetKeyDown(respawnKey) && Time.time - lastTeleportTime > teleportDelay)
        {
            Debug.Log("R key pressed");
            Respawn();
            lastTeleportTime = Time.time; // обновляем время последней телепортации
        }
    }

    private void Respawn()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance, roadLayer);

        if (colliders.Length > 0)
        {
            // Найдем ближайший объект с тегом "Road"
            Collider closestCollider = colliders[0];
            float closestDistance = Vector3.Distance(transform.position, closestCollider.transform.position);

            foreach (var collider in colliders)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestCollider = collider;
                    closestDistance = distance;
                }
            }

            // Теперь телепортируемся на ближайший объект с учетом смещения и обновляем время телепортации
            Vector3 respawnPosition = closestCollider.transform.position + Vector3.up * 1f; // Поднимаем на 0.5 по оси Y
            transform.position = respawnPosition;
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f); // Устанавливаем нулевой угол поворота по оси Z
            Debug.Log("Teleported to the closest object with tag: " + closestCollider.gameObject.tag);
            lastTeleportTime = Time.time; // обновляем время последней телепортации
        }
        else
        {
            Debug.LogWarning("No road found nearby.");
        }
    }

}

