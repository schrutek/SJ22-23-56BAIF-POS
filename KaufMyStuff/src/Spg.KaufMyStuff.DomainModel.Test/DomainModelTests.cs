using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using System.Net.Http.Headers;

namespace Spg.KaufMyStuff.DomainModel.Test
{
    public class DomainModelTests
    {
        //private KaufMyStuffContext db = CreateDb();  GANZ BÖSE!!

        private KaufMyStuffContext CreateDb()
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.UseSqlite("Data Source=KaufMyStuff.db");

            KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            //db.Seed();
            return db;
        }

        [Fact]
        public void SeedDb() 
        {
            KaufMyStuffContext db = CreateDb();
            db.Seed();
        }

        // Tripple A-Pattern AAA
        [Fact]
        public void Product_Add_SuccessTest()
        {
            // 1. Arrange
            KaufMyStuffContext db = CreateDb();
            Product newProduct = new Product("Testprodukt", 20, "123456798", "Testmaterial", DateTime.Now, null);

            // 2. Act
            db.Products.Add(newProduct);
            db.SaveChanges();

            // 3. Assert
            Assert.Equal(1, db.Products.Count());
        }
    }
}