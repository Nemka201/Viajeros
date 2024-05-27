using Viajeros.Data.Models;
using Viajeros.UnitOfWork;
using static System.Net.Mime.MediaTypeNames;

namespace Viajeros.Services;

public class ImageService : IImageService
{
    private readonly IUnitOfWork _unitOfWork;
    public ImageService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }

    public async Task AddImageAsync(PostImage image)
    {
        await _unitOfWork.ImageRepository.AddAsync(image);
        await _unitOfWork.SaveAsync();
    }

    public async Task AddImagesAsync(List<PostImage> images)
    {
        _unitOfWork.ImageRepository.AddRange(images);
        await _unitOfWork.SaveAsync();
    }
    public List<PostImage> GetImages()
    {
        return _unitOfWork.ImageRepository.GetAll();
    }
    public async Task<List<PostImage>> GetAllImagesAsync()
    {
        return await _unitOfWork.ImageRepository.GetAllAsync();
    }
    public Task<List<PostImage>> GetPostImagesAsync(int postId)
    {
        var images = _unitOfWork.ImageRepository.FindBy(i => i.PostId == postId);
        return Task.FromResult(images);
    }
    public async Task<PostImage> GetImageAsync(int id)
    {
        return await _unitOfWork.ImageRepository.FindByIdAsync(id);
    }

    public async Task RemoveImageAsync(PostImage image)
    {
        await _unitOfWork.ImageRepository.DeleteAsync(image);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateImageAsync(PostImage image)
    {
        _unitOfWork.ImageRepository.Edit(image);
        await _unitOfWork.SaveAsync();
    }
}
