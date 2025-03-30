using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface ICategoryBookBAL
    {
        IEnumerable<BookViewModel> GetAllCategory();
        BookViewModel GetCategoryById(int id);
    }
}
