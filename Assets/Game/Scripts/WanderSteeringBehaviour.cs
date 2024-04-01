using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderSteeringBehaviour : SeekSteeringBehaviour
{
    public float wanderDistance = 2.0f;
    public float wanderRadius = 1.0f;
    public float wanderJitter = 20.0f;
    private Vector3 wanderTarget;

    private void Start()
    {
        float theta = (float)Random.value * Mathf.PI * 2;
        wanderTarget = new Vector3(wanderRadius * Mathf.Cos(theta), 
                                    0.0f, 
                                    wanderRadius * Mathf.Sin(theta));
    }

    public override Vector3 CalculateForce()
    {
        float wanderJitterTimeSlice = wanderJitter * Time.deltaTime;
        wanderTarget = wanderTarget + new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitterTimeSlice, 
                                                    0.0f, 
                                                    Random.Range(-1.0f, 1.0f) * wanderJitterTimeSlice);

        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        target = wanderTarget + new Vector3(0, 0, wanderDistance);
        target = steeringAgent.transform.rotation * target + steeringAgent.transform.position;

        return base.CalculateSeekForce();
    }

    protected override void OnDrawGizmos()
    {
        Vector3 circle = transform.rotation * new Vector3(0, 0, wanderDistance) + transform.position;
        DebugExtension.DrawCircle(circle, Vector3.up, Color.red, wanderRadius);
        Debug.DrawLine(transform.position, circle, Color.yellow);
        Debug.DrawLine(transform.position, target, Color.blue);
    }
}
