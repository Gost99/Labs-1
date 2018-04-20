using System;
using System.Collections.Generic;
namespace constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> numbers = new List<string>() { "mac", "kfc", "citypub", "Chelentano", "GreenHub", "NewYork street", "Domino" };
            //  numbers.Add(6); // добавление элемента
            // numbers.RemoveAt(1); //  удаляем второй элементO
            foreach (string i in numbers)
            {
                Console.WriteLine(i);
            }
        }
    }
}
