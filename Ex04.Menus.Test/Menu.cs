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
        private readonly Events.MainMenu r_EventsMainMenu = new Events.MainMenu("** Delegates Main Menu **");
        private readonly Interfaces.MainMenu r_InterfacesMainMenu = new Interfaces.MainMenu("** Interfaces Main Menu **");
        private readonly MenuActions r_MenuActions;

        public Menu()
        {
            r_MenuActions = new MenuActions();
            buildMenuItemsEvents();
            buildMenuItemsInterface();
        }

        private void buildMenuItemsEvents()
        {


            Events.MenuItem wordCounterMenuItem = r_EventsMainMenu.CreateItem(MenuActions.k_CountLowercaseLetters);
            r_EventsMainMenu.AttachListener(wordCounterMenuItem, new ItemClickedEventHandler(r_MenuActions.MenuItemShowNumberOfLowerCaseLetters_Clicked));

            Events.MenuItem showVersionMenuItem = r_EventsMainMenu.CreateItem(MenuActions.k_ShowVersion);
            r_EventsMainMenu.AttachListener(showVersionMenuItem, new ItemClickedEventHandler(r_MenuActions.MenuItemShowVersion_Clicked));

            Events.MenuItem showCurrentTimeMenuItem = r_EventsMainMenu.CreateItem(MenuActions.k_ShowCurrentTime);
            r_EventsMainMenu.AttachListener(showCurrentTimeMenuItem, new ItemClickedEventHandler(r_MenuActions.MenuItemShowCurrentTime_Clicked));

            Events.MenuItem showCurrentDateMenuItem = r_EventsMainMenu.CreateItem(MenuActions.k_ShowCurrentDate);
            r_EventsMainMenu.AttachListener(showCurrentDateMenuItem, new ItemClickedEventHandler(r_MenuActions.MenuItemShowCurrentDate_Clicked));

            Events.MenuItem showCurrentDateOrTimeMenuItem = r_EventsMainMenu.CreateItem(MenuActions.k_ShowCurrentDateOrTime);
            r_EventsMainMenu.AddSubItem(showCurrentDateMenuItem, showCurrentDateOrTimeMenuItem);
            r_EventsMainMenu.AddSubItem(showCurrentTimeMenuItem, showCurrentDateOrTimeMenuItem);

            Events.MenuItem lettersAndVersionMenuItem = r_EventsMainMenu.CreateItem(MenuActions.k_LettersAndVersion);
            r_EventsMainMenu.AddSubItem(showVersionMenuItem, lettersAndVersionMenuItem);
            r_EventsMainMenu.AddSubItem(wordCounterMenuItem, lettersAndVersionMenuItem);

            r_EventsMainMenu.AddSubItem(lettersAndVersionMenuItem, r_EventsMainMenu.RootMenuItem);
            r_EventsMainMenu.AddSubItem(showCurrentDateOrTimeMenuItem, r_EventsMainMenu.RootMenuItem);

            r_EventsMainMenu.Show();    
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
