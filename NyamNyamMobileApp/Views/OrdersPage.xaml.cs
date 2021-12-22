using NyamNyamMobileApp.ViewModels;
using Xamarin.Forms;

namespace NyamNyamMobileApp.Views
{
    public partial class OrdersPage : ContentPage
    {
        OrdersViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new OrdersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}