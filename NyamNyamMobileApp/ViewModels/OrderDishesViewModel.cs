using NyamNyamMobileApp.Models.ResponseModels;
using NyamNyamMobileApp.Services;
using NyamNyamMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(ResponseOrder.Id), nameof(ResponseOrder.Id))]
    public class OrderDishesViewModel : BaseViewModel
    {
        private string id;
        private ResponseOrder order;
        public Command RefreshDishesCommand { get; }
        public Command StartDishCooking { get; }

        public Command<int> OrderedDishTapped { get; }

        public OrderDishesViewModel()
        {
            Title = "Order dishes";
            RefreshDishesCommand = new Command(() => LoadId(Id));
            StartDishCooking = new Command(dishId => ExecuteStartDishCookingCommand(dishId));

            OrderedDishTapped = new Command<int>(OnOrderedDishTapped);
        }

        private async void OnOrderedDishTapped(int dishId)
        {
            int orderId = Order.Id;
            await Shell.Current.GoToAsync($"{nameof(RecipePage)}?{nameof(RecipeViewModel.OrderId)}={order.Id}&{nameof(RecipeViewModel.DishId)}={dishId}");
        }

        private async void ExecuteStartDishCookingCommand(object dishId)
        {
            var dishCookingStarter = new OrderedDishCookingStarter(orderId: int.Parse(Id), dishId: (int)dishId);
            bool isCookingStarted = await dishCookingStarter.StartAsync();
            if (isCookingStarted)
            {
                await DependencyService.Get<IDialogService>().ShowInfo("Cooking was successfully started!");
                LoadId(Id);
            }
            else
            {
                bool isTryingAgain = await DependencyService
                    .Get<IDialogService>().ShowQuestion("Cooking was not started! Try again?");
                if (isTryingAgain)
                {
                    ExecuteStartDishCookingCommand(dishId);
                }
            }
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
            IsBusy = true;
            try
            {
                Order = await OrderDataStore.GetItemAsync(itemId);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Ordered Dishes");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}