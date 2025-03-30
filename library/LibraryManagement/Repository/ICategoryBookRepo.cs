using DAL.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryBookRepo
    {
        IEnumerable<CategoryBook> GetCategoryAll();
        CategoryBook GetCategoryById(int id);
    }
}
