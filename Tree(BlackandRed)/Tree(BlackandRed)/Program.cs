using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_BlackandRed_
{
    public class Three
    {
        public Three parent;
        public int key;
        public Three left;
        public Three right;
        public int colour;
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
            insert(ref node1, 5);
            insert(ref node1, 452);
            insert(ref node1, 4345);
            insert(ref node1, 455);
            insert(ref node1, 445);
            void insert(ref Three node,int key)
            {
                if (node == null)
                {
                    node = new Three(key);
                    Console.WriteLine(key);
                    node.parent = null;
                    node.colour = 1;
                }
                else
                {
                    int current = 0;
                    while (node != null)
                    {
                        node.parent = node;
                        if (key < node.key)
                        {
                            current = node.key;
                            node = node.left;
                        }
                        else if (key > node.key)
                        {
                            current = node.key;
                            node = node.right;
                        }
                        else
                        {
                            return;
                        }
                    }
                    node.colour = 2;
                    if (key < current)
                    {
                        Console.WriteLine(key);
                        node = new Three(key);
                    }
                    else if (key > current)
                    {
                        Console.WriteLine(key);
                        node = new Three(key);
                    }
                    if (node.parent.colour==2)
                    {
                        Console.WriteLine("good");
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
