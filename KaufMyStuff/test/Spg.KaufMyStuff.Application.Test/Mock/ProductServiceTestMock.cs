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
        private readonly Mock<IReadOnlyRepositoryBase<Category>> _productReadOnlyCategoryMock = new Mock<IReadOnlyRepositoryBase<Category>>();
        private readonly ProductService _unitToTest;

        public ProductServiceTestMock()
        {
            _unitToTest = new ProductService(
                _productRepositoryMock.Object,
                _productReadOnlyRepositoryMock.Object,
                _productReadOnlyCategoryMock.Object,
                _dateTimeServiceMock.Object);
        }

        [Fact]
        public void Create_Success_Test()
        {
            // Arrange
            _dateTimeServiceMock.Setup(d => d.Now).Returns(new DateTime(2023, 02, 25));
            _productReadOnlyRepositoryMock.Setup(r => r.GetByPK("Test Product 01")).Returns(new Product(
                "Test Product 01",
                20,
                "1234567890123",
                "Testmaterial",
                new DateTime(2023, 03, 17),
                MockUtilities.GetSeedingCategory(MockUtilities.GetSeedingShop()))
            );

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
    }
}