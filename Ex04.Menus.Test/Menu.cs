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
        private readonly Events.MainMenu r_EventsMainMenu = new Events.MainMenu();
        private readonly Interfaces.MainMenu r_InterfacesMainMenu = new Interfaces.MainMenu();
        private readonly MenuActions r_MenuActions;

        public Menu()
        {
            r_MenuActions = new MenuActions();
            buildMenuItemsEvents();
            buildMenuItemsInterface();
        }

        private void buildMenuItemsEvents()
        {
            Events.MenuItem VersionOrLettersItem = new Events.MenuItem("Letters and Version");
            Events.MenuItem ShowCurrentDateOrTime = new Events.MenuItem("Show Current Date/Time");
            Events.MenuItem ShowVersionItem = new Events.MenuItem("Show Version");
            Events.MenuItem CountLowerCaseItem = new Events.MenuItem("Count Lowercase Letters");
            Events.MenuItem ShowCurrentDate = new Events.MenuItem("Show Current Date");
            Events.MenuItem ShowCurrentTime = new Events.MenuItem("Show Current Time");
            Events.MenuItem ShowMainMenu = new Events.MenuItem("** Delegates Main Menu **");

            ShowVersionItem.ItemClicked += new ItemClickedEventHandler(r_MenuActions.MenuItemShowVersion_Clicked);
            CountLowerCaseItem.ItemClicked += new ItemClickedEventHandler(r_MenuActions.MenuItemShowNumberOfLowerCaseLetters_Clicked);
            ShowCurrentDate.ItemClicked += new ItemClickedEventHandler(r_MenuActions.MenuItemShowCurrentDate_Clicked);
            ShowCurrentTime.ItemClicked += new ItemClickedEventHandler(r_MenuActions.MenuItemShowCurrentTime_Clicked);
            VersionOrLettersItem.AddSubItem(ShowVersionItem);
            VersionOrLettersItem.AddSubItem(CountLowerCaseItem);
            ShowCurrentDateOrTime.AddSubItem(ShowCurrentDate);
            ShowCurrentDateOrTime.AddSubItem(ShowCurrentTime);
            ShowMainMenu.AddSubItem(VersionOrLettersItem);
            ShowMainMenu.AddSubItem(ShowCurrentDateOrTime);
            r_EventsMainMenu.ShowMenu(ShowMainMenu,true);            
        }

        private void buildMenuItemsInterface()
        {
            Interfaces.MenuItem VersionOrLettersItem = new Interfaces.MenuItem("Letters and Version");
            Interfaces.MenuItem ShowCurrentDateOrTime = new Interfaces.MenuItem("Show Current Date/Time");
            Interfaces.MenuItem ShowVersionItem = new Interfaces.MenuItem("Show Version");
            Interfaces.MenuItem CountLowerCaseItem = new Interfaces.MenuItem("Count Lowercase Letters");
            Interfaces.MenuItem ShowCurrentDate = new Interfaces.MenuItem("Show Current Date");
            Interfaces.MenuItem ShowCurrentTime = new Interfaces.MenuItem("Show Current Time");
            Interfaces.MenuItem ShowMainMenu = new Interfaces.MenuItem("** Interface Main Menu **");
            ShowVersionListener VersionListener = new ShowVersionListener(r_MenuActions);
            ShowNumberOfLowerCaseListener CountLowerCaseListener = new ShowNumberOfLowerCaseListener(r_MenuActions);
            ShowDateListener ShowCurrentDateListener = new ShowDateListener(r_MenuActions);
            ShowTimeListener ShowCurrentTimeListener = new ShowTimeListener(r_MenuActions);

            ShowVersionItem.AttachListener(VersionListener);
            CountLowerCaseItem.AttachListener(CountLowerCaseListener);
            ShowCurrentDate.AttachListener(ShowCurrentDateListener);
            ShowCurrentTime.AttachListener(ShowCurrentTimeListener);
            VersionOrLettersItem.AddSubItem(ShowVersionItem);
            VersionOrLettersItem.AddSubItem(CountLowerCaseItem);
            ShowCurrentDateOrTime.AddSubItem(ShowCurrentDate);
            ShowCurrentDateOrTime.AddSubItem(ShowCurrentTime);
            ShowMainMenu.AddSubItem(VersionOrLettersItem);
            ShowMainMenu.AddSubItem(ShowCurrentDateOrTime);
            r_InterfacesMainMenu.ShowMenu(ShowMainMenu, true);
        }
    }
}
