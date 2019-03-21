using Microsoft.EntityFrameworkCore;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Sales.Domain;

namespace Sales.Data.Contexts
{
    /// <summary>
    /// Контекст заказа.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class OrderContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста заказа.
        /// </summary>
        public OrderContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=W971W10;Database=SaleServiceDb;Trusted_Connection=True;");
        }

        public DbSet<Order> Orders { get; set; }
    }
}
