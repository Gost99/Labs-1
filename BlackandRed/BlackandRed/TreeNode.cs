using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackandRed
{
    class TreeNode
    {
        public int Key { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public int Color { get; set; }
        public TreeNode(int data)
        {
            Key = data;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }
        public TreeNode()
        {
            //  Key = key;
            Color = 1;
            Parent = null;
            LeftChild = null;
            RightChild = null;
        }
    }
}
