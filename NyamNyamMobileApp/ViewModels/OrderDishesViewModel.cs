using NyamNyamMobileApp.Models.ResponseModels;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(ResponseOrder.Id), nameof(ResponseOrder.Id))]
    public class OrderDishesViewModel : BaseViewModel
    {
        private string id;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                LoadId(value);
            }
        }

        public async void LoadId(string itemId)
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