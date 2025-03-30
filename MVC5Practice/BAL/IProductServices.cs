using DAL.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);

        IEnumerable<Product> FindProducts(Expression<Func<Product, bool>> predicate);
        IEnumerable<Product> GetProductsByCategory(int categoryId);

        IEnumerable<Product> SearchByName(string productName);
        IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice);
    }
}
