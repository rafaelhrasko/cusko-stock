using System.Collections.Generic;

namespace DOMSharp
{
    public class DOMNode
    {
        private static int NodeQuantity = 0;

        private int internalID;
        private DOMNode parent;
        private List<DOMNode> children;
        private List<DOMAttribute> attributes;
        private string _innerMsg;

        public int InternalId
        {
            get { return internalID; }
        }

        public DOMNode Parent
        {
            get { return parent; }
        }

        public List<DOMAttribute> Attributes
        {
            get { return attributes; }
        }

        public List<DOMNode> Children
        {
            get { return children; }
        }

        public string InnerMsg
        {
            get { return _innerMsg; }
            set { _innerMsg = value; }
        }

        private string _nodeName;

        public string Name
        {
            get { return _nodeName; }
        }

        public DOMNode()
        {
            children = new List<DOMNode>();
            attributes = new List<DOMAttribute>();
            internalID = DOMNode.NodeQuantity++;
        }

        public DOMNode(string nodeName_)
            :this()
        {
            this._nodeName = nodeName_;
        }


        internal DOMNode AddChild(string childName_)
        {
            DOMNode child = new DOMNode(childName_);
            child.parent = this;
            this.children.Add(child);
            return child;
        }

        public override string ToString()
        {
            return this.Name + ':' + this.internalID;
        }
    }
}