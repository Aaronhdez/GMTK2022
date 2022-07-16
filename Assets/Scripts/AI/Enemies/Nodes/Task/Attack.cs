using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Node {

    private GameObject _agent;
    private CharacterController _controller;

    public Attack(GameObject agent) {
        _agent = agent;
        _controller = agent.GetComponent<CharacterController>();
    }

    public override NodeState Evaluate() {
        _controller.Attack();
        state = NodeState.RUNNING;
        return state;
    }
}
