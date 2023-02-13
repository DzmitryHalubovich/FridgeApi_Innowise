using FridgeApi;
using FrigeApi.ApplicationCore.Models;
using FrigeApi.ApplocationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrigeApi.Infrastructure
{
    public class SeedDataContext
    {

        public static async Task SeedAsync(FridgeDbContext fridgeContext, int retry =0)
        {
            var retryForAvailability = retry;


            var fridgeModels = new List<FridgeModel>
            {
                new FridgeModel { Name = "Минск", Year = 1965},
                new FridgeModel { Name = "Атлант", Year = 1971},
                new FridgeModel { Name = "Аврора", Year = 1958},
            };

            var product1 = new Product { Name = "Помидор", DefaultQuantity = 5 };
            var product2 = new Product { Name = "Яблоко", DefaultQuantity = 2 };
            var product3 = new Product { Name = "Морковь", DefaultQuantity = 4 };

            var products = new List<Product>
            {
                new Product{Name = "Помидор", DefaultQuantity = 5 },
                new Product{Name = "Яблоко", DefaultQuantity = 2 },
                new Product{Name = "Морковь", DefaultQuantity = 4 },
            };

            var fridges = new List<Fridge>
            {
                new Fridge{Name = "Холодос", OwnerName = "Володя", FridgeModelId = 1, FridgeProducts = new FridgeProduct { Product =  } },
                new Fridge{Name = "АйсАйсБейби", OwnerName = "Володя", FridgeModelId = 2},
                new Fridge{Name = "Коробочка", OwnerName = "Володя", FridgeModelId = 3},
            };


            var fridgeProducts = new List<FridgeProduct> 
            {  
                new FridgeProduct {FridgeId=1,ProductId = 1, Quantity = 2 },
                new FridgeProduct {FridgeId=1,ProductId = 2, Quantity = 4 },
                new FridgeProduct {FridgeId=1,ProductId = 3, Quantity = 1 },
                new FridgeProduct {FridgeId=2,ProductId = 2, Quantity = 5 },
                new FridgeProduct {FridgeId=3,ProductId = 1, Quantity = 1 },
                new FridgeProduct {FridgeId=3,ProductId = 3, Quantity = 2 },
            };

            if (!await fridgeContext.Products.AnyAsync())
            {
                await fridgeContext.Products.AddRangeAsync(GetInitialProduct());
                await fridgeContext.SaveChangesAsync();
            }

            if (!await fridgeContext.FridgeModels.AnyAsync())
            {
                await fridgeContext.FridgeModels.AddRangeAsync(fridgeModels);
                await fridgeContext.SaveChangesAsync();
            }

            if (!await fridgeContext.Fridges.AnyAsync()) 
            {
                await fridgeContext.Fridges.AddRangeAsync(fridges);
                await fridgeContext.SaveChangesAsync();
            }

            if (!await fridgeContext.FridgeProducts.AnyAsync())
            {
                await fridgeContext.FridgeProducts.AddRangeAsync(fridgeProducts);
                await fridgeContext.SaveChangesAsync();
            }
        }
        private static IEnumerable<Product> GetInitialProduct()
        {
            return new List<Product>
            {
                new Product{Name = "Помидор", DefaultQuantity = 5 },
                new Product{Name = "Яблоко", DefaultQuantity = 2 },
                new Product{Name = "Морковь", DefaultQuantity = 4 },
            };
        }
    }
}
