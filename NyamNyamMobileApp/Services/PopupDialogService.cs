using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    class PopupDialogService : IDialogService
    {
        public async Task ShowError(string message)
        {
            await App.Current.MainPage.DisplayAlert("Error", message, "OK");
        }

        public async Task ShowInfo(string message)
        {
            await App.Current.MainPage.DisplayAlert("Information", message, "OK");
        }

        public async Task<bool> ShowQuestion(string message)
        {
            bool result = await App.Current.MainPage.DisplayAlert("Question", message, "Yes", "No");
            return result;
        }

        public async Task ShowWarning(string message)
        {
            await App.Current.MainPage.DisplayAlert("Warning", message, "OK");
        }
    }
}
