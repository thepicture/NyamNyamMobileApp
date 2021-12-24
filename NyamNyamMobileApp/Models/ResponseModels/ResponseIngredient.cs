namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class ResponseIngredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int PriceInCents { get; set; }
        public string UnitText { get; set; }
        public string RequiredQuantity { get; set; }
        public string CountInStock { get; set; }
        public bool IsAvailable { get; set; }
        public ResponseIngredient()
        {
        }
    }
}
