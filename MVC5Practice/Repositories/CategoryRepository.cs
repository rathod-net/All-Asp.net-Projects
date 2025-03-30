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
    public class CategoryRepository : ICategoryRepository
    {
        ProductDbContext _dbContext;
        public CategoryRepository(ProductDbContext dbContext) 
        { 
            _dbContext= dbContext;
        }
        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = new Category();
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Category> FindCategories(Expression<Func<Category, bool>> predicate)
        {
            return _dbContext.Categories.Where(predicate).ToList();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void UpdateCategory(Category category)
        {
            //Category cat = new Category();
            //cat.Name=category.Name;
            //cat.Rating=category.Rating;
            //_dbContext.Categories.Add(cat);
            //_dbContext.SaveChanges();
            // or below code
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges() ;
            
        }
    }
}
