using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform _transformFrontLeft;
    [SerializeField] private Transform _transformFrontRight;
    [SerializeField] private Transform _transformBackLeft;
    [SerializeField] private Transform _transformBackRight;

    [SerializeField] private WheelCollider _colliderFrontLeft;
    [SerializeField] private WheelCollider _colliderFrontRight;
    [SerializeField] private WheelCollider _colliderBackLeft;
    [SerializeField] private WheelCollider _colliderBackRight;

    [SerializeField] private float _force;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _shiftBoostForce;


    private void FixedUpdate()
    {
        //Ускорение
        _colliderFrontLeft.motorTorque = Input.GetAxis("Vertical") * _force;
        _colliderFrontRight.motorTorque = Input.GetAxis("Vertical") * _force;
        float acceleration = Input.GetAxis("Vertical") * _force;

        // Ускорение с клавишей Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration *= _shiftBoostForce;
        }

        _colliderFrontLeft.motorTorque = acceleration;
        _colliderFrontRight.motorTorque = acceleration;
        

        // Ручной тормоз
        if (Input.GetKey(KeyCode.Space))
        {
            _colliderFrontLeft.brakeTorque = 3000f;
            _colliderFrontRight.brakeTorque = 3000f;
            _colliderBackLeft.brakeTorque = 3000f;
            _colliderBackRight.brakeTorque = 3000f;
        }
        else
        {
            _colliderFrontLeft.brakeTorque = 0f;
            _colliderFrontRight.brakeTorque = 0f;
            _colliderBackLeft.brakeTorque = 0f;
            _colliderBackRight.brakeTorque = 0f;
        }

        //Повороты
        _colliderFrontLeft.steerAngle = _maxAngle * Input.GetAxis("Horizontal");
        _colliderFrontRight.steerAngle = _maxAngle * Input.GetAxis("Horizontal");

        RotateWheel(_colliderFrontLeft, _transformFrontLeft);
        RotateWheel(_colliderFrontRight, _transformFrontRight);
        RotateWheel(_colliderBackLeft, _transformBackLeft);
        RotateWheel(_colliderBackRight, _transformBackRight);

    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
