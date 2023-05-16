using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;
        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            if (entity is null) { throw new ArgumentNullException(nameof(entity)); }
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            if (entity is null) { throw new ArgumentNullException(nameof(entity)); }
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            if(id is null) { throw new ArgumentNullException(nameof(id));}
            var model = await _entities.FindAsync(id);
            if (model is null) { throw new NullReferenceException(nameof(model)); }
            return model;
        }

        public async Task Update(T entity)
        {
            if(entity is null) { throw new ArgumentNullException(nameof(entity)); }
             _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
