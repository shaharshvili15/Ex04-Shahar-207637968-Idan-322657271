using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface IMenuActions
    {
        void MenuItemShowVersion_Clicked();
        void MenuItemShowNumberOfLowerCaseLetters_Clicked();
        void MenuItemShowCurrentDate_Clicked();
        void MenuItemShowCurrentTime_Clicked();
    }
}
