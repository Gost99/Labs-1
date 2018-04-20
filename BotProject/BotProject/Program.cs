using System;
using System.Windows.Forms;

namespace BotProject
{
  //  public class Form1 : Form
   // {
        //public Form1()
        //{
        //    InitializeComponent();
        //}
   // }
    class Program
    {
        static void Main(string[] args)
        {

            Bank<Account> bank = new Bank<Account>("PrivateBank");
            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen; // выводим список команд зеленым цветом
                Console.WriteLine("1. Open raxunok \t 2. Get your money  \t 3. Add to your money");
                Console.WriteLine("4. Close your raxumok \t 5. Miss day \t 6. Exit from program");
                Console.WriteLine("Write the number:");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            OpenAccount(bank);
                            break;
                        case 2:
                            Withdraw(bank);
                            break;
                        case 3:
                            Put(bank);
                            break;
                        case 4:
                            CloseAccount(bank);
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    bank.CalculatePercentage();
                }
                catch (Exception ex)
                {
                    // выводим сообщение об ошибке красным цветом
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }

        private static void OpenAccount(Bank<Account> bank)
        {
            Console.WriteLine("Write the sum of your money:");

            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Chouse type of raxunok: 1. Plain 2. Deposit");
            AccountType accountType;

            int type = Convert.ToInt32(Console.ReadLine());

            if (type == 2)
                accountType = AccountType.Deposit;
            else
                accountType = AccountType.Ordinary;

            bank.Open(accountType,
                sum,
                AddSumHandler,  // обработчик добавления средств на счет
                WithdrawSumHandler, // обработчик вывода средств
                (o, e) => Console.WriteLine(e.Message), // обработчик начислений процентов в виде лямбда-выражения
                CloseAccountHandler, // обработчик закрытия счета
                OpenAccountHandler); // обработчик открытия счета
        }

        private static void Withdraw(Bank<Account> bank)
        {
            Console.WriteLine("Bag for withdrawal:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Write id of raxunok:");
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Withdraw(sum, id);
        }

        private static void Put(Bank<Account> bank)
        {
            Console.WriteLine("Write sum to add to your raxunok:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Write your id:");
            int id = Convert.ToInt32(Console.ReadLine());
            bank.Put(sum, id);
        }
        private static void CloseAccount(Bank<Account> bank)
        {
            Console.WriteLine("To close your raxunok enter your id:");
            int id = Convert.ToInt32(Console.ReadLine());

            bank.Close(id);
        }
        // обработчики событий класса Account
        // обработчик открытия счета
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик добавления денег на счет
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        // обработчик вывода средств
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
                Console.WriteLine("Good luck ");
        }
        // обработчик закрытия счета
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
// у разных банков должен быть или депозит или обы счет поля имя айди тип счета  , 