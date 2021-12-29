using NyamNyamMobileApp.Models.ResponseModels;
using NyamNyamMobileApp.Services;
using NyamNyamMobileApp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    [QueryProperty(nameof(DishId), nameof(DishId))]
    public class RecipeViewModel : BaseViewModel
    {
        private int orderId;
        private int dishId;
        private ResponseCookingStageList stageList;

        public RecipeViewModel()
        {
        }

        public int OrderId { get => orderId; set => SetProperty(ref orderId, value); }
        public int DishId { get => dishId; set => SetProperty(ref dishId, value); }
        public ResponseCookingStageList StageList
        {
            get => stageList;
            set => SetProperty(ref stageList, value);
        }

        public void OnAppearing()
        {
            LoadStages();
            Title = StageList.RecipeName;
        }

        private async void LoadStages()
        {
            IEnumerable<ResponseCookingStageList> stages =
             await CookingStageDataStore
             .GetItemsAsyncFromId(false, new object[] { orderId, dishId });
            StageList = stages.First();
        }

        private Command finishDishCommand;

        public ICommand FinishDishCommand
        {
            get
            {
                if (finishDishCommand == null)
                {
                    finishDishCommand = new Command(FinishDish);
                }

                return finishDishCommand;
            }
        }

        private async void FinishDish()
        {
            var endCookingStarter = new OrderedDishEndCookingStarter(OrderId, DishId);
            if (await endCookingStarter.StartAsync())
            {
                await DependencyService.Get<IDialogService>().ShowInfo("The dish " +
                    "has been successfully finished!");
                await Shell.Current.GoToAsync($"{nameof(OrderDishesPage)}?{nameof(OrderDishesViewModel.Id)}={OrderId}");
            }
            else
            {
                await DependencyService.Get<IDialogService>().ShowInfo("The dish " +
                  "has not been successfully finished! Try again or restart the app");
            }
        }
    }
}
