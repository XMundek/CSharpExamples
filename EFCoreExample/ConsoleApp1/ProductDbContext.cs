using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Query
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext() { }
        public ProductDbContext(DbContextOptions<ProductDbContext> o) : base(o) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public static readonly LoggerFactory MyLoggerFactory
             = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseSqlServer(@"Server=.;Database=ProductsDB;Trusted_Connection=True;");
           // optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<SubCategory>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "C1"},
                new Category {Id = 2,Name = "C2" });
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory() { Id = 1, Name = "S1",CategoryId=1 },
                new SubCategory() { Id = 2, Name = "S2",CategoryId=1 },
                new SubCategory() { Id = 3, Name = "S3", CategoryId=2 },
                new SubCategory() { Id = 4, Name = "S4", CategoryId=2 });
            modelBuilder.Entity<Product>().HasData(
                new Product() {Id=1,Name="P1",SubCategoryId=1},
                new Product() {Id=2, Name = "P2", SubCategoryId = 1 },
                new Product() {Id=3, Name = "P3", SubCategoryId = 2 },
                new Product() {Id=4, Name = "P4", SubCategoryId = 4}
                );
               //modelBuilder.Entity<Product>().Property(p => p.Name).IsConcurrencyToken(true);
            modelBuilder.Entity<Product>().Property(p => p.RowVersion).IsRowVersion();
        }
    }
}
