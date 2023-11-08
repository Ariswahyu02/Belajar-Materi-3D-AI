using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//untuk menggerakkan waypoint
public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float distanceTreshold;
    [SerializeField] private int scaling;
    [SerializeField] private bool monster;
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
        //digunakan untuk merubah titik arah waypoint jika terlalu dkt
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceTreshold)
        {
            currentWaypoint = waypoints.GetNextWaypoints(currentWaypoint);
        }
        InputKey();
        Monster();
        RotateTowardsWaypoint();
    }

    private void RotateTowardsWaypoint()
    {
        Vector3 directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
        Quaternion rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);

    }

    private void Monster()
    {
        if (monster)
        {
            transform.localScale = new Vector3(scaling, scaling, scaling);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void InputKey()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            monster = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            monster = false;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            scaling += 3;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            scaling -= 3;
        }
    }



}
