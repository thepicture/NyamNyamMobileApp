using NyamNyamMobileApp.Models.ResponseModels;
using NyamNyamMobileApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(ResponseOrder.Id), nameof(ResponseOrder.Id))]
    public class OrderIngredientsViewModel : BaseViewModel
    {
        private string id;
        private ObservableCollection<CollectionResponseIngredientGroup> ingredients;

        public ObservableCollection<CollectionResponseIngredientGroup> Ingredients
        {
            get => ingredients;
            set => SetProperty(ref ingredients, value);
        }
        public Command LoadIngredientsCommand { get; }

        public OrderIngredientsViewModel()
        {
            Title = "Ingredients";
            Ingredients = new ObservableCollection<CollectionResponseIngredientGroup>();
            LoadIngredientsCommand = new Command(async () => await ExecuteLoadIngredientsCommand());
        }

        private async Task ExecuteLoadIngredientsCommand()
        {
            IsBusy = true;

            try
            {
                Ingredients.Clear();
                var groups = await ((OrderDataStore)OrderDataStore).GetResponseIngredientGroupsAsync(Id);
                var newGroups = new ObservableCollection<CollectionResponseIngredientGroup>();
                foreach (var group in groups)
                {
                    newGroups.Add(new CollectionResponseIngredientGroup
                    (
                        group.Name,
                        group.Ingredients
                    ));
                    Ingredients = newGroups;
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

        public string Id
        {
            get => id;
            set
            {
                id = value;
                LoadId(value);
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
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