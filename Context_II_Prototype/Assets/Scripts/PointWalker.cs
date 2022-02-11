using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointWalker : MonoBehaviour
{
    public int currentPoint = 0;
    public Transform[] points;
    public bool autoProceedToNextPoint = true;
    public float moveSpeed;

    void Update()
    {
        if(currentPoint < points.Length)
        {
            WalkToPoint();
        }
    }

    public void WalkToPoint()
    {
        if(Vector3.Distance(transform.position, points[currentPoint].position) > 5.0f)
        {
            transform.position += (points[currentPoint].position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }
        else if(autoProceedToNextPoint) { currentPoint++; }
            
    }

    public void NextPoint()
    {
        currentPoint++;
    }

}
