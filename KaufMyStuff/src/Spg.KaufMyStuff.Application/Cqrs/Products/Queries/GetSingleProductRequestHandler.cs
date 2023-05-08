using MediatR;
using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;

namespace Spg.KaufMyStuff.Application.Cqrs.Products.Queries
{
    public class GetSingleProductRequestHandler : IRequestHandler<GetSingleProductRequest, ProductDto>
    {
        private readonly IReadOnlyRepositoryBase<Product> _readOnlyProductRepository;

        public GetSingleProductRequestHandler(IReadOnlyRepositoryBase<Product> readOnlyProductRepository)
        {
            _readOnlyProductRepository = readOnlyProductRepository;
        }

        public async Task<ProductDto> Handle(GetSingleProductRequest request, CancellationToken cancellationToken)
        {
            Product? product = await Task.Run(() => _readOnlyProductRepository.GetByPK(request.Name))
                ?? throw new ProductServiceValidationException("Produkt konnte nicht gefunden werden!");

            return new ProductDto()
            {
                ProductName = product.Name,
                Ean13 = product.Ean,
                Material = product.Material,
                ExpiryDate = product.ExpiryDate,
                CategoryName = product.CategoryNavigation?.Name
            };
        }
    }
}
