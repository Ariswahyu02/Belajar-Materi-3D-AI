using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float speed = 5f;
    private Transform currentWaypoint;

    private void Start()
    {
        // set waypoint pertama
        currentWaypoint = waypoints.SetFirstWaypoint();
        transform.position = currentWaypoint.position;

        // set waypoint selanjutnya
        currentWaypoint = waypoints.GetNextWaypoints(currentWaypoint);

    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
        {
            currentWaypoint = waypoints.GetNextWaypoints(currentWaypoint);
        }
    }

}
