using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//вызывать функцию для нахождения налл и созданию new three instead of simply new tree
//вызвать функцию фикс для того случая когда мы смотрим на дядю и просто меняем ему цвет для случая
namespace Memoized
{
    class Program
    {
        static void Main(string[] args)
        {
            Three three1 = new Three();
            Insert(ref three1, 10);
            Insert(ref three1, 20);
            Insert(ref three1, 30);
            Insert(ref three1, 1);
            Insert(ref three1, 4);
            Insert(ref three1, 7);
            Insert(ref three1, 15);
            write( three1);
            Console.ReadKey();
        }

        static void write( Three node)
        {
            if (node == null)
            {
                Console.WriteLine("From root : " + node.key);
                return;
            }
            if (node.parent == null)
            {
                Console.WriteLine("From 2 or 3 : " + node.key);
                return;
            }
            Console.WriteLine("Left child " + node.left.key + "And his color :" + node.left.Color);
            Console.WriteLine("Left child" + node.right.key + "And his color :" + node.right.Color);
            write(node.left);
            write(node.right);
        }
        static public void FindNull( Three node, int key)
        {
            
            if (node.parent == null)
            {
                node.parent = node;
              //  node.parent.parent = null;
                node = new Three(key);
                Console.WriteLine("Created new node :" + key);
            }
//            else if(node.parent.parent == null)
    //        {
      //          node = new Three(key);
      //      }
            else
            {
                if (node.parent.left == node)
                    FindNull( node.left, key);
                else
                    FindNull( node.right, key);
            }
        }
        static public void insertt(ref Three node, int key)
        {
            node.parent = null;
            node.key = key;
            while (node != null)
            {
                node.parent = node;
                if (key < node.key)
                {
                    node = node.left;
                }
                else if (key > node.key)
                {
                    node = node.right;
                }
                else
                {
                    return;
                }
            }

            Three newNode = new Three(key);
            if (node.parent == null)
            {
                node = newNode;
            }
            else if (key < node.parent.key)
            {
                node.parent.left = newNode;
            }
            else if (key > node.parent.key)
            {
                node.parent.right = newNode;
            }
        }
        static public void Line(ref Three node)
        {
            if (node.parent.parent.right == node.parent) {  //  предок ноды правый
                node.parent.parent.left.left = node.parent.parent.left;   //c on place
                node.parent.parent.left = node.parent.parent;   //b on place
                node.parent.parent = node.parent;               // a on place
                node.parent.parent.left.right = null;        // d on place
                node.parent = node;             // z on place
                node.parent.parent.left.right.Color = 0;//colour d ok
                node.parent.parent.left.left.Color = 0;//color c ok
                node.parent.parent.left.Color = 1;//colour 
                node.parent.parent.Color = 0;
                node.parent.Color = 1;
                node.Color = 0;
            }
            else
            {
                node.parent.parent.right.right = node.parent.parent.right;   //c on place
                node.parent.parent.right = node.parent.parent;   //b on place
                node.parent.parent = node.parent;               // a on place
                node.parent.parent.right.left = null;        // d on place
                node.parent = node;             // z on place
                node.parent.parent.right.left.Color = 0;//colour d ok
                node.parent.parent.right.right.Color = 0;//color c ok
                node.parent.parent.right.Color = 1;//colour 
                node.parent.parent.Color = 0;
                node.parent.Color = 1;
                node.Color = 0;
            }
        }
        static public void Triangle(ref Three node)
        {
            if (node.parent.left == node && node.parent.parent.right == node.parent) //node left ,parent right
            {
                var temp = node;
                node.parent.right = node.parent;
                node.parent = temp;
                //maybe its nessecary to write null to node.parent.left and ...
                Line(ref node);
            }
            else if (node.parent.right == node && node.parent.parent.left == node.parent)
            {
                var temp = node;
                node.parent.left = node.parent;
                node.parent = temp;
                Line(ref node);
            }
            else
                Line(ref node);
        }
        static public Three Grandparent(ref Three node) => node.parent.parent;
        //{
        //        return node.parent.parent;
        //}
        static public Three Uncle(ref Three node)
        {
            if (node.parent.left == node)    //node - левый узел
                return node.parent.parent.right;
            return node.parent.parent.left;
        }
        static public void Сase1(ref Three node, int key)
        {
          //  if (node.parent == null)
                FindNull( node, key);
            //     else
            //   insert_case2(node, key);
        }
        static public void Case2(ref Three node, int key)
        {
            FindNull( node, key);
        }
        static public void Case3(ref Three node, int key)
        {
            if (node.parent.parent.left == node.parent)  // если родитель ноды левый
            {
                if (node.parent.parent.right.Color == 0)  // если дядя черный
                    Triangle(ref node);
                else
                {
                    node.parent.Color = 0;
                    node.parent.parent.Color = 1;
                    node.parent.parent.right.Color = 0;
                }
            }
            else                   // node - rigth
            {
                if (node.parent.parent.left.Color == 0)
                    Triangle(ref node);
                else
                {
                    node.parent.Color = 0;
                    node.parent.parent.Color = 1;
                    node.parent.parent.right.Color = 0;
                }
            }
            node = new Three(key);
        }
        static public void Case4(ref Three node, int key){
            FindNull( node, key);    
        }
        static void Insert(ref Three node,int key)
        {

            if (node.parent == null)
            {
                Сase1(ref node, key);
            }
            else if (node.parent.key == 10)
            {
                Case4(ref node, key);
            }
            else if (node.parent.Color == 0)
                Case2(ref node, key);
            else                           //if (node.parent.Color==1)
                Case3(ref node, key);
        }
    }
}
