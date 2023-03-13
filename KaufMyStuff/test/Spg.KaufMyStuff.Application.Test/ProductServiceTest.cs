using Moq;
using Spg.KaufMyStuff.Application.Services.Products;
using Spg.KaufMyStuff.Application.Test.Helpers;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using Spg.KaufMyStuff.Repositories;

namespace Spg.KaufMyStuff.Application.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void Create_Success_Test()
        {
            using (KaufMyStuffContext db = new KaufMyStuffContext(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                IRepositoryBase<Product> productRepo = new RepositoryBase<Product>(db);
                IReadOnlyRepositoryBase<Product> readOnlyRroductRepo = new RepositoryBase<Product>(db);
                ProductService unitToTest = new ProductService(productRepo, readOnlyRroductRepo, new DateTimeServiceMock());
                Product newProduct = new Product("Test Product 02", 20, "1234567890123", "Testmaterial", new DateTime(2023, 03, 17), db.Categories.Single(c => c.Id == 1));

                // Act
                unitToTest.Create(newProduct);

                // Assert
                Assert.Equal(2, db.Products.Count());
            }
        }

        [Fact]
        public void Create_ProductServiceCreateException_Expected_Test()
        {
            using (KaufMyStuffContext db = new KaufMyStuffContext(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                IRepositoryBase<Product> productRepo = new RepositoryBase<Product>(db);
                IReadOnlyRepositoryBase<Product> readOnlyRroductRepo = new RepositoryBase<Product>(db);
                ProductService unitToTest = new ProductService(productRepo, readOnlyRroductRepo, new DateTimeServiceMock());
                Product newProduct = new Product("Test Product 02", 20, "1234567890123", "Testmaterial", new DateTime(2023, 03, 17), new Category("", new Guid(), null!));

                // Act + Assert
                Assert.Throws<ProductServiceCreateException>(() => unitToTest.Create(newProduct));
            }
        }

        [Fact]
        public void Create_NameMustBeUnique_Test()
        {
            using (KaufMyStuffContext db = new KaufMyStuffContext(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                IRepositoryBase<Product> productRepo = new RepositoryBase<Product>(db);
                IReadOnlyRepositoryBase<Product> readOnlyRroductRepo = new RepositoryBase<Product>(db);
                ProductService unitToTest = new ProductService(productRepo, readOnlyRroductRepo, new DateTimeServiceMock());
                Product newProduct = new Product("Test Product 01", 20, "1234567890123", "Testmaterial", new DateTime(2023, 03, 17), db.Categories.Single(c => c.Id == 1));

                // Act + Assert
                Assert.Throws<ProductServiceValidationException>(() => unitToTest.Create(newProduct));
            }
        }

        [Fact]
        public void Create_ExpiryDateIsNotInFuture_Test()
        {
            using (KaufMyStuffContext db = new KaufMyStuffContext(DatabaseUtilities.GetDbOptions()))
            {
                // Arrange
                DatabaseUtilities.InitializeDatabase(db);
                IRepositoryBase<Product> productRepo = new RepositoryBase<Product>(db);
                IReadOnlyRepositoryBase<Product> readOnlyRroductRepo = new RepositoryBase<Product>(db);
                ProductService unitToTest = new ProductService(productRepo, readOnlyRroductRepo, new DateTimeServiceMock());
                Product newProduct = new Product(
                    "Test Product 02", 
                    20, 
                    "1234567890123", 
                    "Testmaterial", 
                    new DateTime(2023, 03, 03), 
                    db.Categories.Single(c => c.Id == 1)
                );

                // Act + Assert
                Assert.Throws<ProductServiceValidationException>(() => unitToTest.Create(newProduct));
            }
        }
    }
}