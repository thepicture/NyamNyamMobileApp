using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(OrderId), nameof(OrderId))]
    [QueryProperty(nameof(DishId), nameof(DishId))]
    public class RecipeViewModel : BaseViewModel
    {
        private int orderId;
        private int dishId;

        public RecipeViewModel()
        {
        }

        public int OrderId { get => orderId; set => SetProperty(ref orderId, value); }
        public int DishId { get => dishId; set => SetProperty(ref dishId, value); }
    }
}
