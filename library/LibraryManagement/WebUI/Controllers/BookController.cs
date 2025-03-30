using BAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebUI.Controllers
{

    public class BookController : Controller
    {
        // GET: Book
        IBookBAL _bookBAL;
        ICategoryBookBAL _categoryBookBAL;
      //  IMapper _mapper;
        public BookController(IBookBAL bookBAL, ICategoryBookBAL categoryBookBAL)
        {
            _bookBAL = bookBAL;
            _categoryBookBAL = categoryBookBAL;
           // _mapper = mapper;
        }
        [HttpGet]
        public ActionResult Index(string search)
        {
            var books = _bookBAL.GetAllBooks().AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                books = books.Where(b => b.Title.ToLower().Contains(search) ||
                b.ISBN.ToLower().Contains(search) ||
                b.AuthorName.ToLower().Contains(search) ||
                b.CategoryType.ToLower().Contains(search) ||
                b.PublicationName.ToLower().Contains(search) ||
                b.CreatedBy.ToLower().Contains(search));
            }
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
            
        }
        public IEnumerable<SelectListItem> GetAllData()
        {
            var books =_bookBAL.GetAllBooks().ToList();
            var categories =_categoryBookBAL.GetAllCategory().ToList();

            var viewModel = new BookViewModel()
            {
                Books = (IEnumerable<SelectListItem>)books,
                Categories = (IEnumerable<SelectListItem>)categories,
            };
            return (IEnumerable<SelectListItem>)View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _bookBAL.CreateBook(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            model.Categories = GetAllData();
            return View(model);
        }

        //public IEnumerable<SelectListItem> GetCategories()
        //{
        //    var categories = _categoryBookBAL.GetAllCategory().Select(b => new SelectListItem
        //    {
        //        Value = b.CategoryBookId.ToString(),
        //        Text = b.CategoryType,

        //    });
        //    ViewBag.categories = categories;
        //    return categories;
        //}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _bookBAL.GetBookById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookBAL.DeleteBook(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = _bookBAL.GetBookById(id);
            return View(model);
        }



        public ActionResult Edit(int id)
        {
            var model = _bookBAL.GetBookById(id);
            model.Categories = GetAllData();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookBAL.UpdateBook(model);
                return RedirectToAction("Index");
            }
            model.Categories = GetAllData();
            return View(model);
        }

    }
}