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
        public Command PerformIngredientAvailableCommand { get; }

        public OrderIngredientsViewModel()
        {
            Title = "Ingredients";
            Ingredients = new ObservableCollection<CollectionResponseIngredientGroup>();
            LoadIngredientsCommand = new Command(async () => await ExecuteLoadIngredientsCommand());
            PerformIngredientAvailableCommand = new Command(async (id) => await ExecutePerformIngredientAvailableCommand(id));
        }

        private async Task ExecutePerformIngredientAvailableCommand(object param)
        {
            var ingredient = param as ResponseIngredient;
            double requiredAmount = ingredient.RequiredQuantity;
            string result = await DependencyService
                .Get<IDialogService>().ShowPrompt("Enter the number "
                                                  + "of ingredients to receive",
                                                  requiredAmount.ToString(),
                                                  "Enter a value here");
            if (result == null)
            {
                await DependencyService.Get<IDialogService>().ShowInfo("The attempt " +
                    " to change quantity was discard, nothing changed");
            }
            else
            {

                if (!double.TryParse(result, out var userIncrementValue))
                {
                    await DependencyService.Get<IDialogService>().ShowError("You must " +
                        "enter a positive decimal value, " +
                        "probably with a dot and double precision");
                }
                else
                {
                    if (userIncrementValue <= 0)
                    {
                        await DependencyService.Get<IDialogService>().ShowError("You must " +
                     "enter a positive decimal value, " +
                     "but you have entered a zero or negative value. " +
                     "Try again");
                        return;
                    }
                    if (await new QuantityIncrementStarter(ingredient.Id,
                                                           userIncrementValue).StartAsync())
                    {
                        await DependencyService.Get<IDialogService>().ShowInfo("Quantity " +
                            "was successfully updated!");
                        IsBusy = true;
                    }
                    else
                    {
                        if (await DependencyService.Get<IDialogService>().ShowQuestion("Something " +
                            "wrong with the connection. Try again?"))
                        {
                            await ExecutePerformIngredientAvailableCommand(param);
                        }
                    }
                }
            }
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