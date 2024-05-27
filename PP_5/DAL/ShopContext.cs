using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PP_5.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PP_5.DAL
{
    public class ShopContext: DbContext
    {
        public ShopContext(): base("ShopContext") { }

        public DbSet<Product> Products { get; set;}
        public DbSet<Provider> Providers { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Component_Type> ComponentTypes { get; set;}
        public DbSet<Product_in_Order> Product_in_Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}