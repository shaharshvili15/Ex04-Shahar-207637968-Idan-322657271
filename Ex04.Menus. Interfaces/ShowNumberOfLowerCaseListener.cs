using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ShowNumberOfLowerCaseListener : IMenuItemListener
    {
        public IMenuActions IMenuActions { get; set; }
        public ShowNumberOfLowerCaseListener(IMenuActions i_MenuActions)
        {
            IMenuActions = i_MenuActions;
        }
        public void ItemSelected()
        {
            IMenuActions.ShowNumberOfLowerCaseLetters();
        }
    }
}
