using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class MenuActions
    {
        //TODO: CREATE FUNCTION THAT SHOWS THE VERSION NUMBER
        public void ShowVersion()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
        }
        //TODO: CREATE FUNCTION THAT SHOWS NUMBER OF LOWER CASE LETTERS IN A STRING 
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
            Console.WriteLine($"There are {numberOfLower} lowercase letters in you text");
        }
        //TODO: CREATE FUNCTION THAT SHOWS THE CURRENT DATE
        public void ShowCurrentDate()
        {
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            Console.WriteLine($"The current date is {date}");
        }
        ///TODO: CREATE FUNCTION THAT SHOWS THE CURRENT TIME 
        public void ShowCurrentTime()
        {
            string time = DateTime.Now.ToString("HH:mm");
            Console.WriteLine($"The current time is {time}");
        }
    }
}
