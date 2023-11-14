using UnityEngine;

public class RespawnOnKeyPress1 : MonoBehaviour
{
    public KeyCode respawnKey = KeyCode.R;
    public string roadTag = "road"; // ��� ������� ������
    public float maxDistance = 100f; // ������������ ����������, �� ������� ������ ������
    public LayerMask roadLayer; // ���� ������� ������
    public float teleportDelay = 30f; // �������� ������������ � ��������
    private float lastTeleportTime;

    private void Update()
    {
        if (Input.GetKeyDown(respawnKey) && Time.time - lastTeleportTime > teleportDelay)
        {
            Debug.Log("R key pressed");
            Respawn();
            lastTeleportTime = Time.time; // ��������� ����� ��������� ������������
        }
    }

    private void Respawn()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxDistance, roadLayer);

        if (colliders.Length > 0)
        {
            // ������ ��������� ������ � ����� "Road"
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

            // ������ ��������������� �� ��������� ������ � ������ �������� � ��������� ����� ������������
            transform.position = closestCollider.transform.position + Vector3.up * 0.5f;
            Debug.Log("Teleported to the closest object with tag: " + closestCollider.gameObject.tag);
            lastTeleportTime = Time.time; // ��������� ����� ��������� ������������
        }
        else
        {
            Debug.LogWarning("No road found nearby.");
        }
    }
}
