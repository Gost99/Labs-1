using System;
namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[6] { 45, 31, 29, 21, 19, 7 };
            int[] array2 = new int[4000];
            int[] array3 = new int[1000];
            if(heap1(array1, array2, array3))
            Console.WriteLine("First func ");
            else
            heap(array1,array2,array3);
            Console.ReadKey();
        }
        static bool heap1(int[] array1, int[] array2, int[] array3)
        {
            int check = 0;
            int end = 0;
            int help = 0;
            int i;
            for (i=0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        if (k != j&&j!=i&&k!=i)
                        {
                            array2[help] = array1[k] + array1[j];
                         //   array3[help] = 0;
                            for (int y = 0; y < 6; y++)
                            {
                                if (array1[y]!=array1[k]&& array1[y] != array1[j]&& array1[y] != array1[i])
                                {
                                    array3[help] += array1[y];
                                }
                            }
                            help++;
                        }
                       // else

                    }
              
                }
                for (int u = 0; u < 10; u++) {
                    if (array1[i] > array2[u]||array1[i]>array3[u])
                    {
                        end = 1;
                        break;
                    }
                    else
                        end = 0;
          
                }
                if (end == 1) {
                    Console.WriteLine("Number are good : " + array1[i]);
                    check = 1;
            }
                help = 0;
            }
            if (check == 1)
                return true;
            else
                return false;
        }
        static void heap(int[] array1,int [] array2 , int [] array3)
        {
            int symon = 0;
            int first = 0;
            int second = 0;
            int third = 0;
            int n = 0;
            for (int i = first; i < 6; i++)
            {
                for (int gg = second; gg < 6; gg++)
                {
                    for (int j = third; j < 6; j++)
                    {
                        if (gg != j && gg != i && i != j)
                        {
                            n = array1[j] + array1[gg] + array1[i];
                            array2[0] = n;
                            for (int k = 1, q = 0; q < 6; q++)
                            {
                                if (array1[q] != array1[j] && array1[q] != array1[gg] && array1[q] != array1[i])
                                {
                                    array2[k] = array1[q];
                                    k++;
                                }
                            }
                            SearchMax(array2, array3, symon);
                            symon++;
                        }
                    }

                }
            }
        }
      static   void SearchMax(int[] arr,int[] finish,int symon)
        { int max = arr[0];
            for (int i = 0; i < 4; i++)
                if (arr[i] < arr[i + 1])
                    max = arr[i + 1];
          //  int iter = finish.Length + 1;
            finish[symon] = max;
           
            Finish(finish,symon);
        //    symon++;
        }
      static  void Finish(int [] finish,int symon)
        {
            int min = finish[0];
            for (int i = 0; i < symon; i++)
                if (finish[i] > finish[i + 1])
                    min = finish[i + 1];
            Console.Clear();
            Console.WriteLine(min);
        }
    }
}
