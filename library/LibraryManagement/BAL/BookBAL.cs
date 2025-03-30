using AutoMapper;
using DAL.DataEntity;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BookBAL : IBookBAL
    {
        IRepository _bookRepository;
        public BookBAL(IRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookViewModel> GetAllBooks()
        {
            var books = _bookRepository.GetAll();
            return Mapper.Map<IEnumerable<BookViewModel>>(books);
        }

        public BookViewModel GetBookById(int id)
        {
            var book = _bookRepository.GetById(id);
            return Mapper.Map<BookViewModel>(book);
        }

        public void CreateBook(BookViewModel model)
        {
            var existingBook = _bookRepository.GetAll().FirstOrDefault(b => b.ISBN == model.ISBN);
            if (existingBook != null)
            {
                throw new Exception("A book with the same ISBN already exists.");
            }

            var book = Mapper.Map<Book>(model);
            _bookRepository.Add(book);
        }

        public void UpdateBook(BookViewModel model)
        {
            var book = Mapper.Map<Book>(model);
            _bookRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
