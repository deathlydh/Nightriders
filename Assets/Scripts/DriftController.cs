using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DriftController : MonoBehaviour
{
    // ���������
    public float MoveSpeed = 50; // �������� ��������
    public float MaxSpeed = 15; // ������������ ��������
    public float Drag = 0.98f; // ������������� ��������
    public float SteerAngle = 20; // ���� ��������
    public float Traction = 1; // ���������

    private Vector3 MoveForce;

    // Update is called once per frame
    void Update()
    {
        //��������
        MoveForce = transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //����������
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(eulers: Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);


        // ������������� � ����������� ������������ ��������
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
        

        // ��������� 
        Debug.DrawRay(start: transform.position, dir: MoveForce.normalized * 3); //��������� ���� ��� �������
        Debug.DrawRay(start: transform.position, dir: transform.forward * 3, Color.blue); //��������� ���� ��� �������
        MoveForce = Vector3.Lerp(a: MoveForce.normalized, b: transform.forward, t: Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
