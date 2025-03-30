using AutoMapper;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BAL
{
    public class CategoryBookBAL : ICategoryBookBAL
    {
        ICategoryBookRepo _categoryBookRepo;

         public CategoryBookBAL(ICategoryBookRepo categoryBookRepo)
        {
            _categoryBookRepo = categoryBookRepo;
        }

        public IEnumerable<BookViewModel> GetAllCategory()
        {
            var categories = _categoryBookRepo.GetCategoryAll().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.CategoryType,

            });
          
             return Mapper.Map<IEnumerable<BookViewModel>>(categories);
        }

        public BookViewModel GetCategoryById(int id)
        {
            var book = _categoryBookRepo.GetCategoryById(id);
            return Mapper.Map<BookViewModel>(book);
        }
    }
}
