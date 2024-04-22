using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
public class GoToTarget : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform [] targets;
    private int index = 0;
    private bool increasing;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        createAgentPath();
    }

    void SetDestination()
    {
        agent.SetDestination(targets[index].position);
    }
    void createAgentPath()
    {
        if(index < targets.Length)
        {
            if(agent.remainingDistance <= agent.stoppingDistance) 
            {
                if(index == targets.Length -1)
                {
                    increasing = false;
                }
                if(index == 0)
                {
                    increasing = true;
                }
                index = increasing ? index + 1 : index - 1;

                Debug.Log($"{index}/{targets.Length - 1} incrasing: {increasing}");
                SetDestination();
            }
        }
    }
}
