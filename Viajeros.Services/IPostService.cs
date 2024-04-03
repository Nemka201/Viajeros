using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajeros.Data.Models;

namespace Viajeros.Services;

public interface IPostService
{
    public Post GetPost(int id);
    public List<Post> GetAllPosts();
    public void AddPost(Post post);
    public void RemovePost(Post post);
    public void UpdatePost(Post post);
    public Task<Post> GetPostAsync(int id);
    public Task<List<Post>> GetAllPostsAsync();
    public Task AddPostAsync(Post post);
    public Task RemovePostAsync(Post post);
    public Task UpdatePostAsync(Post post);
}
