using NyamNyamMobileApp.Services;
using Xamarin.Forms;

namespace NyamNyamMobileApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<OrderDataStore>();
            DependencyService.Register<CookingStageDataStore>();
            DependencyService.Register<PopupDialogService>();
            MainPage = new AppShell();
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
