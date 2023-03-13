using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using Spg.KaufMyStuff.Repositories;
using Spg.KaufMyStuff.Repository.Test.Helpers;

namespace Spg.KaufMyStuff.Repository.Test
{
    public class ProductRepositoryTest
    {
        //private KaufMyStuffContext GetDatabase()
        //{
        //    DbContextOptionsBuilder options = new DbContextOptionsBuilder();
        //    options.UseSqlite("Data Source=:memory:");

        //    KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();
        //    return db;
        //}

        private DbContextOptions GetDbOptions() 
        {
            SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            
            return new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;
        }

        [Fact()]
        public void Create_Success_Test()
        {
            // Arrange
            using (KaufMyStuffContext db = new KaufMyStuffContext(GetDbOptions()))
            {
                RepositoryBase<Product> unitToTest = new RepositoryBase<Product>(db);

                DatabaseUtilities.InitializeDatabase(db);

                Product newProduct = new Product("Testprodukt", 20, "123456798", "Testmaterial", DateTime.Now, db.Categories.Single(c => c.Id == 1));

                // Act
                unitToTest.Create(newProduct);

                // Assert
                Assert.Equal(1, db.Products.Count());
            }
        }

        [Fact()]
        public void Create_Failure_RepositoryCreateException_Expected_Test()
        {
            using (KaufMyStuffContext db = new KaufMyStuffContext(GetDbOptions()))
            {
                RepositoryBase<Product> unitToTest = new RepositoryBase<Product>(db);

                DatabaseUtilities.InitializeDatabase(db);

                Category category = new Category("", new Guid("d2616f6e-7424-4b9f-bf81-6aad88183f41"), null);
                Product newProduct = new Product("Testprodukt", 20, "123456798", "Testmaterial", DateTime.Now, category);

                // Act + Assert
                Assert.Throws<RepositoryCreateException>(() => unitToTest.Create(newProduct));
            }
        }
    }
}