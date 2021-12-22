using NyamNyamMobileApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NyamNyamMobileApp.Views
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