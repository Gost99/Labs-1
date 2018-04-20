using System;

namespace Turing2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the number in 1 system : ");
            int y = 0;
            const int n = 20;
            int[] Array1 = new int[n];
            int i = Convert.ToInt16(Console.ReadLine());
            int k = Convert.ToInt16(Console.ReadLine());
            for (int ind =0;ind<n;ind++)
            {
                if(Array1[ind]!=1)
                Array1[ind] = 0;
            }
            switch (Array1[y])
            {
                case 7:
                    Array1[y] = 6;
                    Array1[y - 1] += 1;
                    break;
                case 6:
                    Array1[y] = 5;
                    Array1[y - 1] += 1;
                    break;
                case 5:
                    Array1[y] = 4;
                    Array1[y - 1] += 1;
                    break;
                case 4:
                    Array1[y] = 3;
                    Array1[y - 1] += 1;
                    break;
                case 3:
                    Array1[y] = 2;
                    Array1[y - 1] += 1;
                    break;
                case 2:
                    Array1[y] = 1;
                    Array1[y - 1] += 1;
                    break;
                case 1:
                    Array1[y - 1] += 1;
                    Array1[y] = 0;
                    break;
                case 0:
                    Array1[y] = 7;
                    break;
            }
            foreach (int ss in Array1)
            {
                Console.Write(ss);
            }
            Console.ReadKey();
        }

    }
}
}
