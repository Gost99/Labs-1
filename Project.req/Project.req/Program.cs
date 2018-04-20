using System;
using System.Collections.Generic;
using System.Threading;
namespace Project.req
{
    enum RequestStatus
    {
        вирiшений,
        невирiшений,
        невизначений
    }

    enum SpecialistStatus
    {
        free = 1,
        busy
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо список операторів. 
            var specList = CreateList();
            SupportRequest req1;
            Console.WriteLine("Доброго дня! Вас вiтає служба пiдтримки.");
            Console.WriteLine("Введiть своє iм'я: ");
            req1 = new SupportRequest(new Random().Next(1, 9999), Console.ReadLine(), RequestStatus.невизначений, GetSpecialist(specList));
            Console.WriteLine("Запис створено.");
            Console.WriteLine("Меню: \n");
            Console.WriteLine("1. Вiдправити повiдомлення");
            Console.WriteLine("2. Iнформацiя про запис");
            Console.WriteLine("0. Вихiд \n");
            int p = 0;
            do
            {
                p = Convert.ToInt32(Console.ReadLine());
                switch (p)
                {
                    case 1:
                        {
                            Console.WriteLine("Введiть текст повiдомлення: ");
                            req1.SendMessage(req1.UserName, req1.Specialist.Name, Console.ReadLine());
                            Console.WriteLine("Повiдомлення вiдправлено.");
                            Thread.Sleep(1500);
                            Console.WriteLine("Вашу проблему вирiшено? (+ або -) ");
                            string answer = Console.ReadLine();

                            if (answer == "-") req1.Status = RequestStatus.невирiшений;
                            else if (answer == "+") req1.Status = RequestStatus.вирiшений;
                            else req1.Status = RequestStatus.невизначений;
                            Menu();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine(req1);
                            Menu();
                            break;
                        }

                    case 0:
                        Console.WriteLine("Хорошого дня! \nЗакриття програми...");
                        break;
                    default:
                        Console.WriteLine("Неправильна кнопка.");
                        Menu();
                        break;

                }


            } while (p != 0);


            Console.ReadLine();
        }
        static List<SupportSpecialist> CreateList()
        {
            var specList = new List<SupportSpecialist> { };
            specList.Add(new SupportSpecialist("Максим", SpecialistStatus.free));
            specList.Add(new SupportSpecialist("Анатолiй", SpecialistStatus.busy));
            specList.Add(new SupportSpecialist("Дмитро", SpecialistStatus.free));
            specList.Add(new SupportSpecialist("Владислав", SpecialistStatus.busy));
            specList.Add(new SupportSpecialist("Оксана", SpecialistStatus.free));
            specList.Add(new SupportSpecialist("Вiкторiя", SpecialistStatus.busy));
            specList.Add(new SupportSpecialist("Олена", SpecialistStatus.free));
            specList.Add(new SupportSpecialist("Вiктор", SpecialistStatus.busy));
            specList.Add(new SupportSpecialist("Анна", SpecialistStatus.free));
            specList.Add(new SupportSpecialist("Олег", SpecialistStatus.busy));

            return specList;
        }
        static SupportSpecialist GetSpecialist(List<SupportSpecialist> list)
        {
            SupportSpecialist currentSpec = list.Find(x => x.Status == SpecialistStatus.free);
            currentSpec.Status = SpecialistStatus.busy;
            return currentSpec;
        }

        static void Menu()
        {
            Console.WriteLine("Для продовження натиснiть будь-яку клавiшу...");
            Console.ReadKey();
            Console.WriteLine("1. Вiдправити повiдомлення");
            Console.WriteLine("2. Iнформацiя про запис");
            Console.WriteLine("0. Вихiд \n");
        }
    }

    class SupportSpecialist
    {
        private string _specialistName;
        private SpecialistStatus _status;

        public string Name
        {
            set { _specialistName = value; }
            get { return _specialistName; }
        }

        public SpecialistStatus Status
        {
            set { _status = value; }
            get { return _status; }
        }

        public SupportSpecialist(string name)
        {
            this._specialistName = name;
            this._status = SpecialistStatus.free;
        }
        public SupportSpecialist(string name, SpecialistStatus status)
        {
            this._specialistName = name;
            this._status = status;
        }
        public override string ToString()
        {
            return this.Name;
        }

    }
    class SupportRequest
    {
        private int _id;
        private string _userName;
        private RequestStatus _status;
        private SupportSpecialist _specialist;
        private List<Message> _messageList;

        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        public string UserName
        {
            set { _userName = value; }
            get { return _userName; }
        }

        public RequestStatus Status
        {
            set { _status = value; }
            get { return _status; }
        }

        public SupportSpecialist Specialist
        {
            set { _specialist = value; }
            get { return _specialist; }
        }

        public List<Message> MessageList
        {
            set { _messageList = value; }
            get { return _messageList; }
        }

        public SupportRequest(int id, string userName, RequestStatus status, SupportSpecialist specialist)
        {
            this._id = id;
            this._userName = userName;
            this._status = status;
            this._specialist = specialist;
            this._messageList = new List<Message> { };
        }

        public override string ToString()
        {
            return "ID запису: " + this.ID + ". Користувач: " + this.UserName + ". Оператор: " + this.Specialist + ". Статус запису: " + this.Status + "\nIсторiя повiдомлень: \n" + GetMessageHistory();
        }

        public void SendMessage(string sender, string recepient, string text)
        {
            _messageList.Add(new Message(sender, recepient, text));
        }

        public string GetMessageHistory()
        {
            if (_messageList.Capacity == 0) return "Iсторiя порожня";
            else
            {
                string res = "";
                foreach (Message item in _messageList)
                {
                    res += item + "\n";
                }
                return res;
            }
        }
    }

    class Message
    {
        private string _sender;
        private string _recepient;
        private string _messageText;

        public string Sender
        {
            set { _sender = value; }
            get { return _sender; }
        }

        public string Recepient
        {
            set { _recepient = value; }
            get { return _recepient; }
        }
        public string MessageText
        {
            set { _messageText = value; }
            get { return _messageText; }
        }

        public Message(string sender, string recepient, string messageText)
        {
            this._sender = sender;
            this._recepient = recepient;
            this._messageText = messageText;
        }

        public override string ToString()
        {
            return "Вiдправник: " + this.Sender + ". Отримувач: оператор " + this.Recepient + ". Текст: " + this.MessageText;
        }
    }
}