using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IState
{
    private NavMeshAgent agent;
    private Transform target;
    private Enemy enemy;
    private EnemyStateMachine stateMachine;
    public ChaseState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        agent = enemy.agent;
        target = enemy.target;
    }
    public void Enter() 
    {
        Debug.Log("Entering Chase State");
    }
    public void Update() 
    {
        agent.SetDestination(target.position);
        if(!enemy.CanSeePlayer())
        {
            stateMachine.TansitionTo(stateMachine.patrolState);
        }
    }
    public void Exit() 
    {
        Debug.Log("Exit ChaseState");
    }

}
