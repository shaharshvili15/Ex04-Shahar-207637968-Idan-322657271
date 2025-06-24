using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ShowTimeListener : IMenuItemListener
    {
        private readonly IMenuActions r_IMenuActions;

        public ShowTimeListener(IMenuActions i_MenuActions)
        {
            r_IMenuActions = i_MenuActions;
        }

        public void ItemSelected()
        {
            r_IMenuActions.MenuItemShowCurrentTime_Clicked();
        }
    }
}
