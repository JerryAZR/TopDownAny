using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Path path;
    public float speed = 2f;
    public float turnSpeed = 8f;

    private int currentWaypointIndex = 0;

    void Start()
    {
        if (path == null || path.WaypointCount == 0)
        {
            Debug.LogError("Enemy has no valid path assigned.");
            return;
        }

        currentWaypointIndex = 0;

        Vector3 startPos = path.GetWaypoint(0);
        transform.position = startPos;

        if (path.WaypointCount > 1)
        {
            Vector3 nextDir = path.GetWaypoint(1) - startPos;
            if (nextDir != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(nextDir, Vector3.up);
            }
        }
    }

    void Update()
    {
        if (path == null || path.WaypointCount == 0)
            return;

        Vector3 target = path.GetWaypoint(currentWaypointIndex);
        Vector3 direction = target - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            AdvanceWaypoint();
        }
        else
        {
            Vector3 moveDir = direction.normalized;

            transform.position += moveDir * distanceThisFrame;
            RotateTowards(moveDir);
        }
    }

    void RotateTowards(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );
    }

    void AdvanceWaypoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex >= path.WaypointCount)
        {
            OnReachEnd();
        }
    }

    void OnReachEnd()
    {
        Debug.Log("Enemy reached the end of the path");
        Destroy(gameObject);
    }
}
