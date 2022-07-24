using Auxiomize.Data.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auxiomize.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GrossTurnoverByProduct> GrossTurnoverByProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Category>().HasData(new Category(1, "Bevarage"));
            //modelBuilder.Entity<Category>().HasData(new Category(2, "Book"));
            //modelBuilder.Entity<Category>().HasData(new Category(3, "ConsumerGoods"));

            modelBuilder.Entity<Product>().ToTable("Product");
            //modelBuilder.Entity<Product>(e => e.HasOne(x => x.Category));
            //modelBuilder.Entity<Product>().HasData(new Product("CocaCola", 1.75m, "12345678", 1));
            //modelBuilder.Entity<Product>().HasData(new Product("The Great Gatsby", 15.50m, "123456789", 2));
            //modelBuilder.Entity<Product>().HasData(new Product("Pants", 50.00m, "12345678910", 3));

            base.OnModelCreating(modelBuilder);
        }
    }
}
