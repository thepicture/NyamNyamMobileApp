using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    public class OrderedDishEndCookingStarter : IAsyncStarter
    {
        private readonly int orderId;
        private readonly int dishId;
        private const string BaseUrl = "http://10.0.2.2:62319/api/";

        public OrderedDishEndCookingStarter(int orderId, int dishId)
        {
            this.orderId = orderId;
            this.dishId = dishId;
        }

        public async Task<bool> StartAsync()
        {
            using (var client = new WebClient())
            {
                try
                {
                    byte[] response = client
                        .DownloadData($"{BaseUrl}CookingStages/Finish?dishId={dishId}&orderId={orderId}");
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
