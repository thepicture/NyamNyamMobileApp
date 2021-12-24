using NyamNyamMobileApp.Models;
using NyamNyamMobileApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace NyamNyamMobileApp.ViewModels
{
    [QueryProperty(nameof(ResponseOrder.Id), nameof(ResponseOrder.Id))]
    public class OrderIngredientsViewModel : BaseViewModel
    {
        private string id;
        public List<ResponseIngredientGroup> Ingredients { get; set; } =
            new List<ResponseIngredientGroup>();

        public OrderIngredientsViewModel()
        {
            Title = "Ingredients";

            Ingredients.Add(new ResponseIngredientGroup("In stock", new List<ResponseIngredient>
            {
                new ResponseIngredient
                {
                    IngredientName = "Av1",
                    CountInStock = 10.ToString(),
                    Id = 1,
                    PriceInCents = 200,
                    RequiredQuantity = 5.ToString(),
                    UnitText = "pcs",
                    IsAvailable = false
                },
                  new ResponseIngredient
                {
                    IngredientName = "Av2",
                    CountInStock = 50.ToString(),
                    Id = 1,
                    PriceInCents = 5,
                    RequiredQuantity = 10.ToString(),
                    UnitText = "pcs",
                    IsAvailable = false
                },
                    new ResponseIngredient
                {
                    IngredientName = "Av3",
                    CountInStock = 10.ToString(),
                    Id = 1,
                    PriceInCents = 200,
                    RequiredQuantity = 10.ToString(),
                    UnitText = "ml",
                    IsAvailable = false
                },
            })); ;

            Ingredients.Add(new ResponseIngredientGroup("Not available", new List<ResponseIngredient>
            {
                new ResponseIngredient
                {
                    IngredientName = "NotAv1",
                    CountInStock = 10.ToString(),
                    Id = 1,
                    PriceInCents = 200,
                    RequiredQuantity = 20.ToString(),
                    UnitText = "pcs",
                    IsAvailable = true
                },
                  new ResponseIngredient
                {
                    IngredientName = "NotAv2",
                    CountInStock = 50.ToString(),
                    Id = 1,
                    PriceInCents = 5,
                    RequiredQuantity = 100.ToString(),
                    UnitText = "pcs",
                    IsAvailable = true
                },
                    new ResponseIngredient
                {
                    IngredientName = "NotAv3",
                    CountInStock = 4.5.ToString(),
                    Id = 1,
                    PriceInCents = 200,
                    RequiredQuantity = 5.ToString(),
                    UnitText = "ml",
                    IsAvailable = true
                },
            }));
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