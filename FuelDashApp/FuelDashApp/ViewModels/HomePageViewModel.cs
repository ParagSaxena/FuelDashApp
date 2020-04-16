using System;
using System.Collections.Generic;
using System.Text;

namespace FuelDashApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private List<string> _items;
        public List<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertChanged(nameof(Items));
                }
            }
        }
        public HomePageViewModel()
        {
            Items = new List<string>()
            {
                "LABEL1", "LABEL2", "LABEL3", "LABEL4", "LABEL5", "LABEL6", "LABEL7", "LABEL8",
            };
            
        }
    }
}
