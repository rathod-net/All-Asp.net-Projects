using DAL.DataEntities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BAL
{
    public class ProductServices : IProductServices
    {
        IProductRepository _productRepo;
        public ProductServices(IProductRepository productRepo)
        {
            _productRepo= productRepo;
        }
        public void CreateProduct(Product product)
        {
            _productRepo.CreateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
        }

        public IEnumerable<Product> FindProducts(Expression<Func<Product, bool>> predicate)
        {
            return _productRepo.FindProducts(predicate);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _productRepo.GetProductsByCategory(categoryId);
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _productRepo.GetProductsByPriceRange(minPrice, maxPrice);
        }

        public IEnumerable<Product> SearchByName(string productName)
        {
            return _productRepo.SearchByName(productName);
        }

        public void UpdateProduct(Product product)
        {
            _productRepo.UpdateProduct(product);
        }
    }
}
