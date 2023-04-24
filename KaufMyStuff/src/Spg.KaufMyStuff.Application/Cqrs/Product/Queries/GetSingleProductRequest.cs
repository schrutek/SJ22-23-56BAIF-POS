using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spg.KaufMyStuff.DomainModel.Models;

namespace Spg.KaufMyStuff.Application.Cqrs.Product.Queries
{
    public class GetSingleProductRequest : IRequest<ProductDto>
    {
        public GetSingleProductRequest(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
