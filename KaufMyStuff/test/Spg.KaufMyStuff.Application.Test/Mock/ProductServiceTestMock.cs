using Moq;
using Spg.KaufMyStuff.Application.Services.Products;
using Spg.KaufMyStuff.Application.Test.Helpers;
using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using Spg.KaufMyStuff.Repositories;

namespace Spg.KaufMyStuff.Application.Test
{
    public class ProductServiceTestMock
    {
        private readonly Mock<IDateTimeService> _dateTimeServiceMock = new Mock<IDateTimeService>();
        private readonly Mock<IRepositoryBase<Product>> _productRepositoryMock = new Mock<IRepositoryBase<Product>>();
        private readonly Mock<IReadOnlyRepositoryBase<Product>> _productReadOnlyRepositoryMock = new Mock<IReadOnlyRepositoryBase<Product>>();
        private readonly Mock<IReadOnlyRepositoryBase<Category>> _categoryReadOnlyRepositoryMock = new Mock<IReadOnlyRepositoryBase<Category>>();
        private readonly ProductService _unitToTest;

        public ProductServiceTestMock()
        {
            _unitToTest = new ProductService(
                _productRepositoryMock.Object,
                _productReadOnlyRepositoryMock.Object,
                _categoryReadOnlyRepositoryMock.Object,
                _dateTimeServiceMock.Object);
        }

        [Fact]
        public void Create_Success_Test()
        {
            // Arrange
            _dateTimeServiceMock.Setup(d => d.Now).Returns(new DateTime(2023, 02, 25));
            _productReadOnlyRepositoryMock
                .Setup(r => r.GetByPK("Test Product 01"))
                .Returns(new Product(
                "Test Product 01",
                20,
                "1234567890123",
                "Testmaterial",
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()))
            );
            _categoryReadOnlyRepositoryMock
                .Setup(r => r.GetByGuid<Category>(new Guid("d2616f6e-7424-4b9f-bf81-6aad88183f41")))
                .Returns(MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()));

            CreateProductDto newProduct = new CreateProductDto(
                "Test Product 02", 
                20, 
                "1234567890123", 
                "Testmaterial", 
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()).Guid);

            // Act
            _unitToTest.Create(newProduct);

            // Assert
            _productRepositoryMock.Verify(r => r.Create(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void Create_CategoryDoesNotExist()
        {
            // Arrange
            _dateTimeServiceMock.Setup(d => d.Now).Returns(new DateTime(2023, 02, 25));
            _productReadOnlyRepositoryMock
                .Setup(r => r.GetByPK("Test Product 01"))
                .Returns(new Product(
                "Test Product 01",
                20,
                "1234567890123",
                "Testmaterial",
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()))
            );
            _categoryReadOnlyRepositoryMock
                .Setup(r => r.GetByGuid<Category>(new Guid("f99a7349-e987-4cb9-a986-4c200c71bb13")))
                .Returns<Category>(null!);

            CreateProductDto newProduct = new CreateProductDto(
                "Test Product 02",
                20,
                "1234567890123",
                "Testmaterial",
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()).Guid);

            // Act + Assert
            _productRepositoryMock.Verify(r => r.Create(It.IsAny<Product>()), Times.Never);
            Assert.Throws<ProductServiceValidationException>(() => _unitToTest.Create(newProduct));
        }

        [Fact]
        public void Create_CategoryNotUniqueExist()
        {
            // Arrange
            _dateTimeServiceMock.Setup(d => d.Now).Returns(new DateTime(2023, 02, 25));
            _productReadOnlyRepositoryMock
                .Setup(r => r.GetByPK("Test Product 01"))
                .Returns(new Product(
                "Test Product 01",
                20,
                "1234567890123",
                "Testmaterial",
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()))
            );
            _categoryReadOnlyRepositoryMock
                .Setup(r => r.GetByGuid<Category>(new Guid("f99a7349-e987-4cb9-a986-4c200c71bb13")))
                .Throws(() => new InvalidOperationException("Kategorie wurde mehrmals gefunden!"));

            CreateProductDto newProduct = new CreateProductDto(
                "Test Product 02",
                20,
                "1234567890123",
                "Testmaterial",
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()).Guid);

            // Act + Assert
            _productRepositoryMock.Verify(r => r.Create(It.IsAny<Product>()), Times.Never);
            Assert.Throws<ProductServiceValidationException>(() => _unitToTest.Create(newProduct));
        }
    }
}