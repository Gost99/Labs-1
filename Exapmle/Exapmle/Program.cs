using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exapmle
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
            left = null; 
            right = null;
        }
    }
    class Program
    {                   
            static void Main(string[] args)
            {
                Three node1 = null;
                insert(ref node1,50);
                insert(ref node1,60);
                insert(ref node1,100);
                insert(ref node1,44);
             void insert(ref Three node,int x)
            {
                if (node == null)
                {
                    node = new Three(x);
                    Console.WriteLine(x);
                    node.parent = null;
                }
                else
                {
                    int current = 0;
                    while (node != null)
                    {
                         node.parent = node;
                        if (x < node.key)
                        {
                            current = node.key;
                            node = node.left;
                        }
                        else if (x > node.key)
                        {
                             current = node.key;
                            node = node.right;                    
                        }
                        else
                        {
                            return;
                        }
                    }
                     if (x < current)
                    {
                        Console.WriteLine(x);
                        node = new Three(x);
                    }
                    else if (x > current)
                    {
                        Console.WriteLine(x);
                        node = new Three(x);
                    }
                }
            }
            void Write(Three root)
                {
                    while (root != null)
                    {
                        Write( root.left);
                        Console.Write(root.key + " ");
                        Write(root.right);
                    }
                }
                Console.ReadKey();
            }
        }
}
