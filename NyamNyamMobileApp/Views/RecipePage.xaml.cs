
using NyamNyamMobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NyamNyamMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        private readonly RecipeViewModel _viewModel;

        public RecipePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new RecipeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}