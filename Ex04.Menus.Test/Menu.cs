using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;
using System.Linq.Expressions;
namespace Ex04.Menus.Test
{
    internal class Menu
    {
        private List<Events.MenuItem> r_Items;
        private readonly MenuActions r_MenuActions;
        public Menu()
        {
            r_Items = new List<Events.MenuItem>();
            r_MenuActions = new MenuActions();
            BuildMenuItems();
            ShowMenu();
        }

        public void BuildMenuItems()
        {
            //todo : need to understand here the titles ***** 
            //todo: need to undrstand how to deal with childs and menu inside menu 
            //right now only words the basic 1,2 version and lower case 
            Events.MenuItem ShowVersionItem = new Events.MenuItem("Show Version",1);
            Events.MenuItem CountLowerCaseItem = new Events.MenuItem("Count Lowercase Letters",2);
            Events.MenuItem ShowCurrentDateOrTime = new Events.MenuItem("Show Current Date/Time",3);
            r_Items.Add(ShowVersionItem);
            r_Items.Add(CountLowerCaseItem);
            r_Items.Add(ShowCurrentDateOrTime);
            Events.MenuItem ShowCurrentDate = new Events.MenuItem("Show Current Date",1);
            Events.MenuItem ShowCurrentTime = new Events.MenuItem("Show Current Time",2);
            ShowVersionItem.ClickOccured += new ClickEventHandler(r_MenuActions.ShowVersion);
            CountLowerCaseItem.ClickOccured += new ClickEventHandler(r_MenuActions.ShowNumberOfLowerCaseLetters);
            ShowCurrentDate.ClickOccured += new ClickEventHandler(r_MenuActions.ShowCurrentDate);
            ShowCurrentTime.ClickOccured += new ClickEventHandler(r_MenuActions.ShowCurrentTime);
            //todo : need to understand what to do with the submenu (date/time)


        }
        public void  ShowMenu()
        {
            while(true)
            {
                Console.Clear();
                //add text for back 
                //add text for exit 
                foreach (Events.MenuItem currentMenuItem  in r_Items)
                {
                    Console.WriteLine($"{currentMenuItem.Id}. {currentMenuItem.ItemText}");
                }
                //todo: understand how to know if here we need to write back and not exit it will happen if we are in a submenu
                Console.WriteLine("0. Exit");
                Console.WriteLine($"Please enter your choice (1-{r_Items.Count} or 0 to exit):");
                string userChoise = Console.ReadLine();
                bool ableToParseUserChoise = int.TryParse(userChoise, out int userChoiseNumber);
                if(userChoiseNumber < 0 || !ableToParseUserChoise)
                {
                    Console.WriteLine("Invalid Choise Try Again");
                }
                else
                {
                    Events.MenuItem selectedItem = r_Items[userChoiseNumber-1];
                    selectedItem.Clicked();
                    break;
                }
            }
        }
    }
}
