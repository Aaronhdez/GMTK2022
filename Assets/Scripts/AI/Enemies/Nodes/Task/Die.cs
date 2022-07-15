using BehaviorTree;
using System.Collections.Generic;
using UnityEngine;

public class Die : Node {
    private GameObject _agent;
    private CharacterController _controller;

    public Die(GameObject agent) {
        _agent = agent;
        _controller = agent.GetComponent<CharacterController>();
    }

    public override NodeState Evaluate() {
        _controller.Die();

        state = NodeState.RUNNING;
        return state;
    }
}
