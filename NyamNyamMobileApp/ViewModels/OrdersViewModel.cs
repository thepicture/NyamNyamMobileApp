using NyamNyamMobileApp.Models.ResponseModels;
using NyamNyamMobileApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private ResponseOrder _selectedOrder;

        public ObservableCollection<ResponseOrder> Orders { get; }
        public Command LoadOrdersCommand { get; }
        public Command AddOrderCommand { get; }
        public Command<ResponseOrder> OrderTapped { get; }

        public OrdersViewModel()
        {
            Title = "Orders";
            Orders = new ObservableCollection<ResponseOrder>();
            LoadOrdersCommand = new Command(async () => await ExecuteLoadOrdersCommand());

            OrderTapped = new Command<ResponseOrder>(OnOrderSelected);
        }

        async Task ExecuteLoadOrdersCommand()
        {
            IsBusy = true;

            try
            {
                Orders.Clear();
                var orders = await OrderDataStore.GetItemsAsync(true);
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedOrder = null;
        }

        public ResponseOrder SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                OnOrderSelected(value);
            }
        }

        async void OnOrderSelected(ResponseOrder order)
        {
            if(order == null)
            {
                return;
            }
            if (order.Status == "Waiting" && !order.IsEnoughIngredients)
            {
                await Shell.Current.GoToAsync($"{nameof(OrderIngredientsPage)}?{nameof(OrderIngredientsViewModel.Id)}={order.Id}");
            }
            else
            {
                await Shell.Current.GoToAsync($"{nameof(OrderDishesPage)}?{nameof(OrderDishesViewModel.Id)}={order.Id}");
            }
        }
    }
}