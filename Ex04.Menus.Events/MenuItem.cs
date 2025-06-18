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
        public int Id { get; set; }
        public string ItemText { get; set; }
        public readonly List<MenuItem> m_SubItems = new List<MenuItem>();
        public event ClickEventHandler ClickOccured;
        public MenuItem(string i_ItemText, int i_Id)
        {
            ItemText = i_ItemText;
            Id = i_Id;
        }
        public void Clicked()
        {
            if (HasSubItems())
            {
                Logic.ShowSubMenu(this);
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
       /* public void nofifyParante()
        {
            m_ItemClickedDelegates?.Invoke(Id);
        }
        public void DoWhenClick()
        {
            //do here the function 
            nofifyParante();
        }*/


    }
}
