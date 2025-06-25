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
        private readonly Interfaces.MainMenu r_InterfacesMainMenu = new Interfaces.MainMenu("** Interfaces Main Menu **");
        private readonly MenuActions r_MenuActions;

        public Menu()
        {
            r_MenuActions = new MenuActions();
            //buildMenuItemsEvents();
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
            Interfaces.MenuItem wordCounterMenuItem = r_InterfacesMainMenu.CreateItem(MenuActions.k_CountLowercaseLetters);
            r_InterfacesMainMenu.AttachListener(wordCounterMenuItem, new ShowNumberOfLowerCaseListener(r_MenuActions));

            Interfaces.MenuItem showVersionMenuItem = r_InterfacesMainMenu.CreateItem(MenuActions.k_ShowVersion);
            r_InterfacesMainMenu.AttachListener(showVersionMenuItem, new ShowVersionListener(r_MenuActions));

            Interfaces.MenuItem showCurrentTimeMenuItem = r_InterfacesMainMenu.CreateItem(MenuActions.k_ShowCurrentTime);
            r_InterfacesMainMenu.AttachListener(showCurrentTimeMenuItem, new ShowTimeListener(r_MenuActions));

            Interfaces.MenuItem showCurrentDateMenuItem = r_InterfacesMainMenu.CreateItem(MenuActions.k_ShowCurrentDate);
            r_InterfacesMainMenu.AttachListener(showCurrentDateMenuItem, new ShowDateListener(r_MenuActions));

            Interfaces.MenuItem showCurrentDateOrTimeMenuItem = r_InterfacesMainMenu.CreateItem(MenuActions.k_ShowCurrentDateOrTime);
            r_InterfacesMainMenu.AddSubItem(showCurrentDateMenuItem, showCurrentDateOrTimeMenuItem);
            r_InterfacesMainMenu.AddSubItem(showCurrentTimeMenuItem, showCurrentDateOrTimeMenuItem);

            Interfaces.MenuItem lettersAndVersionMenuItem = r_InterfacesMainMenu.CreateItem(MenuActions.k_LettersAndVersion);
            r_InterfacesMainMenu.AddSubItem(showVersionMenuItem, lettersAndVersionMenuItem);
            r_InterfacesMainMenu.AddSubItem(wordCounterMenuItem, lettersAndVersionMenuItem);

            r_InterfacesMainMenu.AddSubItem(lettersAndVersionMenuItem, r_InterfacesMainMenu.RootMenuItem);
            r_InterfacesMainMenu.AddSubItem(showCurrentDateOrTimeMenuItem, r_InterfacesMainMenu.RootMenuItem);

            r_InterfacesMainMenu.Show();
        }
    }
}
