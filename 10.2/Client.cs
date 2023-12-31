﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10._2
{
    [Serializable]
    public class Client
    {
        public int id;
        public string surname;
        public string name;
        public string patronimic;
        public string phoneNumber;
        public string seriesAndNumberOfThePassport;
        public Client(int id, string surname, string name, string patronimic, string phoneNumber, string seriesAndNumberOfThePassport)
        {
            this.id = id;
            this.surname = surname;
            this.name = name;
            this.patronimic = patronimic;
            this.phoneNumber = PhoneNumberUniformization(phoneNumber);
            this.seriesAndNumberOfThePassport = seriesAndNumberOfThePassport;
        }

        public static string PhoneNumberUniformization(string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"[^\d]", "");
        }
    }
}
