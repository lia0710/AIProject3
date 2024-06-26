using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteeringBehaviour : SteeringBehaviourBase
{
    protected Vector3 desiredVelocity;
    public float stoppingDistance = 0.1f;

    public override Vector3 CalculateForce() 
    {
        CheckMouseInput();

        return CalculateSeekForce();
    }

    protected Vector3 CalculateSeekForce()
    {
        /*Vector3 toTarget = target - steeringAgent.transform.position;

        float distance = toTarget.magnitude;
        steeringAgent.reachedGoal = false;

        if (distance < stoppingDistance)
        {
            steeringAgent.reachedGoal = true;
            return Vector3.zero;
        }*/

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
