using System;
using System.IO;
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string readPath = @"C:\4TO-TO\ReadMe.txt";
            string writePath = @"C:\4TO-TO\ReadMe2.txt";
            string wp = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath))
                {
                    char[] c = null;
                        c = new char[60];
                    wp = sr.ReadToEnd();
                        Console.WriteLine(c);
                    using (StreamWriter sw = new StreamWriter(writePath))
                    {
                        int index = 0;
                        while (index<=wp.Length)
                        {
                            for (int i = index; i < index + 5; i++)
                                sw.Write(wp[i]);
                            for (int i = index + 10; i < index + 20; i++)
                                sw.Write(wp[i]);
                            for (int i = index + 5; i < index + 10; i++)
                                sw.Write(wp[i]);
                            for (int i = index + 20; i < index + 30; i++)
                                sw.Write(wp[i]);
                            index += 30;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
