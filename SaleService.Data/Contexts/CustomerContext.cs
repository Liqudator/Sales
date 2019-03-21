using Microsoft.EntityFrameworkCore;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Sales.Domain;

namespace Sales.Data.Contexts
{
    /// <summary>
    /// Контекст покупателя.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста покупателя.
        /// </summary>
        public CustomerContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=W971W10;Database=SaleServiceDb;Trusted_Connection=True;");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
