using System.Collections.Generic;

namespace BehaviourTree
{
    public class Sequence : Node
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in childern)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        nodeState = NodeState.FAILURE;
                        return nodeState;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        nodeState = NodeState.SUCCESS;
                        return nodeState;
                }
            }

            nodeState = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return nodeState;
        }

    }

}