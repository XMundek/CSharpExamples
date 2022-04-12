using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace EF.Query
{
    public interface IProductService
    {
       Product[] GetProducts(string name);
    }
    public class ProductService:IProductService
    {
        public ProductService(): this(new ProductDbContext())
        {

        }
        private ProductDbContext dbContext;
        public ProductService(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Product[] GetProducts(string name)
        {
            return dbContext.Products
                .Where(p => p.Name.StartsWith(name))
                .OrderBy(p=>p.Name).ToArray();
        }
    }
}
