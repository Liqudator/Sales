using Microsoft.EntityFrameworkCore;
using Midway.Common.Ioc.Attributes;
using Midway.Common.Ioc.Domain;
using Sales.Domain;

namespace Sales.Data.Contexts
{
    /// <summary>
    /// Контекст продавца.
    /// </summary>
    [InstanceScope(InstanceScope.Singleton)]
    public class SellerContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста покупателя.
        /// </summary>
        public SellerContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=W971W10;Database=SaleServiceDb;Trusted_Connection=True;");
        }

        public DbSet<Seller> Sellers { get; set; }
    }
}
