using ApiService.BusinessLayer;
using ApiService.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiService
{
    public static class InjectHelper
    {
        public static IServiceCollection InjectAllDependencies(this IServiceCollection serviceCollection, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SqLiteConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            serviceCollection.AddScoped<IWebApiDBContext>(x => new WebApiDBContext(dbContextOptions));

            serviceCollection.AddScoped<IMessageService>(x => new MessageService(x.GetService<IWebApiDBContext>()));

            serviceCollection.AddSingleton<IRoomManagerService>(new RoomManagerService());

            serviceCollection.AddSingleton<IAccessDBContext>(new AccessDBContext(dbContextOptions));

            return serviceCollection;
        }
    }
}
