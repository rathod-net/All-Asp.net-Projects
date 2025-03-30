using AutoMapper;
using CategoryDAL;
using CategoryModel;
using Repository;
using System;
using System.Collections.Generic;

namespace CategoryBAL
{
    public class CategoryBL : ICategoryBL
    {
        ICategoryRepository _repository;
        public CategoryBL(ICategoryRepository repository) 
        {
            _repository= repository;
        }
        public void Create(CategoryViewModel category)
        {
            var cat =Mapper.Map<Category>(category);
            _repository.Create(cat);
           
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryViewModel> GetAll()
        {
            var categories = _repository.GetAll();
            return Mapper.Map<List<CategoryViewModel>>(categories);
        }

        public CategoryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
