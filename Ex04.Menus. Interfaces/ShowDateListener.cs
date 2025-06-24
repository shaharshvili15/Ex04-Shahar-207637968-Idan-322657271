using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ShowDateListener : IMenuItemListener
    {
        private readonly IMenuActions r_IMenuActions;

        public ShowDateListener(IMenuActions i_MenuActions)
        {
            r_IMenuActions = i_MenuActions;
        }

        public void ItemSelected()
        {
            r_IMenuActions.MenuItemShowCurrentDate_Clicked();
        }
    }
}
