using System;
namespace turing_s_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("You would do math operation m*n + i : ");
            Console.Write("Please enter i,m,n: ");
            int y = 1;
            const int dem = 100;
            string[] array1 = new string[dem];
            long i = Convert.ToInt64(Console.ReadLine());
            long m = Convert.ToInt64(Console.ReadLine());
            long n = Convert.ToInt64(Console.ReadLine());
            long help = i;
            while (n > 1)
            {
                n = n / 10;
                y++;
            }
            y++;
            int op = 0;
            while (m > 1)
            {
                m = m / 10;
                op++;
            }
            op++;
            int z = 0;
            while (i > 1)
            {
                i = i / 10;
                z++;
            }
            z++;
            for (int d = 0; d < y; d++)
                array1[d] = "1";
            array1[y] = "0";
            array1[0] = "0";
            int gg = op + y;
            for (int d = 1 + y; d <= gg; d++)
                array1[d] = "1";
            for (int d = 0; d < dem; d++)
                if (array1[d] != "1" && array1[d] != "0")
                    array1[d] = "0";
            console();
            int symon = gg;
            while (gg > 1)
                switch (array1[gg])
                {
                    case "1":
                        array1[gg] = "1";
                        gg--;
                        break;
                    case "0":
                        array1[gg] = "*";
                        gg--;
                        break;
                }
            array1[1] = "b";
            array1[symon + 1] = "=";
            for (int wp = 0; wp < symon; wp++)
                if (array1[wp] == "*")
                    array1[wp + 1] = "b";
            gg = symon;
            int tsh = symon;
            int t = y;
            int u = t;
            while (gg - 1 > t) {
                symon = tsh;
                y = u;
                while (symon > 1) {
                    if (array1[symon] == "1")
                    {
                        array1[symon] = "a";
                        symon = 0;
                    }
                    symon--;
                }
                while (y > 2)
                {
                    if (array1[y - 1] == "1")
                        func();
                    y--;
                }
                gg--;
            }
            func();
            void func()
            {
                for (int d = gg + 1; d < dem; d++)
                    if (array1[d] == "0")
                    {
                        array1[d] = "1";
                        break;
                    }
            }
            void console()
            {
                foreach (string ss in array1)
                    Console.Write(ss);
                Console.WriteLine();
            }
            Console.WriteLine("Now we can see what happend when we multiply 2 digits ");
            console();
            int f = 0;
            if (help == 1)
            console();
            else
            {
                for (int d = tsh + 2; d < dem; d++)
                    if (array1[d] == "1")
                        f++;
                array1[tsh + f + 2] = "+";
                int he = tsh + f + 3;
                for (int d = he; d < he + z; d++)
                array1[d] = "1";
                array1[he + z] = "=";
                console();
                Console.WriteLine("Oh we can do it faster))");
                array1[he + z] = "0";
                array1[he + z - 1] = "0";
                array1[he + z - 2] = "0";
                array1[he - 1] = "1";
                console();
            }
                Console.WriteLine("Dont like letters like a,b? Okey");
                for (int d = tsh + 1; d > 0; d--)
                array1[d] = "0";
                console();
                Console.ReadKey();            
        }
    }
}
