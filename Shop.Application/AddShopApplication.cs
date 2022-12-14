using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.UsersContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application
{
    public static class AddShopApplication
    {
        public static IServiceCollection InstallShopApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserContext, UserContext>();

            return services;
        }
    }
}
