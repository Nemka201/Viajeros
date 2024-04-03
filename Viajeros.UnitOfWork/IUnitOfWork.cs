using Noticias.Repositories;
using Viajeros.Data.Models;

namespace Viajeros.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Post> PostRepository { get; }
    IGenericRepository<Tag> TagRepository { get; }
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Video> VideoRepository { get; }

    void Save();
    Task<Task> SaveAsync();

}
