using CarHupApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CarHupApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}