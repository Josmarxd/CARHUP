using CarHupApp.Services;
using CarHupApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHupApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            // MainPage = new AppShell();
            MainPage = new Login();
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
