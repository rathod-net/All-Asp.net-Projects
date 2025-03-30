using DAL.DataEntities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _catRepo;
        public CategoryServices(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }

        public void CreateCategory(Category category)
        {
            _catRepo.CreateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _catRepo.DeleteCategory(id);
        }

        public IEnumerable<Category> FindCategories(Expression<Func<Category, bool>> predicate)
        {
            return _catRepo.FindCategories(predicate);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _catRepo.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _catRepo.GetCategoryById(id);
        }

        public void UpdateCategory(Category category)
        {
            _catRepo.UpdateCategory(category);
        }
    }
}
