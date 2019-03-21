using Microsoft.EntityFrameworkCore;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Sales.Domain;

namespace Sales.Data.Contexts
{
    /// <summary>
    /// Контекст БД.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class SaleContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста.
        /// </summary>
        public SaleContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=W971W10;Database=SaleServiceDb;Trusted_Connection=True;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
