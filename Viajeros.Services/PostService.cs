using System.Collections.Generic;
using Viajeros.Data.DTO;
using Viajeros.Data.Models;
using Viajeros.UnitOfWork;

namespace Viajeros.Services;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ImageService _imageService;
    public PostService(IUnitOfWork unitofWork, ImageService imageService)
    {
        _unitOfWork = unitofWork;
        _imageService = imageService;
    }
    public void AddPost(PostDTO post)
    {
        _unitOfWork.PostRepository.Add(post.Post);
        _unitOfWork.Save();
    }

    public async Task AddPostAsync(PostDTO postDto)
    {
        var post = postDto.Post;
        await _unitOfWork.PostRepository.AddAsync(post);
        await _unitOfWork.SaveAsync();

        // Verificar si hay URLs de imágenes y agregarlas
        if (postDto.ImagesURL != null && postDto.ImagesURL.Any())
        {
            var postImages = postDto.ImagesURL.Select(imageUrl => new PostImage
            {
                PostId = post.Id,
                ImageUrl = imageUrl
            }).ToList();

            await _imageService.AddImagesAsync(postImages);
        }
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
