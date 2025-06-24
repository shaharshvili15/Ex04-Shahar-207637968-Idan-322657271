using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        public void ShowMenu(MenuItem i_MenuItem, bool i_IsMainMenu = false)
        {
            while (true)
            {
                int userChoiseInput = userChoise(i_MenuItem.SubItems, i_MenuItem.ItemText, i_IsMainMenu);

                if (userChoiseInput == 0)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    i_MenuItem.SubItems[userChoiseInput - 1].Clicked();
                }
            }
        }

        private int userChoise(List<MenuItem> i_Items, string i_ItemText, bool i_IsMainMenu)
        {
            while (true)
            {
                Console.WriteLine(i_ItemText);
                Console.WriteLine("---------------");
                foreach (MenuItem currentMenuItem in i_Items)
                {
                    Console.WriteLine($"{i_Items.IndexOf(currentMenuItem) + 1}. {currentMenuItem.ItemText}");
                }

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

                if (userChoiseNumber < 0 || userChoiseNumber > i_Items.Count)
                {
                    if (i_IsMainMenu)
                    {
                        Console.WriteLine($"Please enter a number in the range (1-{i_Items.Count} or 0 to exit):");
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a number in the range (1-{i_Items.Count} or 0 to go back):");
                    }
                }
                else
                {

                    return userChoiseNumber;
                }
            }
        }
    }
}
