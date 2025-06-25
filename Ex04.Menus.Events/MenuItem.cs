using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public delegate void ItemClickedEventHandler();
    public class MenuItem
    {
        private readonly MenuLogic r_MenuLogic = new MenuLogic();
        public string ItemText { get; set; }
        public List<MenuItem> SubItems { get; } = new List<MenuItem>();
        public event ItemClickedEventHandler ItemClicked;

        public MenuItem(string i_ItemText)
        {
            ItemText = i_ItemText;
        }

        public void Clicked()
        {
            if (HasSubItems())
            {
                Console.Clear();
                r_MenuLogic.ShowMenu(this);
            }
            else
            {
                OnClick();
            }
        }

        protected virtual void OnClick()
        {
            if(ItemClicked != null)
            {
                ItemClicked();
            }
        }

        internal bool HasSubItems()
        {

            return SubItems.Count > 0;
        }

        public void AddSubItem(MenuItem i_ItemToAdd)
        {
            SubItems.Add(i_ItemToAdd);
        }

        public void AttachListener(ItemClickedEventHandler i_MenuItemEventHandler)
        {
            ItemClicked += i_MenuItemEventHandler;
        }
    }
}
