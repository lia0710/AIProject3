using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent3Controller : MonoBehaviour
{
    [SerializeField] private SeekInCircleSteeringBehaviour seek;
    [SerializeField] private WanderSteeringBehaviour wander;
    [SerializeField] private SteeringAgent agent;

    private State state = State.Seek;

    private enum State
    { 
        Seek,
        Wander
    }

    private void Update()
    {
        if (state == State.Seek)
        {
            seek.gameObject.SetActive(true);
            wander.gameObject.SetActive(false);
            if(agent.reachedGoal) 
            {
                state = State.Wander;
                wander.gameObject.SetActive(true);
                seek.gameObject.SetActive(false);
                agent.UpdateSteeringBehaviours();
                agent.reachedGoal = false;
            }
        }
        else if (state == State.Wander)
        {
            seek.gameObject.SetActive(false);
            wander.gameObject.SetActive(true);

            Vector3 dist = seek.steeringAgent.transform.position - seek.center;
            float distance = dist.magnitude;

            if (distance > seek.radius) 
            {
                state = State.Seek;
                wander.gameObject.SetActive(false);
                seek.gameObject.SetActive(true);
                agent.UpdateSteeringBehaviours();
            }
        }
    }
}
