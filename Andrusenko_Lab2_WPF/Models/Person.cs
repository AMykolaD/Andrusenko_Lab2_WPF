﻿using Andrusenko_Lab2_WPF.Tools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Andrusenko_Lab2_WPF
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsAdult { get; }
        public string SunSign { get; }
        public string ChineseSign { get; }
        public bool IsBirthday { get; }
        public Person(string name, string surname, string email, DateTime birthdate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthdate = birthdate;
            IsAdult = Age(birthdate) >= 18;
            SunSign = SunSignFromDate(birthdate);
            ChineseSign = ChineseSignFromDate(birthdate);
            IsBirthday = IsTodayBirthday(birthdate);
            try
            {
                new MailAddress(email);
            }
            catch
            {
                throw new InvalidEmailException("Email is invalid");
            }
            if (email.Contains(' ')) throw new InvalidEmailException("Email is invalid");
            if (Age(birthdate) >= 135) throw new TooOldException("You are older than the oldest human is");
            if (Age(birthdate) < 0) throw new BornInFutureException("You are born in the future");
        }
        public Person(string name, string surname, string email) : this(name, surname, email, DateTime.Now)
        {

        }
        public Person(string name, string surname, DateTime birthdate) : this(name, surname, "", birthdate)
        {

        }

        private static string SunSignFromDate(DateTime dateTime)
        {
            string sunSign = "";
            switch (dateTime.Month)
            {
                case 1:
                    sunSign = dateTime.Day < 20 ? "The Goat" : "The Water-bearer";
                    break;
                case 2:
                    sunSign = dateTime.Day < 19 ? "The Water-bearer" : "The Fish";
                    break;
                case 3:
                    sunSign = dateTime.Day < 21 ? "The Fish" : "The Ram";
                    break;
                case 4:
                    sunSign = dateTime.Day < 20 ? "The Ram" : "The Bull";
                    break;
                case 5:
                    sunSign = dateTime.Day < 21 ? "The Bull" : "The Twins";
                    break;
                case 6:
                    sunSign = dateTime.Day < 22 ? "The Twins" : "The Crab";
                    break;
                case 7:
                    sunSign = dateTime.Day < 23 ? "The Crab" : "The Lion";
                    break;
                case 8:
                    sunSign = dateTime.Day < 23 ? "The Lion" : "The Maiden";
                    break;
                case 9:
                    sunSign = dateTime.Day < 23 ? "The Maiden" : "The Scales";
                    break;
                case 10:
                    sunSign = dateTime.Day < 23 ? "The Scales" : "The Scorpion";
                    break;
                case 11:
                    sunSign = dateTime.Day < 23 ? "The Scorpion" : "The Archer (Centaur)";
                    break;
                case 12:
                    sunSign = dateTime.Day < 22 ? "The Archer (Centaur)" : "The Goat";
                    break;
                default: break;
            }
            return sunSign;
        }
        private static string ChineseSignFromDate(DateTime dateTime)
        {
            if (dateTime.Year < 1901 || dateTime.Year > 2100) return "";
            string chineseSign = "";
            DateTime chineseNewYearDate = new ChineseLunisolarCalendar().ToDateTime(dateTime.Year, 1, 1, 0, 0, 0, 0);
            int chineseYear = dateTime.Year - (dateTime.Month < chineseNewYearDate.Month ||
            dateTime.Month == chineseNewYearDate.Month &&
            dateTime.Day < chineseNewYearDate.Day ? 1 : 0);
            switch (chineseYear % 12)
            {
                case 0:
                    chineseSign = "Monkey";
                    break;
                case 1:
                    chineseSign = "Rooster";
                    break;
                case 2:
                    chineseSign = "Dog";
                    break;
                case 3:
                    chineseSign = "Pig";
                    break;
                case 4:
                    chineseSign = "Rat";
                    break;
                case 5:
                    chineseSign = "Ox";
                    break;
                case 6:
                    chineseSign = "Tiger";
                    break;
                case 7:
                    chineseSign = "Rabbit";
                    break;
                case 8:
                    chineseSign = "Dragon";
                    break;
                case 9:
                    chineseSign = "Snake";
                    break;
                case 10:
                    chineseSign = "Horse";
                    break;
                case 11:
                    chineseSign = "Goat";
                    break;
                default: break;
            }
            return chineseSign;
        }
        private static bool IsTodayBirthday(DateTime dateTime)
        {
            return (dateTime.Day==DateTime.Now.Day) && (dateTime.Month == DateTime.Now.Month);
        }
        public static int Age(DateTime dateTime)
        {
            int yearDifference;
            yearDifference = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now.Month < dateTime.Month ||
                DateTime.Now.Month == dateTime.Month &&
                DateTime.Now.Day < dateTime.Day) yearDifference--;
            return yearDifference;
        }
    }
}