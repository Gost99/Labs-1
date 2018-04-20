using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_not_recursion_
{
    public class Three
    {
        public Three parent;
        public int key;
        public Three left;
        public Three right;
        public Three(int key)
        {
            this.key = key;
            left = right = null;
        }
    }
    class Program
    {
      static  public void insert(ref Three root, int x)
        {
          //  root.parent = null;
           // root.key = x;
            while (root != null)
            {
               root.parent = root;
                if (x < root.key)
                {
                    root = root.left;
                }
                else if (x > root.key)
                {
                    root = root.right;
                }
                else
                {
                    return;
                }
            }

            Three newNode = new Three(x);
            if (root.parent == null)
            {
                root = newNode;
            }
            else if (x < root.parent.key)
            {
                root.parent.left = newNode;
            }
            else if (x > root.parent.key)
            {
                root.parent.right = newNode;
            }
        }
       static void Main(string[] args)
        {
            Three root1 = null;
            insert(ref root1, 50);
            insert(ref root1, 60);
            insert(ref root1, 100);
            insert(ref root1, 44);

            Write(ref root1);
            void Write(ref Three root)
            {
                while (root != null)
                {
                    Write(ref root.left);
                    Console.Write(root.key + " ");
                    Write(ref root.right);
                }

            }
            Console.ReadKey();
        }

    }
}
 /*      
public void insertl(int x)
        {
           Node root = null;
            if (root == null)
            {
                root = new Node(x);
                return;
            }

            Node node = root;
            while (true)
            {
                if (x < node.key)
                {
                    if (node.left == null)
                    {
                        node.left = new Node(x);
                        return;
                    }
                    else
                    {
                        node = node.left;
                    }
                }
                else if (x > node.key)
                {
                    if (node.right == null)
                    {
                        node.right = new Node(x);
                        return;
                    }
                    else
                    {
                        node = node.right;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        class Check
        {
                 void insertk(int x)
                {
                    Node parent = null;
                    Node root = null; //
                    Node node = root;
                    while (node != null)
                    {
                        parent = node;
                        if (x < node.key)
                        {
                            node = node.left;
                        }
                        else if (x > node.key)
                        {
                            node = node.right;
                        }
                        else
                        {
                            return;
                        }
                    }

                    Node newNode = new Node(x);

                    if (parent == null)
                    {
                        root = newNode;
                    }
                    else if (x < parent.key)
                    {
                        parent.left = newNode;
                    }
                    else if (x > parent.key)
                    {
                        parent.right = newNode;
                    }
                }

            }
        }
    }
}
*/
