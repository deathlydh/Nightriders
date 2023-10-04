using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCentreOfMass : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass, 0.1f);
    }
}
