using CarHupApp.Models;
using CarHupApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHupApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

       
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

    }
}