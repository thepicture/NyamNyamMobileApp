namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class ResponseCookingStage
    {
        public ResponseCookingStage()
        {
        }

        public int SequentialNumber { get; set; }
        public string RecipeName { get; set; }
        public float CookingTimeInMinutes { get; set; }
        public ResponseCookingStageIngredient[] Ingredients { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public int DishId { get; set; }
    }
}
