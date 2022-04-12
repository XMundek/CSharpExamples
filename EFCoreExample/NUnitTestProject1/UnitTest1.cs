using EF.Query;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class ProductServiceTests
    {
        [Test]
        public void GetProductsTests ()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase("PST").Options;
            using (var dbContext = new ProductDbContext(options))
            {
                dbContext.Products.Add(new Product() { Name = "Piwo" });
                dbContext.Products.Add(new Product() { Name = "Chleb" });
                dbContext.Products.Add(new Product() { Name = "Cebula" });
                dbContext.SaveChanges();
            }
            using (var dbContext = new ProductDbContext(options))
            {
                var service = new ProductService(dbContext);
                {
                    var products = service.GetProducts("C");
                    Assert.NotNull(products);
                    Assert.AreEqual(2, products.Length);
                    Assert.AreEqual("Cebula", products[0].Name);
                    Assert.AreEqual("Chleb", products[1].Name);
                }
            }
        }
    }
}