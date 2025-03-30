using CategoryDAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ProductDbContext _db;
        public CategoryRepository(ProductDbContext db) 
        { 
            _db = db;
        }
        public void Create(Category category)
        {
            _db.categories.Add(category);
            _db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _db.categories.ToList();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
