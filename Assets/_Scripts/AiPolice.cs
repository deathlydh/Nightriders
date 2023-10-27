using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPolice : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public float moveSpeed = 5.0f; // Скорость полицейской машины
    public float rotationSpeed = 2.0f; // Скорость поворота
    private NavMeshAgent agent;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Направление к игроку
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Поворот машины в направлении игрока
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Движение машины
        rb.velocity = transform.forward * moveSpeed;
        agent.SetDestination(player.position);
    }
}
