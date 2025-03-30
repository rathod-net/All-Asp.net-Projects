using DAL.DataEntity;
using DAL.DBContextEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryBookRepo : ICategoryBookRepo
    {
        LibraryDBContext _libraryDBContext;


        public CategoryBookRepo(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;

        }
        public CategoryBook GetCategoryById(int id)
        {
            return _libraryDBContext.CategoryBooks.Find(id);
        }

        public IEnumerable<CategoryBook> GetCategoryAll()
        {
            return _libraryDBContext.CategoryBooks.ToList();
        }
    }
}
