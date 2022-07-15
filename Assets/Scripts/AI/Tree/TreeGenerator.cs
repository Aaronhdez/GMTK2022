using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree {
    public class TreeGenerator {
        Dictionary<string, ITree> treesAvaliable;

        public TreeGenerator(GameObject agent) {
            treesAvaliable = new Dictionary<string, ITree>();
            
            //V1
            treesAvaliable.Add("DummyBT_V1", null);
        }

        public ITree ConstructTreeFor(string treeToLoad) {
            return treesAvaliable[treeToLoad];
        }
    }
}