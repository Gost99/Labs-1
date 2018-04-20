using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
namespace ConsoleApp2
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class DoubleLinkedList<T>
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
    public class CircularLinkedList<T> : IEnumerable<T>  // кольцевой связный список
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
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }
    }
    class Program
    {
        public static void Main()
        {
            Random rand = new Random();
            int sum = 0;
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            //numbers.Insert(8, 9);
            //numbers.Insert(0, 0);
            //numbers.Insert(5, 54);
            //numbers.RemoveAt(0);
            //numbers.RemoveAt(9);
            //numbers.RemoveAt(4);
            //foreach (int i in numbers)
            //{
            //    sum += i;
            //}
            //Console.Write("The sum of elements: ");
            //Console.WriteLine(sum);
            //int z = 5;
            //foreach (int s in numbers)
            //{
            //    if (s == z)
            //    {
            //        Console.Write("Index of this element : ");
            //        Console.WriteLine(numbers.IndexOf(s));
            //    }
            //}
            const int n = 1000;
            int[] Array1 = new int[n];
            for (int kp = 0; kp < n; kp++)
            {
                Array1[kp] = rand.Next(100);
            }
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            for (int time = 8,mas=0; time < 1008; time++,mas++)
            {
                numbers.Insert(time, Array1[mas]);
            }
            stopwatch1.Stop();
            Console.WriteLine("Waisted time with insert in List : {0}", stopwatch1.Elapsed);
            /////////////////////////////////////////////////////////////
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            int zam = 0;
            for(int yay = 0;yay<1000;yay++)
            {               
                numbers.RemoveAt(zam);            //numbers.RemoveAll;
                numbers.Insert(zam,rand.Next(100));
                zam++;
            }
            stopwatch4.Stop();
            Console.WriteLine("Waisted time with substitute in List : {0}", stopwatch4.Elapsed);
            /////////////////////////////////////////////////////////////
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            foreach (int i in numbers)
            {
                sum += i;
            }
            Console.Write("The sum of elements: ");
            Console.WriteLine(sum);
            stopwatch2.Stop();
            Console.WriteLine("Waisted time with counting sum in List : {0}", stopwatch2.Elapsed);
            /////////////////////////////////////////////////////////////
            int z = rand.Next(100);
            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            int ident = 1;
            foreach (int ss in numbers)
            {  
                if (ss == z)
                {
                    Console.Write("The number (Index) for this elements : ");
                    Console.WriteLine(/*numbers.IndexOf(z)*/ident);
                }
                ident++;
            }
            stopwatch3.Stop();
            Console.WriteLine("Waisted time with finding index in List : {0}", stopwatch3.Elapsed);
            ////////////////////////////////////////////////////////////////
            int ll = 0;
            Stopwatch stopwatch5 = new Stopwatch();
            stopwatch5.Start();
           for(int s=0;s<1000;s++)
            {
                numbers.Remove(ll);
                ll++;
            }
            stopwatch5.Stop();
            Console.WriteLine("Waisted time with delete all elements in List : {0}", stopwatch5.Elapsed);
            /////////////////////////////////////////////////////////////
            LinkedList<int> num = new LinkedList<int>();
            const int j = 1000;
            int[] Array2 = new int[j];
            for (int kp = 0; kp < j; kp++)
            {
                Array2[kp] = rand.Next(100);
            }
            Stopwatch stopwatch6 = new Stopwatch();
            stopwatch6.Start();
            for (int time = 0; time < 1000; time++)
            {
                num.AddFirst(Array2[time]);
            }
            stopwatch6.Stop();
            Console.WriteLine("Waisted time with insert in DoubleLinkedList : {0}", stopwatch6.Elapsed);
            ///////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch7 = new Stopwatch();
            stopwatch7.Start();
            //int zamt = 0;
            for (int yay = 0; yay < 1000; yay++)
            {
                num.RemoveFirst();            //numbers.RemoveAll;
                num.AddFirst( rand.Next(100));
            }
            stopwatch7.Stop();
            Console.WriteLine("Waisted time with substitute in DoubleLinkedList : {0}", stopwatch7.Elapsed);
            ////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch8 = new Stopwatch();
            stopwatch8.Start();
            int inter = 0;
            foreach (int i in num)
            {
                inter += i;
            }
            Console.Write("The sum of elements in DoubleLinkedList: ");
            Console.WriteLine(inter);
            stopwatch8.Stop();
            Console.WriteLine("Waisted time with counting sum in DoubleLinkedList : {0}", stopwatch8.Elapsed);
            //////////////////////////////////////////////////////////////////////////
            int za = rand.Next(100);
            Stopwatch stopwatch9 = new Stopwatch();
            stopwatch9.Start();
            int id = 0;
            foreach (int s in num)
            {
                id++;
                if (s == za)
                {
                    Console.Write("The number (Index) for this elements : ");
                    Console.WriteLine(/*numbers.IndexOf(z)*/id);
                }
            }
            stopwatch9.Stop();
            Console.WriteLine("Waisted time with finding index in DoubleLinkedList : {0}", stopwatch9.Elapsed);
            ///////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch10 = new Stopwatch();
            stopwatch10.Start();
            for (int s = 0; s < 1000; s++)
            {
                num.RemoveFirst();
            }
            stopwatch10.Stop();
            Console.WriteLine("Waisted time with delete all elements in List : {0}", stopwatch10.Elapsed);
            //stopwatch6.Stop();
            //num.AddFirst(2);
            //num.AddFirst(4);
            //num.AddFirst(7);
            //num.AddFirst(7);
            //num.AddLast(1);
            //num.AddAfter(num.First, 3);
            //num.RemoveFirst();
            //num.RemoveLast();
            //num.Remove(3);
          //  int wtf = 0;
            //int iter = 0, search = 4;
            //foreach (int k in num)
            //{
            //    wtf += k;
            //    if (search == k)
            //    {
            //        Console.Write("Index of this number (Linked List): ");
            //        Console.WriteLine(++iter);
            //    }
            //    iter++;
            //}
          //  Console.Write("The sum of elements LinkedList: ");
          //  Console.WriteLine(wtf);
            /////////////////////////////////////////////////////////////////
            CircularLinkedList<string> circularList = new CircularLinkedList<string>();
            const int ns = 1000;
            int[] Array3 = new int[ns];
            for (int kp = 0; kp < n; kp++)
            {
                Array3[kp] = rand.Next(100);
            }
            Stopwatch stopwatch11 = new Stopwatch();
            stopwatch11.Start();
            for (int time = 0; time < 1000; time++)
            {
                var zs = Convert.ToString(Array3[time]);
                circularList.Add(zs);
            }
            stopwatch11.Stop();
            Console.WriteLine("Waisted time with insert in CircleDoubleLinkedList : {0}", stopwatch11.Elapsed);
            //////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch14 = new Stopwatch();
            stopwatch14.Start();
            for (int time = 0; time < 1000; time++)
            {
                var zs = Convert.ToString(Array3[time]);
                circularList.Delete();
                circularList.Add(zs);

            }
            stopwatch14.Stop();
            Console.WriteLine("Waisted time with substitushion in CircleDoubleLinkedList : {0}", stopwatch14.Elapsed);
            //////////////////////////////////////////////////////////////////////////
            int suma = 0;
            Stopwatch stopwatch12 = new Stopwatch();
            stopwatch12.Start();
            foreach (string yu in circularList)
            {               
                suma += Convert.ToInt16(yu);
            }
            stopwatch12.Stop();
            Console.WriteLine("Wasted time with counting the sum in CircleDoubleLinkedList : {0}", stopwatch12.Elapsed);
            ///////////////////////////////////////////////////////////////////////////
            var wp = Convert.ToString(rand.Next(100));
            int index = 0;
            Stopwatch stopwatch13 = new Stopwatch();
            stopwatch13.Start();
            foreach (string yu in circularList)
            {
                if (Convert.ToInt16(yu) == Convert.ToInt16(wp))
                {
                    Console.WriteLine("Circle Linked List : index of choosen element is : ");
                    Console.WriteLine(index);
                }
                else
                {
                    index++;
                }
            }
            stopwatch13.Stop();
            Console.WriteLine("Wasted time with finding index of elements in CircleDoubleLinkedList : {0}", stopwatch13.Elapsed);
            //////////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch15 = new Stopwatch();
            stopwatch15.Start();
            for (int time = 0; time < 1000; time++)
            {
                var zs = Convert.ToString(Array3[time]);
                circularList.Delete();
            }
            stopwatch15.Stop();
            Console.WriteLine("Waisted time to delete all elements in CircleDoubleLinkedList : {0}", stopwatch15.Elapsed);
            //circularList.Add("6");
            //circularList.Add("7");
            //circularList.Add("8");
            //circularList.Add("9");
            //circularList.Add("10");
            //circularList.Add("11");
            //circularList.Add("12");
            //circularList.Add("13");
            //circularList.Remove("6");       
            //circularList.First();
            //circularList.Remove("13");
            //circularList.Add_Last("1");
            //circularList.Remove("1");
            //  circularList.Add_First("78");
            //foreach (var item in circularList)
            //{
            //    Console.WriteLine(item);
            //}
            //  string wp  = "10";
            //int index = 0;
            //int suma = 0;
            //foreach (string yu in circularList)
            //{
            //    suma += Convert.ToInt16(yu);
            //    if (Convert.ToInt16(yu) == Convert.ToInt16(wp))
            //    {
            //        Console.WriteLine("Circle Linked List : index of choosen element is : ");
            //        Console.WriteLine(index);
            //    }
            //    else {
            //        index++;
            //    }              
            //}
            // Console.Write("Circle Linked List : suma : ");
            // Console.WriteLine(suma);
            Console.Clear();
            DoubleLinkedList<int> symon = new DoubleLinkedList<int>();






            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }       
    }
}