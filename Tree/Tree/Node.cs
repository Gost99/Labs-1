using System;
using System.Diagnostics;
namespace Tree
{
    public class Three
    {
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
        public static void add(ref Three node, int key)
        {
            if (node == null)
                node = new Three(key);
            else
            {
                if (key < node.key)
                    add(ref node.left, key);
                else
                    if (key > node.key)
                    add(ref node.right, key);
            }
        }
        public static void Write(Three node)
        {
            if (node != null)
            {
                Write(node.left);
                Console.Write(node.key + " ");
                Write(node.right);
            }
        }
        public static Three searchElem(Three node, int key)
        {
            if (node != null)
            {
                if (key == node.key)
                {
                    return node;
                }
                else
                    if (key < node.key)
                    return searchElem(node.left, key);
                else
                    return searchElem(node.right, key);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Sorry, but we not found your element ( ");
            }
                return node;
        }
        public static void FindMax(ref Three node)
        {
            if (node.right != null)
                 FindMax(ref node.right);
            else
            {
                Write(node);
            }
        }
        public static int DeleteMax(ref Three node)
        {
            if (node.right != null)
            {
                return DeleteMax(ref node.right);
            }
            else
            {
                Three tmp = node;
                node = node.left;
                int res = tmp.key;
                tmp.left = null;
                return res;
            }
        }
        public static void FindMin(ref Three node)
        {
            if (node.left != null)
                FindMin(ref node.left);
            else
            {
                Console.WriteLine(node.key);
            }
        }
        public static void deleteNode(ref Three proot, int pkey)
        {
            if (proot != null)
            {
                if (proot.key < pkey)
                    deleteNode(ref proot.right, pkey);
                else
                    if (proot.key > pkey)
                    deleteNode(ref proot.left, pkey);
                else
                        if (proot.left == null && proot.right == null)
                    proot = null;
                else
                            if (proot.left == null)
                {
                    Three tmp = proot;
                    proot = tmp.right;
                    tmp.right = null;
                }
                else
                                if (proot.right == null)
                {
                    Three tmp = proot;
                    proot = tmp.left;
                    tmp.left = null;
                }
                else 
                    proot.key = DeleteMax(ref proot.left);
            }
        }
        public static Three createTree(int[] pv, ref Three proot)
        {
            for (int i = 0; i < pv.Length; i++)
            {
                Console.Write(pv[i] + " ");
                add(ref proot, pv[i]);
            }
            return proot;
        }
//////////////////////////////////////////////////
        static void Main(string[] args)
        {
            try { 
                Three root1 = null;
                add(ref root1,150);
                add(ref root1, 100);
                add(ref root1, 140);
                add(ref root1, 180);
                add(ref root1, 160);
                add(ref root1, 170);
                add(ref root1, 190);
                Write(root1);
                searchElem(root1, 140);
                searchElem(root1, 200);
                FindMax(ref root1);
                FindMin(ref root1);
                deleteNode(ref root1, 100);
                Write(root1);
                ////////////////////////////////////////////////////////////////////////////////////////////////
                Three root2 = null;
                Three root3 = null;
                Random rand = new Random();
                const int ns = 4000;
                int[] Array3 = new int[ns];
                for (int kp = 0; kp < ns; kp++)
                {
                    Array3[kp] = rand.Next(1000);
                }
                Stopwatch stopwatch2 = new Stopwatch();
                stopwatch2.Start();
                for (int i = 0; i < 4000; i++)
                    add(ref root2, Array3[i]);
                stopwatch2.Stop();
                Console.WriteLine();
                Console.WriteLine("Time elapsed with writing into tree : {0}", stopwatch2.Elapsed);
                Stopwatch stopwatch3 = new Stopwatch();
                stopwatch3.Start();
                for (int i = 0; i < 4000; i++)
                    add(ref root3, i);
                stopwatch3.Stop();
                Console.WriteLine("Time elapsed with writing into tree numbers 1,2,3,...,4000: {0}", stopwatch3.Elapsed);
                Stopwatch stopwatch4 = new Stopwatch();
                stopwatch4.Start();
                for (int i = 0; i < 4000; i++)
                    searchElem(root3, i);
                stopwatch4.Stop();
                Console.WriteLine("Time elapsed with search elements from tree : {0}", stopwatch4.Elapsed);
                Stopwatch stopwatch5 = new Stopwatch();
                stopwatch5.Start();
                for (int i = 0; i < 4000; i++)
                    deleteNode(ref root3, i);
                stopwatch5.Stop();
                Console.WriteLine("Time elapsed with delete elements from tree: {0}", stopwatch5.Elapsed);
                Write(root3);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
            }
        }
    }
}
