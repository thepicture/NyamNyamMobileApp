namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class ResponseIngredient
    {
        public ResponseIngredient()
        {
        }

        public int Id { get; set; }
        public string IngredientName { get; set; }
        public int PriceInCents { get; set; }
        public string UnitText { get; set; }
        public float RequiredQuantity { get; set; }
        public float CountInStock { get; set; }
        public bool IsAvailable { get; set; }
        public float PricePerUnit { get; set; }
    }
}
