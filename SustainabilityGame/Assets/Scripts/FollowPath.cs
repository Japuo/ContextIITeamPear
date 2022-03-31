using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent onFinishEvents;

    public Animator foxAnimator;

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

                foxAnimator.SetFloat("PlayerClose", playerDetectionRange);
            }
        }

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length) { canWalk = false; StartCoroutine(FoxCutscene()); return; }
            currentTarget = waypoints[currentWaypoint];
        }

    }

    //Dit zuigt maar *shrug*
    IEnumerator FoxCutscene()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        sr.enabled = false;
        yield return new WaitForSeconds(2.0f); //Haha hardcoded values go brrrr
        sr.enabled = true;
        onFinishEvents.Invoke();
    }    
}
