using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Noticias.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
        bool Save();
        bool SaveChanges(T entity);
        T FindById(int id);
        void AddRange(IEnumerable<T> entities);

        // Async methods
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task SaveAsync();
        Task SaveChangesAsync(T entity);
        Task<T> FindByIdAsync(int id);
        Task<List<T>> GetByIndexAsync(int pageIndex);
        Task<List<T>> GetLastByDateAsync(Expression<Func<T, DateTime>> dateSelector);
        Task<List<T>> GetByDateAndIndexAsync(Expression<Func<T, DateTime>> dateSelector, int pageIndex);
    }
}
