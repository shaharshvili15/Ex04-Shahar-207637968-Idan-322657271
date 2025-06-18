using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public static class MainMenu
    {
        public static void ShowMenu(MenuItem i_MenuItem, bool i_IsMainMenu = false)
        {
            while (true)
            {
                int userChoise = UserChoise(i_MenuItem.m_SubItems, i_MenuItem.Text, i_IsMainMenu);
                if (userChoise == 0)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    i_MenuItem.m_SubItems[userChoise - 1].Clicked();
                }
            }
        }



        public static int UserChoise(List<MenuItem> i_Items, string i_ItemText, bool i_IsMainMenu )
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
                    Console.WriteLine($"{i_Items.IndexOf(currentMenuItem) + 1}. {currentMenuItem.Text}");
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
                Console.Write(">> ");
                string userChoise = Console.ReadLine();
                bool ableToParseUserChoise = int.TryParse(userChoise, out int userChoiseNumber);
                if (!ableToParseUserChoise)
                {
                    Console.WriteLine("Please enter a number");
                    continue;
                }
                if(userChoiseNumber < 0 || userChoiseNumber > i_Items.Count)
                {
                    Console.WriteLine($"Please enter a number in the range (1-{i_Items.Count} or 0 to go back)");
                }
                else
                {
                    return userChoiseNumber;
                }
            }
        }
    }
}
