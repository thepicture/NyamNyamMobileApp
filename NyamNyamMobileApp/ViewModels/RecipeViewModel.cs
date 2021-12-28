using NyamNyamMobileApp.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
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
    }
}
