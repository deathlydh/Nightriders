using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPolice : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    public float moveSpeed = 5.0f; // �������� ����������� ������
    public float rotationSpeed = 2.0f; // �������� ��������
    private NavMeshAgent agent;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // ����������� � ������
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // ������� ������ � ����������� ������
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // �������� ������
        rb.velocity = transform.forward * moveSpeed;
        agent.SetDestination(player.position);
    }
}
