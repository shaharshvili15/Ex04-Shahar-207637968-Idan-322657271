using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ShowTimeListener : IMenuItemListener
    {
        public IMenuActions IMenuActions { get; set; }
        public ShowTimeListener(IMenuActions i_MenuActions)
        {
            IMenuActions = i_MenuActions;
        }
        public void ItemSelected()
        {
            IMenuActions.ShowCurrentTime();
        }
    }
}
