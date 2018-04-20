using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackandRed
{
    public class RedBlackTree
    {

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode();
            //  TreeNode<int> root1 = new TreeNode<int>();
            tree.Inse(tree);
            rbtree.Search(130);
         //   rbtree.Write();
            Console.ReadKey();
        }
        //public interface IComparable
        //{
        //    int CompareTo(object o);
        //}

        class RedBlackTree1
        {
            public TreeNode Root { get; private set; }
            public int Size { get; private set; }

            public RedBlackTree1()
            {
                Root = null;
                Size = 0;
            }
            //ищет null , передаем новый лист и current лист
            public void Write(TreeNode node)
            {
                if (node == null)
                    return;
                Console.WriteLine("Left child " + node.LeftChild.Key + "And his color :" + node.LeftChild.Color);
                Console.WriteLine("Left child" + node.RightChild.Key + "And his color :" + node.RightChild.Color);
                Write(node.LeftChild);
                Write(node.RightChild);

            }
            private static TreeNode SearchNull(TreeNode current, TreeNode new1)
            {
                if (new1.Key.CompareTo(current.Key) < 0)   //текущий обьект перед тем который в дужках  (они сравнюют по ключу)
                {
                    if (current.LeftChild != null) return SearchNull(current.LeftChild, new1); 
                    new1.LeftChild = null;
                    new1.RightChild = null;
                    current.LeftChild = new1;
                    new1.Color = 1;          //RED
                    new1.Parent = current;
                    return new1;
                }
                if (current.RightChild != null) return SearchNull(current.RightChild, new1);
                new1.LeftChild = null;
                new1.RightChild = null;
                current.RightChild = new1;
                new1.Color = 1;
                new1.Parent = current;
                return new1;
            }

            private void LeftTurn(TreeNode node)
            {
                if (node.RightChild == null) return;
                var child = node.RightChild;
                node.RightChild = child.LeftChild;
                if (child.LeftChild != null) child.LeftChild.Parent = node;
                child.Parent = node.Parent;
                if (node.Parent == null) Root = child;
                else
                {
                    if (node == node.Parent.LeftChild)    //если K левый ребенок,то...
                        node.Parent.LeftChild = child;
                    else
                        node.Parent.RightChild = child;
                }
                child.LeftChild = node;
                node.Parent = child;
            }

            private void RightTurn(TreeNode node)
            {
                if (node.LeftChild == null) return;
                var child = node.LeftChild;
                node.LeftChild = child.RightChild;
                if (child.RightChild != null) child.RightChild.Parent = node;
                child.Parent = node.Parent;
                if (node.Parent == null) Root = child;
                else
                {
                    if (node == node.Parent.RightChild) node.Parent.RightChild = child;
                    else node.Parent.LeftChild = child;
                }
                child.RightChild = node;
                node.Parent = child;
            }

            public void Insert(TreeNode node)
            {
                if (Root == null)
                {
                    Root = node;
                    Root.Color = 0;
                    Root.LeftChild = null;
                    Root.RightChild = null;
                    Root.Parent = null;
                }
                else
                {
                    var addedNode = SearchNull(Root, node);
                    while (addedNode != Root && addedNode.Parent.Color == 1)
                    {
                        if (addedNode.Parent == addedNode.Parent.Parent.LeftChild)  // если нашло левый лист nil
                        {
                            var uncle = addedNode.Parent.Parent.RightChild;           // y - дядя
                            if (uncle != null && uncle.Color == 1)
                            {
                                addedNode.Parent.Color = 0;
                                uncle.Color = 0;
                                addedNode.Parent.Parent.Color = 1;
                                addedNode = addedNode.Parent.Parent;  
                            }
                            else                                                      //дядя черный
                            {
                                if (addedNode == addedNode.Parent.RightChild)
                                {
                                    addedNode = addedNode.Parent;
                                    LeftTurn(addedNode);
                                }
                                addedNode.Parent.Color = 0;
                                addedNode.Parent.Parent.Color = 1;
                                RightTurn(addedNode.Parent.Parent);
                            }
                        }
                        else
                        {
                            var y = addedNode.Parent.Parent.LeftChild;
                            if (y != null && y.Color == 1)
                            {
                                addedNode.Parent.Color = 0;
                                y.Color = 0;
                                addedNode.Parent.Parent.Color = 1;
                                addedNode = addedNode.Parent.Parent;
                            }
                            else
                            {
                                if (addedNode == addedNode.Parent.Parent.LeftChild)
                                {
                                    addedNode = addedNode.Parent;
                                    RightTurn(addedNode);
                                }
                                addedNode.Parent.Color = 0;
                                addedNode.Parent.Parent.Color = 1;
                                LeftTurn(addedNode.Parent.Parent);
                            }
                        }
                    }
                }
                Root.Color = 0;
            }

            private static TreeNode Min(TreeNode node)
            {
                while (node.LeftChild != null) node = node.LeftChild;
                return node;
            }

            private static TreeNode Next(TreeNode node)
            {
                if (node.RightChild != null) return Min(node.RightChild);
                var y = node.Parent;
                while (y != null && node == y.RightChild)
                {
                    node = y;
                    y = y.Parent;
                }
                return y;
            }

            private void FixUp(TreeNode node)
            {
                while (node != Root && node.Color == 0)
                {
                    if (node == node.Parent.LeftChild)
                    {
                        var w = node.Parent.RightChild;
                        if (w.Color == 1)
                        {
                            w.Color = 0;
                            node.Parent.Color = 1;
                            LeftTurn(node.Parent);
                            w = node.Parent.RightChild;
                        }
                        if (w.LeftChild.Color == 0 && w.RightChild.Color == 0)
                        {
                            w.Color = 1;
                            node = node.Parent;
                        }
                        else
                        {
                            if (w.RightChild.Color == 0)
                            {
                                w.LeftChild.Color = 0;
                                w.Color = 1;
                                RightTurn(w);
                                w = node.Parent.RightChild;
                            }
                            w.Color = node.Parent.Color;
                            node.Parent.Color = 0;
                            w.RightChild.Color = 0;
                            LeftTurn(node.Parent);
                            node = Root;
                        }
                    }
                    else
                    {
                        var w = node.Parent.LeftChild;
                        if (w.Color == 1)
                        {
                            w.Color = 0;
                            node.Parent.Color = 1;
                            RightTurn(node.Parent);
                            w = node.Parent.LeftChild;
                        }
                        if (w.RightChild.Color == 0 && w.LeftChild.Color == 0)
                        {
                            w.Color = 1;
                            node = node.Parent;
                        }
                        else
                        {
                            if (w.LeftChild.Color == 0)
                            {
                                w.RightChild.Color = 0;
                                w.Color = 1;
                                LeftTurn(w);
                                w = node.Parent.LeftChild;
                            }
                            w.Color = node.Parent.Color;
                            node.Parent.Color = 0;
                            w.LeftChild.Color = 0;
                            RightTurn(node.Parent);
                            node = Root;
                        }
                    }
                }
                node.Color = 0;
            }
            public void Delete(TreeNode node)
            {
                TreeNode y;
                if (node.LeftChild == null || node.RightChild == null)
                    y = node;
                else
                    y = Next(node);
                var x = y.LeftChild ?? y.RightChild;
                if (x == null)
                {
                    node.Key = y.Key;
                    if (y.Parent == null) return;
                    if (y.Parent.LeftChild == y) y.Parent.LeftChild = null;
                    else y.Parent.RightChild = null;
                    return;
                }
                x.Parent = y.Parent;
                if (y.Parent == null) Root = x;
                else
                {
                    if (y == y.Parent.LeftChild) y.Parent.LeftChild = x;
                    else y.Parent.RightChild = x;
                }
                if (y != node)
                {
                    node.Key = y.Key;
                }
                if (y.Color == 0) FixUp(x);
            }

            private static TreeNode SearchInSubTree(TreeNode topNode,int data)
            {
                if (data.Equals(topNode.Key))
                    return topNode;
                if (data.CompareTo(topNode.Key) < 0 && topNode.LeftChild != null)
                    return SearchInSubTree(topNode.LeftChild, data);
                if (data.CompareTo(topNode.Key) > 0 && topNode.RightChild != null)
                    return SearchInSubTree(topNode.RightChild, data);
                return null;
            }

            public bool Search(int data)
            {
                return SearchInSubTree(Root, data) != null;
            }

            public TreeNode SearchNode(int data)
            {
                return SearchInSubTree(Root, data);
            }
        }
    }
}
