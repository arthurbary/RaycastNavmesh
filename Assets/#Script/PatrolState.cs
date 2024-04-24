using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IState
{
    private NavMeshAgent agent;
    private Transform waypoints;
    private Enemy  enemy;
    private EnemyStateMachine stateMachine;

    public PatrolState(Enemy enemy, EnemyStateMachine stateMachine)
    {
        agent = enemy.agent;
        waypoints = enemy.waypoints;
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }
    private void SelectDestination()
    {
        int numWaypoints = waypoints.childCount;
        int rdIndex = Random.Range(0, numWaypoints);
        Transform target = waypoints.GetChild(rdIndex);
        agent.SetDestination(target.position);
    }

    protected bool isAtDestinaytion{
        get{return agent.remainingDistance <= agent.stoppingDistance;}
    }
    public void Enter()
    {
        SelectDestination();
    }
    public void Update()
    {
        if(isAtDestinaytion)
        {
            SelectDestination();
        }
        if(enemy.CanSeePlayer())
        {
            stateMachine.TansitionTo(stateMachine.chaseState);
        }
    }
}