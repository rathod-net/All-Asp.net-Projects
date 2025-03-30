﻿using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Impletations;


namespace Repository.Interfaces
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) { await _dbSet.AddAsync(entity); }
        public void Update(T entity) { _dbSet.Update(entity); }
        public void Delete(T entity) { _dbSet.Remove(entity); }
        public async Task SaveAsync() { await _context.SaveChangesAsync(); }
    }
}

