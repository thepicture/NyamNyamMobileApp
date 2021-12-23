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
        private ResponseOrder order;

        public OrderDishesViewModel()
        {
            Title = "Order dishes";
        }

        public string Id
        {
            get => id;
            set
            {
                id = value;
                LoadId(value);
            }
        }

        public ResponseOrder Order
        {
            get => order;
            set => SetProperty(ref order, value);
        }

        public async void LoadId(string itemId)
        {
            try
            {
                Order = await OrderDataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}