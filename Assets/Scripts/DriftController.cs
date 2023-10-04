using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DriftController : MonoBehaviour
{
    // Настройки
    public float MoveSpeed = 50; // Скорость движение
    public float MaxSpeed = 15; // Максимальная скорость
    public float Drag = 0.98f; // Сопротивление движения
    public float SteerAngle = 20; // Угол поворота
    public float Traction = 1; // Сцепление

    private Vector3 MoveForce;

    // Update is called once per frame
    void Update()
    {
        //Движение
        MoveForce = transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //Управление
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(eulers: Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);


        // Сопротивление и ограничение максимальной скорости
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);
        

        // Сцепление 
        Debug.DrawRay(start: transform.position, dir: MoveForce.normalized * 3); //Отрисовка луча для отладки
        Debug.DrawRay(start: transform.position, dir: transform.forward * 3, Color.blue); //Отрисовка луча для отладки
        MoveForce = Vector3.Lerp(a: MoveForce.normalized, b: transform.forward, t: Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
