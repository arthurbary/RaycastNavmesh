using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine
{
    public IState CurrentState {get; private set;}
    public ChaseState chaseState;
    public EnemyStateMachine(NavMeshAgent agent, Transform playerTransform)
    {
        chaseState = new ChaseState(agent, playerTransform);
    }
    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }
    public void Update()
    {
        CurrentState?.Update();
    }
    public void TansitionTo(IState nextState)
    {
        CurrentState?.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }
}
