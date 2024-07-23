using Noticias.Repositories;
using Viajeros.Data.Models;

namespace Viajeros.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Post> PostRepository { get; }
    IGenericRepository<Tag> TagRepository { get; }
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Video> VideoRepository { get; }
    IGenericRepository<PostImage> ImageRepository { get; }
    IGenericRepository<VideoTag> VideoTagRepository { get; }


    void Save();
    Task<Task> SaveAsync();

}
