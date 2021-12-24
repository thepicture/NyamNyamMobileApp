using NyamNyamMobileApp.Models.ResponseModels;
using System.Collections.Generic;

namespace NyamNyamMobileApp.Models
{
    public class ResponseIngredientGroup : List<ResponseIngredient>
    {
        public ResponseIngredientGroup(string name, IEnumerable<ResponseIngredient> collection) : base(collection)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
