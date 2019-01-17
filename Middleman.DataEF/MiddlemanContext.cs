using Middleman.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleman.DataEF
{
    public class MiddlemanContext : DbContext
    {
        public MiddlemanContext() : base("DefaultConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ProductInStock> ProductInStocks { get; set; }
        public DbSet<ChangeState> ChangeStates { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Messenger> Messengers { get; set; }

    }
}
