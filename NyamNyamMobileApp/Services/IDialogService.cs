using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    public interface IDialogService
    {
        Task ShowInfo(string message);
        Task ShowError(string message);
        Task ShowWarning(string message);
        Task<bool> ShowQuestion(string message);
    }
}
