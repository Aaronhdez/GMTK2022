using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {
    public class Simple_BT : Tree {
        private INode _customRoot = null;

        public Simple_BT(INode root, GameObject agent) {
            _customRoot = root;
            _agent = agent;
        }

        protected override INode SetupTree() {
            if (_customRoot != null) {
                return _customRoot;
            }

            INode root = new Selector(new List<Node>() {
                new Sequence(new List<Node>() {
                }),
            });

            return root;
        }
    }
}
