using DAL.DataEntity;
using DAL.DBContextEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : IRepository
    {
         LibraryDBContext _libraryDBContext;
         

        public BookRepository(LibraryDBContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
           
        }

        public IEnumerable<Book> GetAll()
        {
            return _libraryDBContext.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _libraryDBContext.Books.Find(id);
        }

        public void Add(Book entity)
        {
            _libraryDBContext.Books.Add(entity);
            _libraryDBContext.SaveChanges();
        }

        public void Update(Book entity)
        {
            _libraryDBContext.Entry(entity).State = EntityState.Modified;
            _libraryDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _libraryDBContext.Books.Find(id);
            if (entity != null)
            {
                _libraryDBContext.Books.Remove(entity);
                _libraryDBContext.SaveChanges();
            }
        }









    }
}
