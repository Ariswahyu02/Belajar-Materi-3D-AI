using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node root;

        protected void Start() {
            root = SetupTree();
        }

        protected void Update() {
            if(root != null)
            {
                root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }
}
