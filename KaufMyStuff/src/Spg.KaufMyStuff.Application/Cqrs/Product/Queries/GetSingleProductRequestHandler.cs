using MediatR;
using Spg.KaufMyStuff.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Application.Cqrs.Product.Queries
{
    public class GetSingleProductRequestHandler : IRequestHandler<GetSingleProductRequest, ProductDto>
    {
        public Task<ProductDto> Handle(GetSingleProductRequest request, CancellationToken cancellationToken)
        {
            // TODO : Daten aus der DB laden
            return null;
        }
    }
}
