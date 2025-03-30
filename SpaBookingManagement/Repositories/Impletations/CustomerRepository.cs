using DataModel.DbContextEntity;
using DataModel.Entites;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Impletations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAll() => await _context.Customers.ToListAsync();
        public async Task<Customer> GetById(int id) => await _context.Customers.FindAsync(id);
        public async Task Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Customer customer)
        {
         //   _context.Customers.Update(customer);
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity != null)
            {
                _context.Customers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
