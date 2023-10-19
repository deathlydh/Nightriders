using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigation : MonoBehaviour
{
    AICarController controller;
    public Waypoint currentWaypoint;

    int direction;

    private void Awake()
    {
        controller = GetComponent<AICarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));

        controller.SetDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (controller.reachedDestination)
        {
            if(direction == 0)
            {
               currentWaypoint = currentWaypoint.nextWaypoint;
            }
            else if(direction == 1)
            {
                currentWaypoint = currentWaypoint.previousWaypoint;
            }
            
            controller.SetDestination(currentWaypoint.GetPosition());
        }
    }
}