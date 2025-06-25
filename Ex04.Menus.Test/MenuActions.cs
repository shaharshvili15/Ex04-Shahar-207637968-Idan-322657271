using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class MenuActions : IMenuActions
    {
        public const string k_CountLowercaseLetters = "Count Lowercase Letters";
        public const string k_ShowVersion = "Show Version";
        public const string k_ShowCurrentDate = "Show Current Date";
        public const string k_ShowCurrentTime = "Show Current Time";
        public const string k_ShowCurrentDateOrTime = "Show Current Date/Time";
        public const string k_LettersAndVersion = "Letters and Version";

        public void MenuItemShowVersion_Clicked()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
        }

        public void MenuItemShowNumberOfLowerCaseLetters_Clicked()
        {
            string sentence = Console.ReadLine();
            int numberOfLower = 0;
            foreach (char currentChar in sentence)
            {
                if (char.IsLower(currentChar))
                {
                    numberOfLower++;
                }
            }

            Console.WriteLine($"> There are {numberOfLower} lowercase letters in you text");
        }

        public void MenuItemShowCurrentDate_Clicked()
        {
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");

            Console.WriteLine($"The current date is {date}");
        }

        public void MenuItemShowCurrentTime_Clicked()
        {
            string time = DateTime.Now.ToString("HH:mm");

            Console.WriteLine($"The current time is {time}");
        }
    }
}