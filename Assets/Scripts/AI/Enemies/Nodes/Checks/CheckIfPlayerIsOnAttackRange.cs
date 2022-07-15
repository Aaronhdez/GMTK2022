using BehaviorTree;
using UnityEngine;

public class CheckIfPlayerIsOnAttackRange : Node {

    private GameObject _agent;
    private CharacterController _controller;

    public CheckIfPlayerIsOnAttackRange(GameObject agent) {
        _agent = agent;
        _controller = agent.GetComponent<CharacterController>();
    }

    public override NodeState Evaluate() {
        var _player = GameObject.FindWithTag("Player").transform;

        if (Vector2.Distance(_player.position, _agent.transform.position) < 1) { 
            //_controller.GetAttackDistance()) {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }

}
