using FrigeApi.ApplicationCore.Models;
using FrigeApi.ApplocationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgeApi
{
    public class FridgeDbContext : DbContext
    {
        public FridgeDbContext(DbContextOptions<FridgeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //     .Entity<Fridge>()
            //     .HasMany(pr => pr.Products)
            //     .WithMany(fr => fr.Fridges)
            //     .UsingEntity<FridgeProduct>(
            //        j => j
            //        .HasOne(fr => fr.Fridge)
            //        .WithMany(t => t.FridgeProducts)
            //        .HasForeignKey(fr => fr.FridgeId),
            //    j => j
            //    .HasOne(pr => pr.Product)
            //    .WithMany(p => p.FridgeProducts)
            //    .HasForeignKey(pr => pr.ProductId),
            //    j => { 
            //    }

            modelBuilder
            .Entity<Fridge>()
            .HasMany(c => c.Products)
            .WithMany(s => s.Fridges)
            .UsingEntity<FridgeProduct>(
               j => j
                .HasOne(pt => pt.Product)
                .WithMany(t => t.FridgeProducts)
                .HasForeignKey(pt => pt.ProductId),
            j => j
                .HasOne(pt => pt.Fridge)
                .WithMany(p => p.FridgeProducts)
                .HasForeignKey(pt => pt.FridgeId),
            j =>
            {
                j.Property(q=>q.Quantity).HasDefaultValue(1);
                j.HasKey(t=> new { t.ProductId,t.FridgeId});
                j.ToTable("FridgesProducts");
            });



            //builder.ToTable("fridge");
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.Property(x => x.Name).HasMaxLength(50).HasColumnName("name").IsRequired();
            //builder.Property(x => x.OwnerName).HasMaxLength(50).HasColumnName("owner_name").IsRequired();
        }

        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<FridgeModel> FridgeModels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<FridgeProduct> FridgeProducts { get; set; }


    }
}
