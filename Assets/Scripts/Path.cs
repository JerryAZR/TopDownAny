using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();

    public int WaypointCount => waypoints.Count;

    public Vector3 GetWaypoint(int index)
    {
        return waypoints[index].position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
            {
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
                Gizmos.DrawSphere(waypoints[i].position, 0.15f);
            }
        }

        if (waypoints.Count > 0 && waypoints[^1] != null)
        {
            Gizmos.DrawSphere(waypoints[^1].position, 0.15f);
        }
    }
}
