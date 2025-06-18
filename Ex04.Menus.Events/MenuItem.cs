using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public delegate void ClickEventHandler();
    public class MenuItem
    {
        public string ItemText { get; set; }
        public readonly List<MenuItem> m_SubItems = new List<MenuItem>();
        public event ClickEventHandler ClickOccured;
        public MenuItem(string i_ItemText)
        {
            ItemText = i_ItemText;
        }
        public void Clicked()
        {
            if (HasSubItems())
            {
                Console.Clear();
                MainMenu.ShowMenu(this);
            }
            else
            {
                OnClick();
            }
        }
        protected virtual void OnClick()
        {
            if(ClickOccured != null)
            {
                ClickOccured();
            }
        }
        public bool HasSubItems()
        {
            return m_SubItems.Count > 0;
        }
    }
}
