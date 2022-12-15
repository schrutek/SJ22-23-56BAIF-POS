using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Infrastructure
{
    // 0. von DbContext ableiten
    public class KaufMyStuffContext : DbContext
    {
        // 1. Tabellen / Entities mappen
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<ShoppingCartItem> ShoppingCartItems => Set<ShoppingCartItem>();


        // 2. Constructor
        public KaufMyStuffContext()
        { }
        public KaufMyStuffContext(DbContextOptions options) 
            : base(options)
        { }

        // 3. OnConfiguring
        // Achtung!! ConnectionString darf NIEMALS in den Sources stehen (Git-Hub)
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=KaufMyStuff.db");
            }
        }

        // 4. OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("Stuff");
            //modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Product>().HasKey(p => p.Name);
            
            //modelBuilder.Entity<Product>().HasIndex(p => p.Ean);

            modelBuilder.Entity<Customer>().OwnsOne(c => c.Address);
            modelBuilder.Entity<Shop>().OwnsOne(s => s.Address);

            //modelBuilder.Entity<Customer>().HasMany(c => c.ShoppingCarts);
        }

        // 5. Seeding
        public void Seed()
        {
            
        }
    }
}
