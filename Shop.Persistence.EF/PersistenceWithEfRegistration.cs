using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Contracts.Persistence;
using Shop.Persistence.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF
{
    public static class PersistenceWithEfRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ShopConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentsRepository, CommentRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
