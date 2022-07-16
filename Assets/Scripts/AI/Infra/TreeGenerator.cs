using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {
    public class TreeGenerator {
        Dictionary<string, ITree> treesAvaliable;

        public TreeGenerator(GameObject agent) {
            treesAvaliable = new Dictionary<string, ITree>();
            
            treesAvaliable.Add("Enemy_BT", new Enemy_BT(null, agent));
        }

        public ITree ConstructTreeFor(string treeToLoad) {
            return treesAvaliable[treeToLoad];
        }
    }
}