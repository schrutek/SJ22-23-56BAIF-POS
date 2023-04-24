﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spg.KaufMyStuff.DomainModel.Dtos;
using Spg.KaufMyStuff.DomainModel.Exceptions;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Application.Services.Products
{
    public class ProductService : IReadOnlyProductService
    {
        private readonly IRepositoryBase<Product> _productRepository;
        private readonly IReadOnlyRepositoryBase<Product> _readOnlyProductRepository;
        private readonly IReadOnlyRepositoryBase<Category> _readOnlyCategoryRepository;
        private readonly IDateTimeService _dateTimeService;

        public IQueryable<Product> Products { get; set; }

        public ProductService(
            IRepositoryBase<Product> productRepository,
            IReadOnlyRepositoryBase<Product> readOnlyProductRepository,
            IReadOnlyRepositoryBase<Category> readOnlyCategoryRepository,
            IDateTimeService dateTimeService)
        {
            _productRepository = productRepository;
            _readOnlyProductRepository = readOnlyProductRepository;
            _readOnlyCategoryRepository = readOnlyCategoryRepository;
            _dateTimeService = dateTimeService;
        }

        public IReadOnlyProductService Load()
        {
            Products = _readOnlyProductRepository.GetAll();
            return this;
        }

        public IEnumerable<Product> GetData() // Product ändern auf ProductDto
        {
            // DTO-Mapping (AutoMapper, LinQ-Select, foreach(...))
            //return Products.Select(p => new ProductDto() { ProductName = p.Name, ... });
            return Products;
        }

        public IEnumerable<Product> GetDataPaged(int pageIndex, int pageSize) // Product ändern auf ProductDto
        {
            // PagenatedList verwenden...
            return Products;
        }

        // TODO: Fertig machen!!!!!!

        /// <summary>
        /// Beinhaltet die Business-Logic für das hinzufügen eines Products.
        /// </summary>
        /// <remarks>
        /// Validierung
        /// * Produktbezeichnung ist notwendig
        /// * EAN ist notwendig
        /// * Darf nicht <code>null</code> sein.
        /// 
        /// Technische Prüfung
        /// * Stückzahl muss größer 0 sein
        /// * Muss eine gültige Category haben (LinQ)
        /// * Muss unique sein (LinQ)
        /// * Muss einen gültigen Preis mit gültiger Steuerklasse haben (LinQ)
        /// --- * Darf nur in einer Kategorie vorkommen
        /// * Das Ablaufdatum darf nicht an einem Samstag/Sonntag sein
        /// </remarks>
        public void Create(CreateProductDto newProductDto)
        {
            // Initialization
            //TODO: Katg. finden in DB
            Category existingCategory = _readOnlyCategoryRepository.GetByGuid<Category>(newProductDto.CategoryId) 
                ?? throw new ProductServiceValidationException("Die Kategorie wurde nicht gefunden!");

            // Validation
            if (newProductDto.ExpiryDate < _dateTimeService.Now.AddDays(14))
            {
                throw new ProductServiceValidationException("Das Ablaufdatum muss 2 Wochen in der Zukunft liegen!");
            }
            if (_readOnlyProductRepository.GetByPK(newProductDto.Name) is not null)
            {
                throw new ProductServiceValidationException("Das Produkt existiert bereits!");
            }
            // ...

            // Act / Mapping
            Product p = new(
                newProductDto.Name, 
                newProductDto.Tax, 
                newProductDto.Ean, 
                newProductDto.Material, 
                newProductDto.ExpiryDate, 
                existingCategory);

            // [Save]
            try
            {
                _productRepository.Create(p);
            }
            catch (RepositoryCreateException ex)
            {
                throw new ProductServiceCreateException("Create ist sehr schief gegangen!", ex);
            }

            // [Mapp]
        }
    }
}
