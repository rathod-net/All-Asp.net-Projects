using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public interface IBookBAL
    {
        IEnumerable<BookViewModel> GetAllBooks();
        BookViewModel GetBookById(int id);
        void CreateBook(BookViewModel model);
        void UpdateBook(BookViewModel model);
        void DeleteBook(int id);
    }
}
