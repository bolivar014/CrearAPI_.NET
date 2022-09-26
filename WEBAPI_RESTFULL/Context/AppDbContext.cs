using Microsoft.EntityFrameworkCore;
using WEBAPI_RESTFULL.Entities;

namespace WEBAPI_RESTFULL.Context
{
    public class AppDbContext : DbContext
    {
        // Compartimos clase DBContext hacía las caracteristicas de EntityFramework
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Especificamos las tablas que van a hacer parte del DbContext ya sea 1 o muchas desde entities
        public DbSet<Producto> Producto { get; set; }

    }
}
