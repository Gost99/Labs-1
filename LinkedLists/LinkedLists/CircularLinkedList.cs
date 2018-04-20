using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    public class CircularLinkedList <T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
                    // добавление элемента
        public void Add_First(T data)
        {
            Node<T> node = new Node<T>(data);
            if (head != null)
            {
                node.Next.Next = head;
                tail.Next.Next = node;
                tail.Next = node;
            }
            count++;
        }
        public void Add_Last(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            tail.Next = node;
            tail = null;
            count++;
        }
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            // если список пуст
            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
        }
        public bool Delete()
        {
            Node<T> current = head;
            Node<T> previous = null;
            if (IsEmpty) return false;
            do
            {
                if (count == 1)
                {
                    head = tail = null;
                }
                else
                {
                    head = current.Next;
                    tail.Next = current.Next;
                }
                count--;
                return true;
                previous = current;
                current = current.Next;
            } while (current != head);
            return false;
        }
        //public bool Last()
        //{
        //    Node<T> current = head;
        //    Node<T> previous = null;
        //    if (IsEmpty) return false;
        //    do
        //    {
        //        if (previous != null)
        //        {
        //            previous.Next = current.Next;
        //            if (current == tail)
        //                tail = previous;
        //        }
        //        count--;
        //        return true;

        //        previous = current;
        //    current = current.Next;
        //} while (current != head);
        //    return false;
        //}
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            if (IsEmpty) return false;
            do
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
                        // Если узел последний,
                        // изменяем переменную tail
                        if (current == tail)
                            tail = previous;
                    }
                    else
                    {
                        if (count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);
            return false;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(T data)
        {
            Node<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }
    }
}
