using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{

    class Program
    {
        static public BlackRedthree grandparent(ref BlackRedthree node)
        {
            if ((node != null) && (node.parent != null))
                return node.parent.parent;
            else
                return null;
        }
        static public BlackRedthree uncle(ref BlackRedthree node)
        {
           BlackRedthree node1 = grandparent(ref node);
            if (node == null)
                return null; // No grandparent means no uncle
            if (node.parent == node1.left)
                return node1.right;
            else
                return node1.left;
        }
        static public void leftturn(BlackRedthree node,int key)
{
    BlackRedthree rigthchild = node.right;
	
    rigthchild.parent = node.parent; /* при этом, возможно, rigthchild становится корнем дерева */
    if (node.parent != null) {
        if (node.parent.left==node)
            node.parent.left = rigthchild;
        else
            node.parent.right = rigthchild;
    }
    node.right = rigthchild.left;
    if (rigthchild.left != null)
        rigthchild.left.parent = node;

    node.parent = rigthchild;
    rigthchild.left = node;
   //         node = new BlackRedthree(key);
}
        static public void rightturn(BlackRedthree node,int key)
        {
            BlackRedthree leftchild = node.left;
            leftchild.parent = node.parent; /* при этом, возможно, rigthchild становится корнем дерева */
            if (node.parent != null)
            {
                if (node.parent.left == node)
                    node.parent.left = leftchild;
                else
                    node.parent.right = leftchild;
            }
            node.left = leftchild.right;
            if (leftchild.right != null)
                leftchild.right.parent = node;

            node.parent = leftchild;
            leftchild.right = node;
             //new BlackRedthree(key);
        }
        //static void Symon(BlackRedthree node,int key)
        //{
        //    insert_case1(node);
        //}
      static public void insert_case1( BlackRedthree node,int key)
    {
            if (node.parent == null)
            {
                node.Color = 0;
              //  node = new BlackRedthree(key);
            }
            else
                insert_case2(node, key);
    }
       static void insert_case2(BlackRedthree node,int key)
    {
            if (node.parent.Color == 0)
            {
           //     node = new BlackRedthree(key);
                return; /* Tree is still valid */
            }
            else
                insert_case3(node, key);
    }
       static void insert_case3(BlackRedthree node,int key)
{
         BlackRedthree node1 = uncle(ref node);
         BlackRedthree node2;

	if ((node1 != null) && (node1.Color == 1)) {
	// && (n->parent->color == RED) Второе условие проверяется в insert_case2, то есть родитель уже является красным.
		node.parent.Color = 0;
		node1.Color = 0;
		node2 = grandparent(ref node);
        node2.Color = 1;
                //node = new RBT(key);
        insert_case1(node2,key);
    } else {
        insert_case4(node,key);
    }
}
    static void insert_case4(BlackRedthree node,int key)
    {
     BlackRedthree node1 = grandparent(ref node);
	if ((node == node.parent.right) && (node.parent == node1.left)) {
        leftturn(node.parent,key);
        /*
		 * rotate_left может быть выполнен следующим образом, учитывая что уже есть *g =  grandparent(n) 
		 *
		 * struct node *saved_p=g->left, *saved_left_n=n->left;
		 * g->left=n; 
		 * n->left=saved_p;
		 * saved_p->right=saved_left_n;
		 * 
		 */
        node = node.left;
	} else if ((node == node.parent.left) && (node.parent == node1.right)) {

        rightturn(node.parent,key);
    /*
     * rotate_right может быть выполнен следующим образом, учитывая что уже есть *g =  grandparent(n) 
     *
     * struct node *saved_p=g->right, *saved_right_n=n->right;
     * g->right=n; 
     * n->right=saved_p;
     * saved_p->left=saved_right_n;
     * 
     */

    node = node.right;
	}
    insert_case5(node,key);
}
       static void insert_case5(BlackRedthree node,int key) { 
	BlackRedthree node1 = grandparent(ref node);
        node.parent.Color = 0;
	node1.Color = 1;
	if ((node == node.parent.left) && (node.parent == node1.left)) {
        rightturn(node1,key);
    } else { /* (n == n->parent->right) && (n->parent == g->right) */
                leftturn(node1,key);
           }
}
        static void write ( BlackRedthree node)
        {
            Console.WriteLine(node.key + "  " + node.Color);
            Console.WriteLine(node.parent.key + "  " + node.parent.Color);
            if (node.parent.left == node)
                write(node.parent);
           
        }
    static public void insert(ref BlackRedthree node,int key)
        {
            if (node.parent == null)
            {
                node.parent = null;
                node.left = null;
                node.right = null;
                node.Color = 0;       //black
            }
            else
            {

                //while (node != null)
                //{
                //     node.parent = node;
                //    if (key < node.key)
                //    {
                //        node = node.left;
                //    }
                //    else             // if (key > node.key)
                //    {
                //        node = node.right;
                //    }
                //}
                //BlackRedthree newNode = new BlackRedthree();


                //if (node.parent == null)
                //{
                //    node = newNode;
                //}
                //if (key < node.parent.key)
                //{
                //    Console.WriteLine(key);
                //    node.parent.left = newNode;
                //}
                //else      // if (key > node.parent.key)
                //{
                //    Console.WriteLine(key);
                //    node.parent.right = newNode;
                //}

            }
               // Console.WriteLine("gg");
        }
        static void Main(string[] args)
        {
            BlackRedthree root2 = new BlackRedthree();
            BlackRedthree root1 = new BlackRedthree();
            insert_case1(root1, 20);
            insert_case1(root1, 40);
            insert_case1(root1, 15);
            insert_case1(root1, 5);
            insert_case1(root1, 151);
            insert_case1(root1, 149);
            insert_case1(root1, 78);
            insert_case1(root1, 40);
            write( root1);
            // insert(ref root1, 40);
            // insert(ref root1, 50);
            //   insert(ref root1, 401);
            //     insert_case1(root2);



            Console.ReadKey();
        }
    }
}