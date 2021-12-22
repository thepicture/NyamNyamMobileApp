using NyamNyamMobileApp.Models;
using NyamNyamMobileApp.Models.ResponseModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(ResponseOrder.Id), nameof(ResponseOrder.Id))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public int OrderId;
        public async void LoadItemId(string itemId)
        {
            try
            {
                var order = await OrderDataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
