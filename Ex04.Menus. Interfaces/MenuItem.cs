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
        private readonly List<IMenuItemListener> m_MenuItemListeners;
        public List<MenuItem> m_SubItems { get; }
        public string Text;

        public MenuItem(string i_Text)
        {
            Text = i_Text;
            m_MenuItemListeners = new List<IMenuItemListener>();
            m_SubItems = new List<MenuItem>();
        }

        public void Clicked()
        {
            if (m_SubItems.Count > 0)
            {
                if (HasSubItems())
                {
                    Console.Clear();
                    MainMenu.ShowMenu(this);
                }
            }
            else
            {
                foreach (IMenuItemListener menuItemListener in m_MenuItemListeners)
                {
                    menuItemListener.ItemSelected();
                }
            }
        }

        public void AttachListener(IMenuItemListener menuItemListener)
        {
            m_MenuItemListeners.Add(menuItemListener);
        }

        public void DetachListener(IMenuItemListener menuItemListener)
        {
            m_MenuItemListeners.Remove(menuItemListener);
            //todo: maybe need to check if this item exists??? 
        }
        public bool HasSubItems()
        {
            return m_SubItems.Count > 0;
        }
    }
}
