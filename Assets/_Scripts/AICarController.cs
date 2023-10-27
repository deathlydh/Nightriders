using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float rotationSpeed = 120f;
    [SerializeField] private float stopDistance = 2.5f;
    [SerializeField] public bool reachedDestination;
    [SerializeField] private Vector3 destination;
    private Vector3 lastPosition; // Added a missing declaration for lastPosition
    private Vector3 velocity; // Added a missing declaration for velocity

    // Update is called once per frame
    void Update()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            float velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            lastPosition = transform.position; // Update lastPosition
        }
    }

    public void SetDestination(Vector3 newDestination)
    {
        destination = newDestination;
        reachedDestination = false;
    }
}

