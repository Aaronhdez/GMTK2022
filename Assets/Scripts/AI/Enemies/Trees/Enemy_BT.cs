using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {
    public class Enemy_BT : Tree {
        private INode _customRoot = null;

        public Enemy_BT(INode root, GameObject agent) {
            _customRoot = root;
            _agent = agent;
        }

        protected override INode SetupTree() {
            if (_customRoot != null) {
                return _customRoot;
            }

            INode root = new Selector(new List<Node>() {
                new Sequence(new List<Node>() {
                    new CheckIfHealthIsZero(_agent),
                    new Die(_agent)
                }),
                new Sequence(new List<Node>() {
                    new CheckIfPlayerIsOnAttackRange(_agent),
                    new Attack(_agent)
                }),
                new Chase(_agent)
            }); 

            return root;
        }
    }
}
