using CarHupApp.ViewModels;
using CarHupApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace CarHupApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Login();
        }
    }
}
