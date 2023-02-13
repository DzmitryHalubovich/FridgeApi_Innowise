
using FrigeApi.ApplocationCore.Models;
using FrigeApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FridgeApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                try
                {
                    var fridgeContext = scopedProvider.GetRequiredService<FridgeDbContext>();
                    if (fridgeContext.Database.IsSqlServer())
                    {
                        fridgeContext.Database.Migrate();
                    }
                    await SeedDataContext.SeedAsync(fridgeContext);
                }
                catch (Exception ex)
                {
                    app.Logger.LogError(ex, "An error occurred adding migrations to Databse.");
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            //Из контекста
            app.MapGet("/fridge/All", async(FridgeDbContext context) =>
                await context.Fridges
                .Include(model => model.FridgeModel)
                .Include(model => model.Products)
                .ToListAsync());

            app.MapGet("/fridge/{id}", async (FridgeDbContext context, int id) =>
                await context.Fridges.FindAsync(id) is Fridge fridge ?
                    Results.Ok(fridge) :
                    Results.NotFound("Sorry, fridge not found")) ;

            app.MapPost("/fridge/Put", async (FridgeDbContext context, Fridge fridge) =>
            {
                context.Fridges.Add(fridge);
                await context.SaveChangesAsync();
                return Results.Ok(await context.Fridges.ToListAsync());
            }) ;

            app.MapControllers();

            app.Run();
        }
    
    }

}