using DAL.DataEntities;
using DAL.DbContextEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDbContext _dbContext;
        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var cat= GetProductById(id);
            if (cat != null)
            {
                _dbContext.Products.Remove(cat);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Product> FindProducts(Expression<Func<Product, bool>> predicate)
        {
            return _dbContext.Products.Where(predicate).Include(p => p.Category).ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _dbContext.Products.Where(p=>p.CategoryId== categoryId).
                Include(p=>p.Category).ToList();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State=EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public IEnumerable<Product> SearchByName(string productName)
        {
            return _dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Name.Contains(productName))
                .ToList();
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _dbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }

    }
}
