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
        private List<Events.MenuItem> r_Items;
        private readonly MenuActions r_MenuActions;
        public Menu()
        {
            r_Items = new List<Events.MenuItem>();
            r_MenuActions = new MenuActions();
            BuildMenuItems();
            Logic.ShowMenu(r_Items, "** Delegates Main Menu **");
        }

        public void BuildMenuItems()
        {
            //todo : need to understand here the titles ***** 
            //todo: need to undrstand how to deal with childs and menu inside menu 
            //right now only words the basic 1,2 version and lower case 
            Events.MenuItem VersionOrLettersItem = new Events.MenuItem("Letters and Version", 1);
            Events.MenuItem ShowCurrentDateOrTime = new Events.MenuItem("Show Current Date/Time", 2);

            Events.MenuItem ShowVersionItem = new Events.MenuItem("Show Version", 1);
            Events.MenuItem CountLowerCaseItem = new Events.MenuItem("Count Lowercase Letters", 2);

            Events.MenuItem ShowCurrentDate = new Events.MenuItem("Show Current Date", 1);
            Events.MenuItem ShowCurrentTime = new Events.MenuItem("Show Current Time", 2);

            ShowVersionItem.ClickOccured += new ClickEventHandler(r_MenuActions.ShowVersion);
            CountLowerCaseItem.ClickOccured += new ClickEventHandler(r_MenuActions.ShowNumberOfLowerCaseLetters);
            ShowCurrentDate.ClickOccured += new ClickEventHandler(r_MenuActions.ShowCurrentDate);
            ShowCurrentTime.ClickOccured += new ClickEventHandler(r_MenuActions.ShowCurrentTime);

            VersionOrLettersItem.m_SubItems.Add(ShowVersionItem);
            VersionOrLettersItem.m_SubItems.Add(CountLowerCaseItem);

            ShowCurrentDateOrTime.m_SubItems.Add(ShowCurrentDate);
            ShowCurrentDateOrTime.m_SubItems.Add(ShowCurrentTime);

            r_Items.Add(VersionOrLettersItem);
            r_Items.Add(ShowCurrentDateOrTime);

            
            //todo : need to understand what to do with the submenu (date/time)
        }
    }
}
