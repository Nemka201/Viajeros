using System.Linq.Expressions;

namespace Noticias.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public void Attach(T entity);

        // Devuelve todos los elemento
        List<T> GetAll();

        // Devuelve los elementos utilizando LINQ
        List<T> FindBy(Expression<Func<T, bool>> predicate);

        // Agrega un elemento
        bool Add(T entity);

        // Elimina un elemento
        bool Delete(T entity);

        // Modifica un elemento
        bool Edit(T entity);

        // Guarda los cambios en la DB
        bool Save();

        // Guarda los cambios de la tabla indicada en la DB
        bool SaveChanges(T entity);

        // Devuelve el elemento por ID
        T FindById(int id);
        void AddRange(IEnumerable<T> entities);

        // Async methods

        // Devuelve todos los elemento
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        // Devuelve cantidad de elementos
        Task<int> GetCountAsync();

        // Devuelve los elementos utilizando LINQ
        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        // Agrega un elemento
        Task<T> AddAsync(T entity);

        // Elimina un elemento
        Task<T> DeleteAsync(T entity);

        // Guarda los cambios
        Task SaveAsync();

        // Guarda los cambios de la tabla indicada
        Task SaveChangesAsync(T entity);

        // Busca por ID
        Task<T> FindByIdAsync(int id);

        // Devuelve de manera indexada 8 elementos
        Task<List<T>> GetByIndexAsync(int pageIndex);

        // Devuelve de manera indexada pageSize de elementos
        Task<List<T>> GetByIndexAsync(int pageIndex, int pageSize);

        // Devuelve ordenado por los ultimos elementos
        Task<List<T>> GetLastByDateAsync(Expression<Func<T, DateTime>> dateSelector);

        // Devuelve ordenado por los ultimos elementos de manera indexada 8 elementos
        Task<List<T>> GetByDateAndIndexAsync(Expression<Func<T, DateTime>> dateSelector, int pageIndex);

        // Devuelve ordenaro por los ultimos elementos de manera indexada pageSize elementos
        Task<List<T>> GetByDateAndIndexAsync(Expression<Func<T, DateTime>> dateSelector, int pageIndex, int pageSize); 

    }
}
