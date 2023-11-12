using UnityEngine;

public class RespawnOnKeyPress1 : MonoBehaviour
{
    public KeyCode respawnKey = KeyCode.R;
    public string roadTag = "road"; // тег объекта дороги
    public float maxDistance = 100f; // максимальное расстояние, на котором искать дорогу
    public LayerMask roadLayer; // слой объекта дороги

    private void Update()
    {
        if (Input.GetKeyDown(respawnKey))
        {
            Debug.Log("R key pressed");
            Respawn();
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

            // Теперь телепортируемся на ближайший объект
            transform.position = closestCollider.transform.position + Vector3.up * 0.5f;
            Debug.Log("Teleported to the closest object with tag: " + closestCollider.gameObject.tag);
        }
        else
        {
            Debug.LogWarning("No road found nearby.");
        }
    }

}