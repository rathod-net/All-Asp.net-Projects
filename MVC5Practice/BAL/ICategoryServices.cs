using DAL.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BAL
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(int id);

        IEnumerable<Category> FindCategories(Expression<Func<Category, bool>> predicate);
    }
}
