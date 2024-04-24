using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IState
{
    public void Enter() {}
    public void Update() {}
    public void Exit() {}
}