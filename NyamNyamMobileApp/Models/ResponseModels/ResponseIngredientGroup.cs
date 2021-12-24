using System.Collections.Generic;

namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class ResponseIngredientGroup
    {
        public ResponseIngredientGroup()
        {
        }

        public string Name { get; set; }
        public List<ResponseIngredient> Ingredients { get; set; }
    }
}
