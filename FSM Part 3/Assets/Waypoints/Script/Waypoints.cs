using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private bool canLoop = true;
    [SerializeField] private bool moveForward = true;
    private void OnDrawGizmos()
    {
        //mengloop semua child dan memberi warna+kube
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(t.position, 0.5f);
        }

        //mengdrawline untuk slg terhbung dlm antar cube
        Gizmos.color = Color.white;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        if (canLoop)
        {

            Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        }
    }

    //mengeset titik awal dr waypoints
    public Transform SetFirstWaypoint()
    {
        return transform.GetChild(0);
    }

    public Transform GetNextWaypoints(Transform currentWaypoint)
    {
        int currentIndex = currentWaypoint.GetSiblingIndex();
        int nextIndex = currentIndex;

        if (moveForward)
        {
            nextIndex++;

            if (nextIndex == transform.childCount)
            {
                if (canLoop)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex--;
                }
            }
        }
        else
        {
            nextIndex--;

            if (nextIndex < 0)
            {
                if (canLoop)
                {
                    nextIndex = transform.childCount - 1;
                }
                else
                {
                    nextIndex++;
                }
            }
        }

        return transform.GetChild(nextIndex);
    }

}
