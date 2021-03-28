using ApiService.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.DataAccessLayer
{
    public static class Helper
    {
        public static IServiceCollection InjectAllDependencies(this IServiceCollection serviceCollection, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("SqLiteConnectionString");
            var dbContextOptions = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            serviceCollection.AddScoped<IWebApiDBContext>(x=> new WebApiDBContext(dbContextOptions));

            serviceCollection.AddScoped<IMessageService>(x => new MessageService(x.GetService<IWebApiDBContext>()));

            serviceCollection.AddSingleton<IRoomManagerService>(new RoomManagerService());

            return serviceCollection;
        }
    }
}
