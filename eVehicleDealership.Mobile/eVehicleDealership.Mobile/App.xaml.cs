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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjUwOTUxQDMxMzgyZTMxMmUzMEtOeml5K3g1SitTQ0hNdWdyVWRZS1hOcmRnQWM1b1dzWVQ0OVNxUTl4cTQ9");
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
