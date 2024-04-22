using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRandomTarget : GoToTarget
{
    protected override void NextDestination()
    {
        int newIndex = Random.Range(0, targets.Length);
        while(newIndex == index)
        {
            newIndex = Random.Range(0, targets.Length);
        }
        index = newIndex;
        SetDestination();
    }
}
