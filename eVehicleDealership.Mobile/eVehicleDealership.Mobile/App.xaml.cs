using eVehicleDealership.Mobile.Pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eVehicleDealership.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjY3ODI5QDMxMzgyZTMxMmUzME5sQS8yVjhWN2RzOUNpdm9RWFhOM3pmcFpWcDNKZC9wRnpvZDZOTFFhL0k9");
            InitializeComponent();
            //var accessToken = Preferences.Get("access_token", string.Empty);
            //if (string.IsNullOrEmpty(accessToken))
            //{
            MainPage = new NavigationPage(new LoginPage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new HomePage());
            //}
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
