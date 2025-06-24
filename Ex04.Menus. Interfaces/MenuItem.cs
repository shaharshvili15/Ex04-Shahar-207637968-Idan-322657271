using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly MainMenu r_MainMenu = new MainMenu();
        private readonly List<IMenuItemListener> r_MenuItemListeners;
        public List<MenuItem> SubItems { get; }
        public string ItemText { get; set; }

        public MenuItem(string i_Text)
        {
            ItemText = i_Text;
            r_MenuItemListeners = new List<IMenuItemListener>();
            SubItems = new List<MenuItem>();
        }

        public void Clicked()
        {
            if (SubItems.Count > 0)
            {
                if (HasSubItems())
                {
                    Console.Clear();
                    r_MainMenu.ShowMenu(this);
                }
            }
            else
            {
                foreach (IMenuItemListener menuItemListener in r_MenuItemListeners)
                {
                    menuItemListener.ItemSelected();
                }
            }
        }

        public void AttachListener(IMenuItemListener menuItemListener)
        {
            r_MenuItemListeners.Add(menuItemListener);
        }

        public void DetachListener(IMenuItemListener menuItemListener)
        {
            r_MenuItemListeners.Remove(menuItemListener);
        }

        public bool HasSubItems()
        {

            return SubItems.Count > 0;
        }

        public void AddSubItem(MenuItem i_ItemToAdd)
        {
            SubItems.Add(i_ItemToAdd);
        }
    }
}
