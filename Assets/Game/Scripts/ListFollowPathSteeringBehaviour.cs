using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ListFollowPathSteeringBehaviour : ArriveSteeringBehaviour
{
    public float waypointDistance = 0.5f;
    public int currentWaypointIndex = 0;
    public GameObject[] points;

    public override Vector3 CalculateForce()
    {
        CheckMouseInput();
        
        if(points != null) 
        {
            if (points.Length > 0 && currentWaypointIndex == 0)
            {
                target = points[0].transform.position;
            }
        }

        if ((target - transform.position).magnitude < waypointDistance) 
        {
            if (currentWaypointIndex != points.Length)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex < points.Length)
                {
                    target = points[currentWaypointIndex].transform.position;
                }
            }
            else if (currentWaypointIndex == points.Length)
            {
                currentWaypointIndex = 0;
                target = points[currentWaypointIndex].transform.position;
            }
        }
        
        return CalculateArriveForce();
    }

    protected override void OnDrawGizmos()
    { 
        base.OnDrawGizmos();

        DebugExtension.DrawCircle(target, Color.magenta, waypointDistance);
        if(points != null) 
        { 
            for(int i = 1; i < points.Length; i++) 
            {
                Debug.DrawLine(points[i-1].transform.position, points[i].transform.position, Color.black);
            }
        }
    }
}
