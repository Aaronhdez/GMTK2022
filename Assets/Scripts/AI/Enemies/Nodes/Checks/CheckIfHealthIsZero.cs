using BehaviorTree;
using UnityEngine;

public class CheckIfHealthIsZero : Node {
    private GameObject _agent;
    private CharacterController _controller;

    public CheckIfHealthIsZero(GameObject agent) {
        _agent = agent;
        _controller = agent.GetComponent<CharacterController>();
    }

    public override NodeState Evaluate() {
        if (_controller.characterLife <= 0) {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
