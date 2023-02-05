using FrigeApi.ApplocationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgeApi
{
    public class FridgeDbContext : DbContext
    {
        public FridgeDbContext(DbContextOptions<FridgeDbContext> options) : base(options) { }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<Fridge> FridgeModels { get; set; }
        public DbSet<Fridge> Products { get; set; }
    }
}
