using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.Infrastructure
{
    public static class SqlExtensions
    {
        public static void AddEd(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<KaufMyStuffContext>(options => options.UseSqlite(connectionString));
        }
    }
}
