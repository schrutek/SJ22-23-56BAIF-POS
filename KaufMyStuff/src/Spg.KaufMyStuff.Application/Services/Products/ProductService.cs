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
    public class ProductService
    {
        private readonly IRepositoryBase<Product> _productRepository;
        private readonly IReadOnlyRepositoryBase<Product> _readOnlyRroductRepository;
        private readonly IDateTimeService _dateTimeService;

        public ProductService(
            IRepositoryBase<Product> productRepository,
            IReadOnlyRepositoryBase<Product> readOnlyRroductRepository,
            IDateTimeService dateTimeService)
        {
            _productRepository = productRepository;
            _readOnlyRroductRepository = readOnlyRroductRepository;
            _dateTimeService = dateTimeService;
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
        public void Create(Product newProduct)
        {
            // TODO: Das Ablaufdatum muss 4 Wochen in der Zukunft liegen
            if (newProduct.ExpiryDate < _dateTimeService.Now.AddDays(14))
            {
                throw new ProductServiceValidationException("Das Ablaufdatum muss 2 Wochen in der Zukunft liegen!");
            }
            if (_readOnlyRroductRepository.GetByPK(newProduct.Name) is not null)
            {
                throw new ProductServiceValidationException("Das Produkt existiert bereits!");
            }

            // ...

            try
            {
                _productRepository.Create(newProduct);
            }
            catch (RepositoryCreateException ex)
            {
                throw new ProductServiceCreateException("Create ist sehr schief gegangen!", ex);
            }
        }

        public IQueryable<Product> GetAll()
        {
            return null;
        }
    }
}
