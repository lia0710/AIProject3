using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekInCircleSteeringBehaviour : SteeringBehaviourBase
{
    protected Vector3 desiredVelocity;
    public Vector3 center;
    public float radius;
    public float stoppingDistance = 0.1f;

    private void Start()
    { 
        target = GetRandomCirclePoint();
    }

    public override Vector3 CalculateForce()
    {
        //CheckMouseInput();


        return CalculateSeekForce();
    }

    private Vector3 GetRandomCirclePoint() 
    {
        Vector2 point = Random.insideUnitCircle * Random.Range(-radius, radius);
        point.x += center.x;
        point.y += center.z;
        return new Vector3(point.x, 0, point.y);
    }

    protected Vector3 CalculateSeekForce()
    {
        Vector3 toTarget = target - new Vector3(steeringAgent.transform.position.x, 0, steeringAgent.transform.position.z);


        float distance = toTarget.magnitude;
        steeringAgent.reachedGoal = false;

        if (distance < stoppingDistance)
        {
            steeringAgent.reachedGoal = true;
            return Vector3.zero;
        }

        desiredVelocity = (target - transform.position).normalized;
        desiredVelocity = desiredVelocity * steeringAgent.maxSpeed;
        return (desiredVelocity - steeringAgent.velocity);
    }

    protected virtual void OnDrawGizmos()
    {
        if (steeringAgent != null)
        {
            DebugExtension.DebugArrow(transform.position, desiredVelocity, Color.red);
            DebugExtension.DebugArrow(transform.position, steeringAgent.velocity, Color.blue);
        }

        DebugExtension.DebugPoint(target, Color.magenta);
    }
}
