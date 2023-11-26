using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour
{
    [SerializeField] private GameObject[] CarModels;

    private void Awake()
    {
        ChooseCarModel(SaveManager.instance.currentCar);
    }

    private void ChooseCarModel(int _index)
    {
        Instantiate(CarModels[_index], transform.position, Quaternion.identity, transform);
    }
}