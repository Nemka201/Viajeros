using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;
using Viajeros.Data.Context;
namespace Noticias.Repositories
{
    public class GenericRepository<T>(ViajerosContext context) : IGenericRepository<T>
   where T : class
    {
        public ViajerosContext Db
        {
            get { return context; }
            set { context = value; }
        }
        public virtual List<T> GetAll()
        {
            IQueryable<T> query = context.Set<T>();
            return [.. query];
        }
        public List<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = context.Set<T>().Where(predicate);
            return [.. query];
        }
        public virtual void Attach(T entity)
        {
            context.Set<T>().Attach(entity);
        }
        public virtual bool Add(T entity)
        {
            context.Set<T>().Add(entity);
            return true;
        }
        public virtual bool Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return true;
        }
        public virtual bool Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            context.SaveChanges();
            return true;
        }

        public virtual bool SaveChanges(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }
        public virtual T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            context.AddRange(entities);
        }
        // Async Methdos

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = context.Set<T>();
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();


            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();

        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = context.Set<T>().Where(predicate);
            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task SaveAsync() => context.SaveChangesAsync();


        public Task SaveChangesAsync(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Set<T>().Attach(entity);
            }
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync();
        }

        public Task<T> FindByIdAsync(int id)
        {
            return context.Set<T>().FindAsync(id).AsTask();
        }
        public async Task<List<T>> GetByIndexAsync(int pageIndex)
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("El índice de página debe ser mayor o igual a cero.", nameof(pageIndex));
            }

            const int pageSize = 10;
            int indexBase = pageIndex * pageSize;

            IQueryable<T> query = context.Set<T>()
                .Skip(indexBase)
                .Take(pageSize);

            try
            {
                return await query.ToListAsync();
            }
            catch (DbException ex)
            {
                // Manejar errores de base de datos (puedes loguear el error o lanzar una excepción personalizada)
                Console.WriteLine($"Error al obtener los posts: {ex.Message}");
                throw;
            }
        }
        public async Task<List<T>> GetByIndexAsync(int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("El índice de página debe ser mayor o igual a cero.", nameof(pageIndex));
            }

            int indexBase = pageIndex * pageSize;

            IQueryable<T> query = context.Set<T>()
                .Skip(indexBase)
                .Take(pageSize);

            try
            {
                return await query.ToListAsync();
            }
            catch (DbException ex)
            {
                // Manejar errores de base de datos (puedes loguear el error o lanzar una excepción personalizada)
                Console.WriteLine($"Error al obtener los posts: {ex.Message}");
                throw;
            }
        }

        public async Task<List<T>> GetLastByDateAsync(Expression<Func<T, DateTime>> dateSelector)
        {
            IQueryable<T> query = context.Set<T>().OrderByDescending(dateSelector);
            // Take 8 elements
            return await query.Take(8).ToListAsync();
        }
        public async Task<List<T>> GetByDateAndIndexAsync(
            Expression<Func<T, DateTime>> dateSelector,
            int pageIndex)
        {
            const int pageSize = 10;
            int indexBase = pageIndex * pageSize;

            IQueryable<T> query = context.Set<T>()
                .OrderBy(dateSelector)
                .Skip(indexBase)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetByDateAndIndexAsync(
        Expression<Func<T, DateTime>> dateSelector, int pageIndex, int pageSize)
        {
            int indexBase = pageIndex * pageSize;

            IQueryable<T> query = context.Set<T>()
                .OrderBy(dateSelector)
                .Skip(indexBase)
                .Take(pageSize);

            return await query.ToListAsync();
        }
        public async Task<int> GetCountAsync()
        {
            return await context.Set<T>().CountAsync();
        }
    }
}
