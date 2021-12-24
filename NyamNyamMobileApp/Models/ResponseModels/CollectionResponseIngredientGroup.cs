using System.Collections.Generic;
using System.Linq;

namespace NyamNyamMobileApp.Models.ResponseModels
{
    public class CollectionResponseIngredientGroup : List<ResponseIngredient>
    {
        public CollectionResponseIngredientGroup(string name,
                                                 IEnumerable<ResponseIngredient> collection)
            : base(collection)
        {
            Name = name;
            TotalCostInDollars = (collection.Sum(i => i.PricePerUnit * i.RequiredQuantity) / 100).ToString("F2");
        }

        public string Name { get; private set; }
        public string TotalCostInDollars { get; private set; }
    }
}
