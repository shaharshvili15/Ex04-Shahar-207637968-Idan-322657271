using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuLogic r_MenuLogic = new MenuLogic();
        public MenuItem RootMenuItem { get; private set; }

        public MainMenu(string text)
        {
            RootMenuItem = new MenuItem(text);
        }

        public MenuItem CreateItem(string i_Text)
        {
            MenuItem newMenuItem = new MenuItem(i_Text);
            return newMenuItem;
        }

        public void AddSubItem(MenuItem i_SubMenuItem, MenuItem i_ParentMenuItem)
        {
            i_ParentMenuItem.AddSubItem(i_SubMenuItem);
        }

        public void Show()
        {
            r_MenuLogic.ShowMenu(RootMenuItem, true);
        }

        public void AttachListener(MenuItem i_MenuItem, IMenuItemListener i_Listener)
        {
            i_MenuItem.AttachListener(i_Listener);
        }

        public void DetachListener(MenuItem i_MenuItem, IMenuItemListener i_Listener)
        {
            i_MenuItem.DetachListener(i_Listener);
        }

    }
}