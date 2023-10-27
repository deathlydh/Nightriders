using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    [SerializeField] private Transform _maincar;

    private Vector3 _offset = new Vector3(0f, 2f, -4f);
    private float _speed = 10f;

    private void FixedUpdate()
    {
        var targetPosition = _maincar.TransformPoint(_offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);

        var direction = _maincar.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }
}
