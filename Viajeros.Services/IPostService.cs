using Viajeros.Data.DTO;
using Viajeros.Data.Models;

namespace Viajeros.Services;

public interface IPostService
{
    public Post GetPost(int id);
    public List<Post> GetAllPosts();
    public void AddPost(PostDTO post);
    public void RemovePost(Post post);
    public void UpdatePost(Post post);
    public Task<Post> GetPostAsync(int id);
    public Task<List<Post>> GetAllPostsAsync();
    public Task AddPostAsync(PostDTO post);
    public Task RemovePostAsync(Post post);
    public Task UpdatePostAsync(PostDTO postDto);
}
