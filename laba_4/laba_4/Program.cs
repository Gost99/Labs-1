using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace laba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 19748;
            Random rand = new Random();
            int[] Array1 = new int[size];
            for (int i = 0; i < size; i++)
            {
                Array1[i] = rand.Next(100);
            }
            int[] arr2 = new int[size];
            int[] arr3 = new int[size];

            Array.Copy(Array1, arr2, size);
            Array.Copy(Array1, arr3, size);

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
           
            BubbleSort(Array1);
            stopwatch1.Stop();
            Console.WriteLine("Bublesort's wasted time: {0}", stopwatch1.Elapsed);

            Stopwatch stopwatch2 = new Stopwatch();
            QuickSort qs = new QuickSort();
            stopwatch2.Start();
            qs.Sort_algo(arr2, 0, size - 1);
            stopwatch2.Stop();
            Console.WriteLine("Quicksort's wasted time: {0}", stopwatch2.Elapsed);

            Stopwatch stopwatch3 = new Stopwatch();
            HeapSort hs = new HeapSort();
            stopwatch3.Start();
            hs.PerformHeapSort(arr3);
            stopwatch3.Stop();
            Console.WriteLine("Heapsort's wasted time: {0}", stopwatch3.Elapsed);

            Console.ReadKey();

        }
        static void BubbleSort(int[] Array1)
        {
            for (int i = 0; i < Array1.Length; i++)
            {
                for (int j = 0; j < Array1.Length - i - 1; j++)
                {
                    if (Array1[j] > Array1[j + 1])
                    {
                        int temporary = Array1[j];
                        Array1[j] = Array1[j + 1];
                        Array1[j + 1] = temporary;
                    }
                }
            }
        }
    }

    class QuickSort
    {
        public void Sort_algo(int[] Array, int str, int end)
        {
            if (str >= end)
            {
                return;
            }
            int middle = partition(Array, str, end);
            Sort_algo(Array, str, middle - 1);              // рекурсивно виконуємо для лівої половини
            Sort_algo(Array, middle + 1, end);                // і для правої половини
        }
        private int partition(int[] Array, int start, int end)
        {
            int temporary;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (Array[i] < Array[end])
                {
                    temporary = Array[marker];
                    Array[marker] = Array[i];
                    Array[i] = temporary;
                    marker += 1;
                }
            }
            temporary = Array[marker];
            Array[marker] = Array[end];
            Array[end] = temporary;
            return marker;
        }
    }
    class HeapSort
    {
        private int SiZe;

        private void BuildHeap(int[] Array)
        {
            SiZe = Array.Length - 1;
            for (int i = SiZe / 2; i >= 0; i--)
            {
                H(Array, i);
            }
        }

        private void Swap(int[] Array, int x, int y)
        {
            int temporary = Array[x];
            Array[x] = Array[y];
            Array[y] = temporary;
        }
        private void H(int[] Array, int index)
        {
            int left = 2 * index;
            int right = 2 * index + 1;
            int largest = index;

            if (left <= SiZe && Array[left] > Array[index])
            {
                largest = left;
            }

            if (right <= SiZe && Array[right] > Array[largest])
            {
                largest = right;
            }
if (largest != index)
            {
                Swap(Array, index, largest);
                H(Array, largest);
    }
}
public void PerformHeapSort(int[] Array)
{
    BuildHeap(Array);
    for (int i = Array.Length - 1; i >= 0; i--)
    {
        Swap(Array, 0, i);
        SiZe--;
        H(Array, 0);
    }
}

    }
}