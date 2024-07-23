using Serilog;
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
        try
        {
            // Validate tag association
            if (!video.Tags.Any())
            {
                throw new ArgumentException("El video debe tener al menos 1 Tag");
            }
            _unitOfWork.VideoRepository.Add(video);
            await _unitOfWork.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error en el servicio" + ex.Message);
        }
    }



    public List<Video> GetAllVideos()
    {
        return _unitOfWork.VideoRepository.GetAll();
    }

    public async Task<List<Video>> GetAllVideosAsync()
    {
        var videos = await _unitOfWork.VideoRepository.GetAllAsync();
        foreach (var video in videos)
        {
            await _unitOfWork.VideoTagRepository
                .FindByAsync(vt => vt.VideoID == video.Id); // Carga los VideoTag relacionados
        }
        return videos;
    }

    public async Task<int> GetCountAsync()
    {
        return await _unitOfWork.VideoRepository.GetCountAsync();
    }


    public Video GetVideo(int id)
    {
        return _unitOfWork.VideoRepository.FindById(id);
    }

    public async Task<Video> GetVideoAsync(int id)
    {
        return await _unitOfWork.VideoRepository.FindByIdAsync(id);
    }
    public async Task<List<Video>> GetVideoByIndexAsync(int pageIndex, int pageSize)
    {
        return await _unitOfWork.VideoRepository.GetByIndexAsync(pageIndex, pageSize);
    }
    public void RemoveVideo(Video video)
    {
        _unitOfWork.VideoRepository.Delete(video);
        _unitOfWork.Save();
    }

    public async Task RemoveVideoAsync(Video video)
    {
        // Uso LINQ para obtener los video tags para el ID del video
        var videoTags = await _unitOfWork.VideoTagRepository.FindByAsync(vt => vt.VideoID == video.Id);


        // Elimino los video tags relacionados
        foreach (var videoTag in videoTags)
        {
            _unitOfWork.VideoTagRepository.Delete(videoTag);
        }

        // Elimino el video
        _unitOfWork.VideoRepository.Delete(video);

        // Guardo los cambios en la base de datos
        await _unitOfWork.SaveAsync();
    }



    public void UpdateVideo(Video video)
    {
        _unitOfWork.VideoRepository.Edit(video);
        _unitOfWork.Save();
    }

    public async Task UpdateVideoAsync(Video video)
    {
        // Obtener los video tags del video asociado
        var originalVideoTags = await _unitOfWork.VideoTagRepository.FindByAsync(vt => vt.VideoID == video.Id);

        // Modificar los cambios del video
        _unitOfWork.VideoRepository.Edit(video);

        // Manejar los posibles cambios de los video tags
        //var updatedVideoTags = video.Tags; // Obtener los video tags actualizados
        //var newVideoTags = updatedVideoTags.Where(vt => !originalVideoTags.Any(ot => ot.Id == vt.Id)).ToList(); // Nuevos tags
        //var removedVideoTags = originalVideoTags.Where(ot => !updatedVideoTags.Any(ut => ut.Id == ot.Id)).ToList(); // Tags removidos

        
        // Eliminar los video tags removidos
        foreach (var removedVideoTag in originalVideoTags)
        {
            _unitOfWork.VideoTagRepository.Delete(removedVideoTag);
        }

        // Guardar los cambios en la base e datos
        await _unitOfWork.SaveAsync();
    }

    public List<Video> FindByName(string name)
    {
        return _unitOfWork.VideoRepository.FindBy(v => v.Name == name);
    }
    public List<Video> FindByTag(int tagId)
    {
        return _unitOfWork.VideoRepository.FindBy(v => v.Tags.Any(t => t.Id == tagId));
    }
    public async Task<List<Video>> GetLastsVideosAsync()
    {
        return await _unitOfWork.VideoRepository.GetLastByDateAsync(n => n.Date);
    }
}
