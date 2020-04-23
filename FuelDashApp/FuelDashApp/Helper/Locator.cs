using CommonServiceLocator;
using FuelDashApp.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace FuelDashApp.Helper
{
    public class Locator
    {
        public static IDevice Device;
        public const string GeneratePassCode = "GeneratePassCode";
        public const string HomePage = "HomePage";
        public const string SubMenu = "SubMenu";
        static Locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var navigation = new NavigationService();
            var resolverContainer = new SimpleContainer();
            navigation.Configure(Locator.GeneratePassCode, typeof(GenerateQRPage));
            navigation.Configure(Locator.HomePage, typeof(HomePage));
            navigation.Configure(Locator.SubMenu, typeof(SubMenu));
            SimpleIoc.Default.Register(() => navigation);
            resolverContainer.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            Resolver.SetResolver(resolverContainer.GetResolver());
            Device = Resolver.Resolve<IDevice>();
        }
        public NavigationService NavigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationService>();
            }
        }
    }
}
