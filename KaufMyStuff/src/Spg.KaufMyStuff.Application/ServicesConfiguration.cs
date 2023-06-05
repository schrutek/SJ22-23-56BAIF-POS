using Microsoft.Extensions.DependencyInjection;
using Spg.KaufMyStuff.DomainModel.Services;
using Spg.KaufMyStuff.DomainModel.Services.Accounts;
using Spg.KaufMyStuff.DomainModel.Services.Products;
using Spg.KaufMyStuff.DomainModel.Interfaces;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel
{
    public static class ServicesConfiguration
    {
        public static void AddKmSRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryBase<Product>, RepositoryBase<Product>>();
            services.AddTransient<IReadOnlyRepositoryBase<Product>, RepositoryBase<Product>>();
            services.AddTransient<IReadOnlyRepositoryBase<Category>, RepositoryBase<Category>>();
        }

        public static void AddKmSServices(this IServiceCollection services) 
        {
            services.AddTransient<IReadOnlyProductService, ProductService>();
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<ILoginService, DbLoginService>();
        }
    }
}
