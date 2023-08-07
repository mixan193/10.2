using _10._2;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._2
{
    public class Consultant : IGetClient, IChangeClient
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public Consultant()
        {
            Id = 1;
            Name = "Random name";
        }
        public virtual void Handler()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Вы консультант!");
                Console.WriteLine("Выберте действие:\r\n" +
                    "1. Просмотреть информацию о клиенте;\r\n" +
                    "2. Просмотреть всех клиентов\r\n");
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.D1:
                        ChooseAMethodToFind();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(GetAllClientsInStrings(ClientsDB.clients.ToArray()));
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Вы ничего не выбрали");
                        Console.ReadKey();
                        break;
                }
            }
        }

        protected void ChooseAMethodToFind()
        {
            Client client = null;
            Console.Clear();
            Console.WriteLine("Выберте действие:\r\n" +
                "1. Поиск по ФИО;\r\n" +
                "2. Поиск по ИД\r\n" +
                "3. Поиск по номеру телефона\r\n");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Введите ФИО через пробел");
                    string[] strings = Console.ReadLine().Split(new char[] { ' ' });
                    ClientsDB.GetClient(strings[0], strings[1], strings[2]);
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Введите ИД");
                    ClientsDB.GetClient(int.Parse(Console.ReadLine()));
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Введите номер телефона");
                    ClientsDB.GetClient(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Вы ничего не выбрали");
                    Console.ReadKey();
                    break;
            }
            if (client == null)
            {
                Console.WriteLine("Клиент не найден");
            }
            else
            {
                ChooseActionsWithClient(client);
            }
        }

        protected void ChooseActionsWithClient(Client client)
        {
            Console.Clear();
            Console.WriteLine(GetClientInString(client));
            Console.WriteLine("Выберте действие:\r\n" +
                "1. Изменить номер;\r\n" +
                "2. Выход\r\n");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.D1:
                    ChangeClient(client);
                    break;
                default:
                    break;
            }

        }

        public string GetClientInString(Client client)
        {
            if (client == null)
            {
                return "Такого клиента не существует";
            }
            else
            {
                string result = string.Empty;
                result += $"ИД: {client.id}\r\n";
                result += $"Фамилия: {client.surname}\r\n";
                result += $"Имя: {client.name}\r\n";
                result += $"Отчество: {client.patronimic}\r\n";
                result += $"Номер телефона: {client.phoneNumber}\r\n";
                if (client.seriesAndNumberOfThePassport != string.Empty)
                {
                    result += "Серия и номер паспорта: **********\r\n";
                }
                else
                {
                    result += "Серия и номер паспорта: отсутствует\r\n";
                }
                return result;
            }
        }
        public bool ChangeClient(Client client)
        {
            if (client == null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Введите новый номер: ");
                client.phoneNumber = Client.PhoneNumberUniformization(Console.ReadLine());
                return true;
            }
        }

        public string GetAllClientsInStrings(Client[] clients)
        {
            string result = string.Empty;
            foreach (Client client in clients)
            {
                result += GetClientInString(client);
            }
            if (result == string.Empty)
            {
                result += "Клиентов нет";
            }
            return result;
        }
    }
}
