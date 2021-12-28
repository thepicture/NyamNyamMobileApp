using NyamNyamMobileApp.Views;
using Xamarin.Forms;

namespace NyamNyamMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OrderDishesPage), typeof(OrderDishesPage));
            Routing.RegisterRoute(nameof(OrderIngredientsPage), typeof(OrderIngredientsPage));
            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
        }
    }
}
