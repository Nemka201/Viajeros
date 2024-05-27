using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viajeros.Data.Models;

namespace Viajeros.Services;

public interface IImageService
{
    public Task<PostImage> GetImageAsync(int id);
    public Task<List<PostImage>> GetAllImagesAsync();
    public Task AddImageAsync(PostImage image);
    public Task<List<PostImage>> GetPostImagesAsync(int postId);
    public Task AddImagesAsync(List<PostImage> images);
    public Task RemoveImageAsync(PostImage image);
    public Task UpdateImageAsync(PostImage image);
    public List<PostImage> GetImages();
}
