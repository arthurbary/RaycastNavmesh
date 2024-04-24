using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    private NavMeshAgent agent;
    private Transform target;
    public ChaseState(NavMeshAgent navMeshAgent, Transform transform)
    {
        agent = navMeshAgent;
        target = transform;
    }
    public void Enter() 
    {
        Debug.Log("Entering Chase State");
    }
    public void Update() 
    {
        agent.SetDestination(target.position);
    }
    public void Exit() 
    {
        Debug.Log("Exit ChaseState");
    }

}
