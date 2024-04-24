using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform target;
    private NavMeshAgent agent;
    private EnemyStateMachine stateMachine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(agent, target);
        stateMachine.Initialize(stateMachine.chaseState);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
