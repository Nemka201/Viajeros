using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Viajeros.Data.Models;
using Viajeros.Data.Context;
namespace Noticias.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
   where T : class
    {
        private ViajerosContext _entities;

        public GenericRepository(ViajerosContext context)
        {
            _entities = context;
        }
        public ViajerosContext db
        {

            get { return _entities; }
            set { _entities = value; }
        }
        public virtual List<T> GetAll()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query.ToList();
        }
        public List<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query.ToList();
        }
        public virtual void Attach(T entity)
        {
            _entities.Set<T>().Attach(entity);
        }
        public virtual bool Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            return true;
        }
        public virtual bool Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            return true;
        }
        public virtual bool Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            _entities.SaveChanges();
            return true;
        }

        public virtual bool SaveChanges(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _entities.Set<T>().Attach(entity);
            }
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
            return true;
        }
        public virtual T FindById(int id)
        {
            return _entities.Set<T>().Find(id);
        }

        // Async Methdos

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _entities.Set<T>();
            return await query.ToListAsync();
        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return await query.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _entities.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await _entities.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task SaveAsync() => _entities.SaveChangesAsync();


        public Task SaveChangesAsync(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _entities.Set<T>().Attach(entity);
            }
            _entities.Entry(entity).State = EntityState.Modified;
            return _entities.SaveChangesAsync();
        }

        public Task<T> FindByIdAsync(int id)
        {
            return _entities.Set<T>().FindAsync(id).AsTask();
        }
    }
}
