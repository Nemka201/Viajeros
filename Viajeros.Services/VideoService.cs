using Viajeros.Data.Models;
using Viajeros.UnitOfWork;

namespace Viajeros.Services;

public class VideoService : IVideoService
{
    private readonly IUnitOfWork _unitOfWork;
    public VideoService(IUnitOfWork unitofWork)
    {
        _unitOfWork = unitofWork;
    }
    public void AddVideo(Video video)
    {
        _unitOfWork.VideoRepository.Add(video);
        _unitOfWork.Save();
    }

    public async Task AddVideoAsync(Video video)
    {
        await _unitOfWork.VideoRepository.AddAsync(video);
        await _unitOfWork.SaveAsync();
    }

    public List<Video> GetAllVideos()
    {
        return _unitOfWork.VideoRepository.GetAll();
    }

    public async Task<List<Video>> GetAllVideosAsync()
    {
        return await _unitOfWork.VideoRepository.GetAllAsync();
    }

    public Video GetVideo(int id)
    {
        return _unitOfWork.VideoRepository.FindById(id);
    }

    public async Task<Video> GetVideoAsync(int id)
    {
        return await _unitOfWork.VideoRepository.FindByIdAsync(id);
    }

    public void RemoveVideo(Video video)
    {
        _unitOfWork.VideoRepository.Delete(video);
        _unitOfWork.Save();
    }

    public async Task RemoveVideoAsync(Video video)
    {
        await _unitOfWork.VideoRepository.DeleteAsync(video);
        await _unitOfWork.SaveAsync();
    }

    public void UpdateVideo(Video video)
    {
        _unitOfWork.VideoRepository.Edit(video);
        _unitOfWork.Save();
    }

    public async Task UpdateVideoAsync(Video video)
    {
        _unitOfWork.VideoRepository.Edit(video);
        await _unitOfWork.SaveAsync();
    }
}
