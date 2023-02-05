using FridgeApi;
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
        static Fridge fridge1 = new Fridge() { Name = "АйсАйсБейби", OwnerName = "Билли", FridgeModelId = 1 };
        static Fridge fridge2 = new Fridge() { Name = "Жратвохранилище", OwnerName = "Володя", FridgeModelId = 2 }; 
        static Fridge fridge3 = new Fridge() { Name = "BigSquareBoy", OwnerName = "Серёжа", FridgeModelId = 1 }; 
        static Fridge fridge4 = new Fridge() { Name = "Холодос", OwnerName = "Олег", FridgeModelId = 3 }; 
        static Fridge fridge5 = new Fridge() { Name = "Урал", OwnerName = "Олег", FridgeModelId = 4 }; 

        static FridgeModel fridgeModel1 = new FridgeModel() { Name = "Минск", Year = 1962 };
        static FridgeModel fridgeModel2 = new FridgeModel() { Name = "Брест", Year = 2006};
        static FridgeModel fridgeModel3 = new FridgeModel() { Name = "Орск", Year = 1960};
        static FridgeModel fridgeModel4 = new FridgeModel() { Name = "Эврика   ", Year = 1970};
        static FridgeModel fridgeModel5= new FridgeModel() { Name = "Ракета   ", Year = 1956};

        static Product product1 = new Product
        {
            Name = "Помидор",
            DefaultQuantity = 10,
            Fridges = new List<Fridge>() { fridge1, fridge2, fridge4 }
        }; 

        static Product product2 = new Product
        {
            Name = "Лимон",
            DefaultQuantity = 3,
            Fridges = new List<Fridge>() { fridge1, fridge2, fridge4 }
        };
        
        static Product product3 = new Product
        {
            Name = "Ананас",
            DefaultQuantity = 1,
            Fridges = new List<Fridge>() { fridge1, fridge2, fridge4 }
        };
        
        static Product product4 = new Product
        {
            Name = "Пиво",
            DefaultQuantity = 2,
            Fridges = new List<Fridge>() { fridge5}
        };
        
        static Product product5 = new Product
        {
            Name = "Рыба",
            DefaultQuantity = 0,
            Fridges = new List<Fridge>() { fridge3}
        };

        public static async Task SeedAsync(FridgeDbContext fridgeContext, int retry =0)
        {
            var retryForAvailability = retry;

            if (!await fridgeContext.Fridges.AnyAsync()) 
            {
                await fridgeContext.Fridges.AddAsync(fridge1);
                await fridgeContext.Fridges.AddAsync(fridge2);
                await fridgeContext.Fridges.AddAsync(fridge3);
                await fridgeContext.Fridges.AddAsync(fridge4);
                await fridgeContext.Fridges.AddAsync(fridge5);
                //await fridgeContext.Fridges.AddRangeAsync();
                await fridgeContext.SaveChangesAsync();
            }

            if (!await fridgeContext.FridgeModels.AnyAsync())
            {
                await fridgeContext.FridgeModels.AddAsync(fridgeModel1);
                await fridgeContext.FridgeModels.AddAsync(fridgeModel2);
                await fridgeContext.FridgeModels.AddAsync(fridgeModel3);
                await fridgeContext.FridgeModels.AddAsync(fridgeModel4);
                await fridgeContext.FridgeModels.AddAsync(fridgeModel5);
                await fridgeContext.SaveChangesAsync();
            }

            if (!await fridgeContext.Products.AnyAsync())
            {
                await fridgeContext.Products.AddAsync(product1);
                await fridgeContext.Products.AddAsync(product2);
                await fridgeContext.Products.AddAsync(product3);
                await fridgeContext.Products.AddAsync(product4);
                await fridgeContext.Products.AddAsync(product5);
                await fridgeContext.SaveChangesAsync();
            }
        }
    }
}
