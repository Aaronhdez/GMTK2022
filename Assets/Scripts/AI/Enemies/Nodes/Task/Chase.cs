using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{
    private GameObject _agent;
    private CharacterController _controller;

    public Chase(GameObject agent) {
        _agent = agent;
    }

    public override NodeState Evaluate() {
        _controller.Move();
        state = NodeState.RUNNING;
        return state;
    }
}
