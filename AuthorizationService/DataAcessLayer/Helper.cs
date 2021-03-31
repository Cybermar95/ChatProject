using AuthorizationService.BusinessLayer;
using AuthorizationService.DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.DataAccessLayer
{
    public static class Helper
    {
        public static IServiceCollection AddDB(this IServiceCollection serviceCollection, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SqLiteConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            serviceCollection.AddScoped<IAuthorizationServerDBContext>(x=> new AuthorizationServerDBContext(dbContextOptions)); //DI injection DB Context

            serviceCollection.AddScoped<IAuthService>(x => new AuthService(x.GetService<IAuthorizationServerDBContext>()));                 //DI injection auth service
            serviceCollection.AddScoped<IRegistrationService>(x => new RegistrationService(x.GetService<IAuthorizationServerDBContext>())); //DI injection registration service

            return serviceCollection;
        }
    }
}
