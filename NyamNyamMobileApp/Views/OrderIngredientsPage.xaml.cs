using NyamNyamMobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NyamNyamMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderIngredientsPage : ContentPage
    {
        private readonly OrderIngredientsViewModel _viewModel;
        public OrderIngredientsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new OrderIngredientsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}