using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform target;
    [HideInInspector] public NavMeshAgent agent;
    public Transform waypoints;
    private EnemyStateMachine stateMachine;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new EnemyStateMachine(agent, target, this);
        stateMachine.Initialize(stateMachine.patrolState);
    }

    void Update()
    {
        stateMachine.Update();
    }
    public bool CanSeePlayer()
    {
        Vector3 enemyFacing = transform.forward;
        Vector3 enemyPosition = transform.position;
        Vector3 enemyToPlayer = target.position - enemyPosition;
        Vector3 offset = Vector3.up * 0.01f;

        RaycastHit hit;
        if(Physics.Raycast(enemyPosition + offset, enemyToPlayer + offset, out hit, 10f))
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("Player"))
            {
                if(Vector3.Angle(enemyFacing, enemyToPlayer) <= 45f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
