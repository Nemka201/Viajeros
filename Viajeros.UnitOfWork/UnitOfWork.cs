using Noticias.Repositories;
using Viajeros.Data.Context;
using Viajeros.Data.Models;

namespace Viajeros.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ViajerosContext _context;
    private bool _disposed = false;
    private IGenericRepository<Post> postRepository;
    private IGenericRepository<Tag> tagRepository;
    private IGenericRepository<User> userRepository;
    private IGenericRepository<Video> videoRepository;
    private IGenericRepository<PostImage> imageRepository;

    public UnitOfWork() 
    {
        _context = new ViajerosContext();
    }

    public IGenericRepository<Tag> TagRepository => tagRepository ??= new GenericRepository<Tag>(_context);
    public IGenericRepository<Post> PostRepository => postRepository ??= new GenericRepository<Post>(_context);
    public IGenericRepository<User> UserRepository => userRepository ??= new GenericRepository<User>(_context);
    public IGenericRepository<Video> VideoRepository => videoRepository ??= new GenericRepository<Video>(_context);
    public IGenericRepository<PostImage> ImageRepository => imageRepository ??= new GenericRepository<PostImage>(_context);

    public void Save()
    {
        _context.SaveChanges();
    }
    public async Task<Task> SaveAsync()
    {
        await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
