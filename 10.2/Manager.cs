using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._2
{
    internal class Manager : Consultant
    {
        public Manager()
        {
            Id = 2;
            Name = "Random name";
        }

        public override void Handler()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вы менеджер!");
                Console.WriteLine("Выберте действие:\r\n" +
                    "1. Просмотреть информацию о клиенте;\r\n" +
                    "2. Просмотреть всех клиентов\r\n" +
                    "3. Добавить клиента");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1:
                        ChooseAMethodToFind();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(GetAllClientsInStrings(ClientsDB.clients.ToArray()));
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        AddClient();
                        break;
                    default:
                        Console.WriteLine("Вы ничего не выбрали");
                        break;
                }
            }
        }
        protected void AddClient()
        {
            int id;
            string surname;
            string name;
            string patronimic;
            string phoneNumber;
            string seriesAndNumberOfThePassport;
            if(ClientsDB.clients.Count > 0)
            {
                id = ClientsDB.clients.Last().id + 1;
            }
            else
            {
                id = 1;
            }
            Console.CursorLeft = 0;
            Console.WriteLine("Введите фамилию: ");
            surname = Console.ReadLine();
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите отчество: ");
            patronimic = Console.ReadLine();
            Console.WriteLine("Введите номер телефона: ");
            phoneNumber =  Console.ReadLine();
            Console.WriteLine("Введите серию и номер паспорта: ");
            seriesAndNumberOfThePassport = Console.ReadLine();
            ClientsDB.AddClient(new Client(id, surname, name, patronimic, phoneNumber, seriesAndNumberOfThePassport));
            Console.WriteLine("Пользователь добавлен");
        }
    }
}
