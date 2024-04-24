using UnityEngine;
using UnityEngine.AI;

public class PatrolState : IState
{
    private NavMeshAgent agent;

    public PatrolState(NavMeshAgent navMeshAgent)
    {
        agent = navMeshAgent;
    }
    private void SelectDestination()
    {

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
    }
}