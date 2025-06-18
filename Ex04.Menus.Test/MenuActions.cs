using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class MenuActions:IMenuActions
    {
        public void ShowVersion()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
        }
        public void ShowNumberOfLowerCaseLetters()
        {
            string sentence = Console.ReadLine();
            int numberOfLower = 0;
            foreach(char currentChar in sentence)
            {
                if(char.IsLower(currentChar))
                {
                    numberOfLower++;
                }
            }
            Console.WriteLine($"> There are {numberOfLower} lowercase letters in you text");
        }
        public void ShowCurrentDate()
        {
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            Console.WriteLine($"The current date is {date}");
        }
        public void ShowCurrentTime()
        {
            string time = DateTime.Now.ToString("HH:mm");
            Console.WriteLine($"The current time is {time}");
        }
    }
}
