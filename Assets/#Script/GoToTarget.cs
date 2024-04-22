using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
public class GoToTarget : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] protected Transform [] targets;
    protected int index = 0;
    protected bool increasing;
    protected bool isAtDestinaytion{
        get{return agent.remainingDistance <= agent.stoppingDistance;}
    }
    // Start is called before the first frame update
    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    // Update is called once per frame
    protected void Update()
    {
        if(isAtDestinaytion) 
        {
            NextDestination();
        }
    }

    protected void SetDestination()
    {
        agent.SetDestination(targets[index].position);
    }
    protected virtual void NextDestination()
    {
            if(index >= targets.Length -1)
            {
                increasing = false;
            }
            if(index <= 0)
            {
                increasing = true;
            }
            index = increasing ? index + 1 : index - 1;

            Debug.Log($"{index}/{targets.Length - 1} incrasing: {increasing}");
            SetDestination();
    }
}
