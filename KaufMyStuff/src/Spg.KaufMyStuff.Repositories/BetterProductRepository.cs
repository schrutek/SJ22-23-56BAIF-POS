﻿using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Repositories
{
    public class BetterProductRepository : IProductRepository
    {
        private readonly KaufMyStuffContext _db;

        public BetterProductRepository(KaufMyStuffContext db)
        {
            _db = db;
        }

        public void Create(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
