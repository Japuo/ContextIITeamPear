using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public float playerDetectionRange;
    public float moveSpeed = 5;
    public Transform[] waypoints;
    public Rigidbody2D rb2d;

    private GameObject player;
    private Transform currentTarget;
    private int currentWaypoint = 0;
    private bool canWalk;

    void Awake()
    {
        canWalk = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, playerDetectionRange);

        Gizmos.color = Color.red;
        foreach (Transform waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint.position, 1);
        }
    }

    private void FixedUpdate()
    {
        if (currentWaypoint < waypoints.Length)
        {
            if (currentTarget == null)
            {
                currentTarget = waypoints[currentWaypoint];
            }
            Walk();
        }
    }

    public void ActivateCanWalk()
    {
        canWalk = true;
    }

    void Walk()
    {
        Vector3 dir = (currentTarget.transform.position - rb2d.transform.position).normalized;
        if (canWalk)
        {
            if (Vector2.Distance(player.transform.position, transform.position) <= playerDetectionRange)
            {
                rb2d.MovePosition(transform.position + dir * moveSpeed * Time.fixedDeltaTime);
            }
        }

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length) { canWalk = false; return; }
            currentTarget = waypoints[currentWaypoint];
        }

    }
}
