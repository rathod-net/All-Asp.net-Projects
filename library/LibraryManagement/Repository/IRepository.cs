using DAL.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Add(Book entity);
        void Update(Book entity);
        void Delete(int id);
    }
}
