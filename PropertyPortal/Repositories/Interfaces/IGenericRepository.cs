using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPortal.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Update(T entity);
        void Save();
    }
}
