using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace ApiService.DataAccessLayer
{
    public class WebApiDBContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public WebApiDBContext(DbContextOptions<WebApiDBContext> options) : base(options)
        {
        }
    }
}