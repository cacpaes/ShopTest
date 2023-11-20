using Microsoft.EntityFrameworkCore;
using ShopTest.Entities;

namespace ShopTest.Configurations
{
    public class ContextBase : DbContext 
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) {}

        public DbSet<People> People { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TypesReference> TypesReference { get; set; }
        public DbSet<Sells> SellList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=CarlosShop;Integrated Security=True; TrustServerCertificate=True;");
        }
    }
}