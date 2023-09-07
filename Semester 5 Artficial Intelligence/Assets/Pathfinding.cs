using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;
    
    private NavMeshAgent nav;
    private int destPoint;

    private void Start() 
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() 
    {
        if(!nav.pathPending && nav.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    private void GoToNextPoint()
    {
        if(points.Length == 0) return;

        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
