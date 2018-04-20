using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
   public class DoubleLinkedList <T>
    {
        Node<T> head;
        Node<T> tail;
        int number;
        public void Add_First(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
        }
    }
}
