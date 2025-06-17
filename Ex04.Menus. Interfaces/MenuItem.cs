using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        public string ItemText { get; set; }

        public MenuItem(string i_ItemText) 
        { 
            ItemText = i_ItemText;
        }
    }
}
