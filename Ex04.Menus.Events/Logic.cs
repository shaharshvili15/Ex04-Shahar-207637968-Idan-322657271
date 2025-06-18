using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public static class Logic
    {
        public static void ShowSubMenu(MenuItem i_MenuItem)
        {
            while (true)
            {
                //Console.Clear();
                int userChoise = UserChoise(i_MenuItem.m_SubItems, i_MenuItem.ItemText,false);
                if (userChoise == 0)
                {
                    break;
                }
                else
                {
                    i_MenuItem.m_SubItems[userChoise-1].Clicked();
                }
            }
        }

        public static void ShowMenu(List<MenuItem> i_MenuItem, string i_ItemText)
        {
            while (true)
            {
                Console.Clear();
                int userChoise = UserChoise(i_MenuItem, i_ItemText);
                if (userChoise == 0)
                {
                    break;
                }
                else
                {
                    i_MenuItem[userChoise - 1].Clicked();
                }
            }
        }

        public static int UserChoise(List<MenuItem> i_Items,string i_ItemText, bool i_IsMainMenu = true)
        {
            while (true)
            {
                //Console.Clear();
                //add text for back 
                //add text for exit 
                Console.WriteLine(i_ItemText);
                Console.WriteLine("---------------");
                foreach (MenuItem currentMenuItem in i_Items)
                {
                    Console.WriteLine($"{i_Items.IndexOf(currentMenuItem) + 1}. {currentMenuItem.ItemText}");
                }
                //todo: understand how to know if here we need to write back and not exit it will happen if we are in a submenu
                if (i_IsMainMenu)
                {
                    Console.WriteLine("0. Exit");
                    Console.WriteLine($"Please enter your choice (1-{i_Items.Count} or 0 to exit):");
                }
                else
                {
                    Console.WriteLine("0. Back");
                    Console.WriteLine($"Please enter your choice (1-{i_Items.Count} or 0 to go back):");
                }
                string userChoise = Console.ReadLine();
                bool ableToParseUserChoise = int.TryParse(userChoise, out int userChoiseNumber);
                if (userChoiseNumber < 0 || !ableToParseUserChoise)
                {
                    Console.WriteLine("Invalid Choise Try Again");
                }
                else
                {
                    return userChoiseNumber;
                }
            }
        }
    }
}
