using Viajeros.Data.Models;
using Viajeros.UnitOfWork;

namespace Viajeros.Services;

public class ImageService(IUnitOfWork unitofWork) : IImageService
{
    public async Task AddImageAsync(PostImage image)
    {
        await unitofWork.ImageRepository.AddAsync(image);
        await unitofWork.SaveAsync();
    }

    public async Task AddImagesAsync(List<PostImage> images)
    {
        unitofWork.ImageRepository.AddRange(images);
        await unitofWork.SaveAsync();
    }
    public List<PostImage> GetImages()
    {
        return unitofWork.ImageRepository.GetAll();
    }
    public async Task<List<PostImage>> GetAllImagesAsync()
    {
        return await unitofWork.ImageRepository.GetAllAsync();
    }
    public Task<List<PostImage>> GetPostImagesAsync(int postId)
    {
        var images = unitofWork.ImageRepository.FindBy(i => i.PostId == postId);
        return Task.FromResult(images);
    }
    public async Task<PostImage> GetImageAsync(int id)
    {
        return await unitofWork.ImageRepository.FindByIdAsync(id);
    }

    public async Task RemoveImageAsync(PostImage image)
    {
        unitofWork.ImageRepository.Delete(image);
        await unitofWork.SaveAsync();
    }

    public async Task UpdateImageAsync(PostImage image)
    {
        unitofWork.ImageRepository.Edit(image);
        await unitofWork.SaveAsync();
    }

    public async Task RemoveImagesAsync(List<PostImage> images)
    {
        foreach (var image in images)
        {
            unitofWork.ImageRepository.Delete(image);
        }
        await unitofWork.SaveAsync();

    }
    public async Task RemoveImagesAsync(int postId)
    {
        var postImages = await GetPostImagesAsync(postId);
        foreach (var image in postImages)
        {
            unitofWork.ImageRepository.Delete(image);
        }
        await unitofWork.SaveAsync();

    }
}
