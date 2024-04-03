﻿using Viajeros.Data.Models;

namespace Viajeros.Services;

public interface IVideoService
{
    public Video GetVideo(int id);
    public List<Video> GetAllVideos();
    public void AddVideo(Video video);
    public void RemoveVideo(Video video);
    public void UpdateVideo(Video video);
    public Task<Video> GetVideoAsync(int id);
    public Task<List<Video>> GetAllVideosAsync();
    public Task AddVideoAsync(Video video);
    public Task RemoveVideoAsync(Video video);
    public Task UpdateVideoAsync(Video video);
}
