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
    private bool incrasing;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(index < targets.Length)
        {
            if(index == targets.Length - 1)
            {
                index = 0;
            }
            if(agent.remainingDistance <= agent.stoppingDistance) 
            {
                if(index == targets.Length - 1)
                {
                    incrasing = false;
                }
                if(index == 0)
                {
                    incrasing = true;
                }
                if(incrasing) 
                {
                    index++;
                }
                SetDestination();
            }
        }
    }

    void SetDestination()
    {
        agent.SetDestination(targets[index].position);
    }
}
