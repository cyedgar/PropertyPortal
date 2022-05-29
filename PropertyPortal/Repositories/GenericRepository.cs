using Microsoft.EntityFrameworkCore;
using PropertyPortal.Data;
using PropertyPortal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PropertyPortal.Extensions;

namespace PropertyPortal.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected ApplicationDbContext _context = null;
        protected DbSet<T> _table = null;

        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            _table = _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

 

        public async Task<T> Get(int id)
        {
            return await _table.FindAsync(id);
        }
        public IQueryable<T> GetAll()
        {
            return _table;
        }
        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }
    }
}
