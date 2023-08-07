using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._2
{
    public static class ClientsDB
    {
        public static List<Client> clients = new List<Client>();
        public static int GetCount { get { return clients.Count; } }
        public static int AddClient(Client client)
        {
            clients.Add(client);
            return clients.Count;
        }
        /// <summary>
        /// Возвращает экземпляр класса Client по имени, фамилии и отчеству
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="name"></param>
        /// <param name="patronimic"></param>
        /// <returns></returns>
        public static Client GetClient(string surname, string name, string patronimic)
        {
            foreach (Client client in clients)
            {
                if (client.surname == surname)
                {
                    if (client.name == name)
                    {
                        if (client.patronimic == patronimic)
                        {
                            return client;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Возвращает экземпляр класса Client по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static Client GetClient(string phoneNumber)
        {
            foreach (Client client in clients)
            {
                if (client.phoneNumber == Client.PhoneNumberUniformization(phoneNumber))
                {
                    return client;
                }
            }
            return null;
        }
        /// <summary>
        /// Возвращает экземпляр класса Client по номеру ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Client GetClient(int id)
        {
            foreach (Client client in clients)
            {
                if (client.id == id)
                {
                    return client;
                }
            }
            return null;
        }

    }
}
