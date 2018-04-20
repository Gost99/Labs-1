using System;
namespace TA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter x : ");
            int sy = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter y:");
            int yg = Convert.ToInt32(Console.ReadLine());
                        int O(int x) => 0;
            int S(int x) => x + 1;
            int Arr(int[] arr, int m) => m;
            //Realized of superposition
            int[] Func1(int[] arr) => arr;                               //передаем массив аргументов и возвращаем его
            int[] func(int[] arr)=> Func1(arr);                          //передаем масив функций и вернем его
            int[] Superposition(int[] arr)=>func(arr);                   //передаем масив и функцию - вернет функцию
            //Realized of reqursion
            int[] req(int[] arr, int y) =>Func1(arr);
            int req2(int[] arr, int func2) =>func2;
//Realized of adding
            int add(int x, int y) => S(x+y-1);
            int g1 = add(sy, O(sy));
            int h1 = add(sy, S(yg));
            if (S(add(sy, yg)) == h1)
                Console.WriteLine("So now we know that add of x and y is primitive reqursion");
            //Realized of -
            int minus(int x, int y) => x > y ? S(x - y - 1) : 0;
            int g2 = minus(sy, O(yg));
            int h2 = minus(sy, S(yg));
            if (h2 == 0)
                h2 = O(sy);
            if (h2  == minus(sy, S(yg-1)))
                Console.WriteLine("Minus working))");
                        int multiply1(int x, int y) =>S(x*y-1);
            int res =  multiply1(sy, O(sy));
            int Module2(int x, int y) => x >= y ? minus(x, y) : minus(y, x);
            int Min2(int x, int y) => x >= y ? y : x;
            Console.WriteLine("From program : " + add(Module2(sy, yg), Min2(sy, yg)));
            int Min(int x, int y) => x > y ? y : x;
            int Absminus(int x, int y) => x > y ? x - y : y - x;
            int Add(int n1, int n2) => n1 + n2;
            Console.WriteLine("From calculator : "+ Add(Min(sy, yg), Absminus(sy, yg)));
            Console.ReadKey();
        }
    }
}
