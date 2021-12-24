using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    /// <summary>
    /// Defines a method to start an asynchronous action.
    /// </summary>
    public interface IAsyncStarter
    {
        /// <summary>
        /// Starts an asynchronous action.
        /// </summary>
        /// <returns>True if the action was successful, otherwise false.</returns>
        Task<bool> StartAsync();
    }
}
