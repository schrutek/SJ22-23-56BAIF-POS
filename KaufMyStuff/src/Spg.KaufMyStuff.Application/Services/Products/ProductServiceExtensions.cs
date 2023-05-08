using Microsoft.EntityFrameworkCore.Update;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Application.Services.Products
{
    public static class ProductServiceExtensions
    {
        public static IReadOnlyProductService FilterNameContains(this IReadOnlyProductService service, string namePart)
        {
            if (!string.IsNullOrEmpty(namePart))
            {
                service.Products = service.Products.Where(p => p.Name.ToLower().Contains(namePart.ToLower()));
            }
            return service;
        }

        public static IReadOnlyProductService Sort(this IReadOnlyProductService service, string columnName)
        {
            // TODO: Implementation
            return service;
        }

        public static IReadOnlyProductService FilterStockLimit(this IReadOnlyProductService service, int minStockLImit)
        {
            // TODO: Implementation
            return service;
        }

        public static IReadOnlyProductService FilterExpiryDate(this IReadOnlyProductService service, DateTime expiryDate)
        {
            // TODO: Implementation
            return service;
        }
    }
}
