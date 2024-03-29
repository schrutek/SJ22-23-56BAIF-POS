﻿using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Services;
using Spg.KaufMyStuff.DomainModel.Services.Products;
using Spg.KaufMyStuff.DiDemoConsole;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using Spg.KaufMyStuff.Repositories;

ProductController controller = new ProductController();
controller.Index();
controller.Privacy();



//DbContextOptionsBuilder options = new DbContextOptionsBuilder();
//options.UseSqlite("Data Source=KaufMyStuff.db");

//KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
//db.Database.EnsureDeleted();
//db.Database.EnsureCreated();
//db.Seed();

//IQueryable<Product> result = new ProductService(new RepositoryBase<Product>(db), new RepositoryBase<Product>(db), new RepositoryBase<Category>(db), new DateTimeService()).GetAll();

//foreach (Product p in result.ToList())
//{
//    Console.WriteLine($"{p.Name} {p.Ean} {p.Material}");
//}