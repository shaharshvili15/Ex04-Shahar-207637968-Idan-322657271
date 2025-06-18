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

    //HERE WE CREATE THE MENU AS WAS ASKED IN THE EXCERSISE 
    internal class Menu
    {
        private readonly MenuActions r_MenuActions;
        public Menu()
        {
            r_MenuActions = new MenuActions();
            //BuildMenuItemsEvents();
            BuildMenuItemsInterface();
        }

        public void BuildMenuItemsEvents()
        {
            //todo : need to understand here the titles ***** 
            //todo: need to undrstand how to deal with childs and menu inside menu 
            //right now only words the basic 1,2 version and lower case 
            Events.MenuItem VersionOrLettersItem = new Events.MenuItem("Letters and Version");
            Events.MenuItem ShowCurrentDateOrTime = new Events.MenuItem("Show Current Date/Time");

            Events.MenuItem ShowVersionItem = new Events.MenuItem("Show Version");
            Events.MenuItem CountLowerCaseItem = new Events.MenuItem("Count Lowercase Letters");


            Events.MenuItem ShowCurrentDate = new Events.MenuItem("Show Current Date");
            Events.MenuItem ShowCurrentTime = new Events.MenuItem("Show Current Time");

            Events.MenuItem ShowMainMenu = new Events.MenuItem("** Delegates Main Menu **");



            ShowVersionItem.ClickOccured += new ClickEventHandler(r_MenuActions.ShowVersion);
            CountLowerCaseItem.ClickOccured += new ClickEventHandler(r_MenuActions.ShowNumberOfLowerCaseLetters);
            ShowCurrentDate.ClickOccured += new ClickEventHandler(r_MenuActions.ShowCurrentDate);
            ShowCurrentTime.ClickOccured += new ClickEventHandler(r_MenuActions.ShowCurrentTime);

            VersionOrLettersItem.m_SubItems.Add(ShowVersionItem);
            VersionOrLettersItem.m_SubItems.Add(CountLowerCaseItem);
            

            ShowCurrentDateOrTime.m_SubItems.Add(ShowCurrentDate);
            ShowCurrentDateOrTime.m_SubItems.Add(ShowCurrentTime);

            ShowMainMenu.m_SubItems.Add(VersionOrLettersItem);
            ShowMainMenu.m_SubItems.Add(ShowCurrentDateOrTime);

            Events.MainMenu.ShowMenu(ShowMainMenu,true);

            
            //todo : need to understand what to do with the submenu (date/time)
        }
        public void BuildMenuItemsInterface()
        {
            Interfaces.MenuItem VersionOrLettersItem = new Interfaces.MenuItem("Letters and Version");
            Interfaces.MenuItem ShowCurrentDateOrTime = new Interfaces.MenuItem("Show Current Date/Time");

            Interfaces.MenuItem ShowVersionItem = new Interfaces.MenuItem("Show Version");
            Interfaces.MenuItem CountLowerCaseItem = new Interfaces.MenuItem("Count Lowercase Letters");
            ShowVersionListener VersionListener = new ShowVersionListener(r_MenuActions);
            ShowNumberOfLowerCaseListener CountLowerCaseListener = new ShowNumberOfLowerCaseListener(r_MenuActions);

            Interfaces.MenuItem ShowCurrentDate = new Interfaces.MenuItem("Show Current Date");
            Interfaces.MenuItem ShowCurrentTime = new Interfaces.MenuItem("Show Current Time");
            ShowDateListener ShowCurrentDateListener = new ShowDateListener(r_MenuActions);
            ShowTimeListener ShowCurrentTimeListener = new ShowTimeListener(r_MenuActions);


            Interfaces.MenuItem ShowMainMenu = new Interfaces.MenuItem("** Interface Main Menu **");

            ShowVersionItem.AttachListener(VersionListener);
            CountLowerCaseItem.AttachListener(CountLowerCaseListener);
            ShowCurrentDate.AttachListener(ShowCurrentDateListener);
            ShowCurrentTime.AttachListener(ShowCurrentTimeListener);

            VersionOrLettersItem.m_SubItems.Add(ShowVersionItem);
            VersionOrLettersItem.m_SubItems.Add(CountLowerCaseItem);

            ShowCurrentDateOrTime.m_SubItems.Add(ShowCurrentDate);
            ShowCurrentDateOrTime.m_SubItems.Add(ShowCurrentTime);

            ShowMainMenu.m_SubItems.Add(VersionOrLettersItem);
            ShowMainMenu.m_SubItems.Add(ShowCurrentDateOrTime);

            Interfaces.MainMenu.ShowMenu(ShowMainMenu, true);

        }
    }
}
