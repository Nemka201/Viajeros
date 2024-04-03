using Viajeros.Data.Models;
using Viajeros.UnitOfWork;

namespace Viajeros.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    public PostService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }
    public void AddPost(Post post)
    {
        _unitOfWork.PostRepository.Add(post);
        _unitOfWork.Save();
    }

    public async Task AddPostAsync(Post post)
    {
        await _unitOfWork.PostRepository.AddAsync(post);
        await _unitOfWork.SaveAsync();
    }

    public List<Post> GetAllPosts()
    {
        return _unitOfWork.PostRepository.GetAll();
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await _unitOfWork.PostRepository.GetAllAsync();
    }

    public Post GetPost(int id)
    {
        return _unitOfWork.PostRepository.FindById(id);
    }

    public async Task<Post> GetPostAsync(int id)
    {
        return await _unitOfWork.PostRepository.FindByIdAsync(id);
    }

    public void RemovePost(Post post)
    {
        _unitOfWork.PostRepository.Delete(post);
        _unitOfWork.Save();
    }

    public async Task RemovePostAsync(Post post)
    {
        await _unitOfWork.PostRepository.DeleteAsync(post);
        await _unitOfWork.SaveAsync();
    }

    public void UpdatePost(Post post)
    {
        _unitOfWork.PostRepository.Edit(post);
        _unitOfWork.Save();
    }

    public async Task UpdatePostAsync(Post post)
    {
        _unitOfWork.PostRepository.Edit(post);
        await _unitOfWork.SaveAsync();
    }
}
