using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    public class QuantityIncrementStarter : IAsyncStarter
    {
        private readonly int ingredientId;
        private readonly double incrementValue;
        private const string BaseUrl = "http://10.0.2.2:62319/api/";

        public QuantityIncrementStarter(int ingredientId, double incrementValue)
        {
            this.ingredientId = ingredientId;
            this.incrementValue = incrementValue;
        }

        public async Task<bool> StartAsync()
        {
            using (var client = new WebClient())
            {
                try
                {
                    byte[] response = client
                        .DownloadData($"{BaseUrl}ingredientsapi/{ingredientId}/increment?incrementValue={incrementValue}");
                }
                catch (WebException ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    return await Task.FromResult(false);
                }
            }
            return await Task.FromResult(true);
        }
    }
}
