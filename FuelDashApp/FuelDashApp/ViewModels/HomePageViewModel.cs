using FuelDashApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    OnPropertyChanged(nameof(Items));
                }
            }
        }
        private ObservableCollection<MenuItems> _iconList = new ObservableCollection<MenuItems>();

        /// <summary>
        /// Gets or sets the icon list.
        /// </summary>
        /// <value>The icon list.</value>
        public ObservableCollection<MenuItems> IconList
        {
            get { return _iconList; }
            set
            {
                _iconList = value;
                OnPropertyChanged(nameof(IconList));
            }
        }
        public HomePageViewModel()
        {

            IconList.Add(new MenuItems { ImageSrc = "Inventory.png", Text = "JobSearch", GotoPage = "JobSearch" });
           // IconList.Add(new MenuItems { ImageSrc = "calibrations.png", Text = "GetReady", GotoPage = "GetReady" });
            IconList.Add(new MenuItems { ImageSrc = "Assets.png", Text = "MyDocument", GotoPage = "MyDocument" });
            IconList.Add(new MenuItems { ImageSrc = "Customers.png", Text = "Customers", GotoPage = "MyJobs" });
            IconList.Add(new MenuItems { ImageSrc = "Document.png", Text = "timeEntry", GotoPage = "timeEntry" });
            IconList.Add(new MenuItems { ImageSrc = "Invoice.png", Text = "MyStubs", GotoPage = "MyStubs" });
            IconList.Add(new MenuItems { ImageSrc = "ProductServices.png", Text = "MyStubs", GotoPage = "MyStubs" });
            IconList.Add(new MenuItems { ImageSrc = "Settings.png", Text = "MyStubs", GotoPage = "MyStubs" });
            IconList.Add(new MenuItems { ImageSrc = "Timesheets.png", Text = "MyStubs", GotoPage = "MyStubs" });


        }

        public async void GoToPage(MenuItems item)
        {
            //if (item.GotoPage == "JobSearch")
            //{
            //    string uri = "https://headway-workforce-solutions.jobs.net/en-US/";
            //    await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);

            //}
        }
        }
    }

