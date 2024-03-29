﻿using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Repository.Test.Helpers
{
    public static class DatabaseUtilities
    {
        public static void InitializeDatabase(KaufMyStuffContext db)
        {
            db.Database.EnsureCreated();

            db.Shops.AddRange(GetSeedingShops());
            db.SaveChanges();

            db.Categories.AddRange(GetSeedingCategories(db.Shops.Single(s => s.Id == 1)));
            db.Categories.AddRange(GetSeedingCategories(db.Shops.Single(s => s.Id == 2)));
            db.SaveChanges();

            // Seed Products
            // db.SaveChanges();

            // Seed ...
            // db.SaveChanges();
        }

        private static List<Shop> GetSeedingShops()
        {
            return new List<Shop>()
            {
                new Shop("GMBH", "Test Shop 1", "Test Location 1", "IDontKnow 1", "Bs 1", new Address("Spengergasse", "20", "1050", "Wien"), new Guid("0c03ceb5-e2a2-4faf-b273-63839505f573")),
                new Shop("GMBH", "Test Shop 2", "Test Location 2", "IDontKnow 2", "Bs 2", new Address("Spengergasse", "21", "1051", "Wien"), new Guid("a0a6b711-fd27-4193-8595-325a62d82c5c")),
            };
        }

        private static List<Category> GetSeedingCategories(Shop shop)
        {
            return new List<Category>()
            {
                new Category("DVD", new Guid("d2616f6e-7424-4b9f-bf81-6aad88183f41"), shop),
                new Category("Bücher", new Guid("34993d53-a315-4e4d-aaf8-4406ec5a45b3"), shop),
            };
        }

        //private static List<Product> GetSeedingProducts(Category category)
        //{
        //    throw new NotImplementedException();
        //}

        // ...
    }
}
