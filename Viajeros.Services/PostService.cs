using Viajeros.Data.DTO;
using Viajeros.Data.Models;
using Viajeros.UnitOfWork;

namespace Viajeros.Services;

public class PostService(IUnitOfWork unitofWork, ImageService imageService) : IPostService
{
    public void AddPost(PostDTO post)
    {
        unitofWork.PostRepository.Add(post.Post);
        unitofWork.Save();
    }

    public async Task AddPostAsync(PostDTO postDto)
    {
        try
        {
            var post = postDto.Post;

            await unitofWork.PostRepository.AddAsync(post);
            await unitofWork.SaveAsync();

            // Verificar si hay URLs de imágenes y agregarlas
            if (postDto.ImagesURL != null && postDto.ImagesURL.Length > 0)
            {
                var postImages = postDto.ImagesURL.Select(imageUrl => new PostImage
                {
                    PostId = post.Id,
                    ImageUrl = imageUrl
                }).ToList();

                await imageService.AddImagesAsync(postImages);
            }
        }
        catch (Exception ex)
        {
            // Manejar errores (puedes loguear el error o enviar una respuesta de error)
            Console.WriteLine($"Error al agregar el post: {ex.Message}");
            throw; 
        }
    }

    public List<Post> GetAllPosts()
    {
        return unitofWork.PostRepository.GetAll();
    }

    public async Task<List<Post>> GetAllPostsAsync()
    {
        return await unitofWork.PostRepository.GetAllAsync();
    }

    public Post GetPost(int id)
    {
        return unitofWork.PostRepository.FindById(id);
    }

    public async Task<Post> GetPostAsync(int id)
    {
        return await unitofWork.PostRepository.FindByIdAsync(id);
    }

    public void RemovePost(Post post)
    {
        unitofWork.PostRepository.Delete(post);
        unitofWork.Save();
    }

    public async Task RemovePostAsync(Post post)
    {
        unitofWork.PostRepository.Delete(post);
        await unitofWork.SaveAsync();
    }

    public void UpdatePost(Post post)
    {
        unitofWork.PostRepository.Edit(post);
        unitofWork.Save();
    }

    public async Task UpdatePostAsync(PostDTO postDto)
    {
        try
        {
            var post = postDto.Post;

            // Eliminar todas las imágenes del post
            await imageService.RemoveImagesAsync(post.Id);

            // Verificar si hay URLs de imágenes y agregarlas
            if (postDto.ImagesURL != null && postDto.ImagesURL.Length > 0)
            {
                var postImagesDto = postDto.ImagesURL.Select(imageUrl => new PostImage
                {
                    PostId = post.Id,
                    ImageUrl = imageUrl
                }).ToList();

                await imageService.AddImagesAsync(postImagesDto);
            }

            // Actualizar el post
            unitofWork.PostRepository.Edit(post);
            await unitofWork.SaveAsync();

        }
        catch (Exception ex)
        {
            // Manejar errores (puedes loguear el error o enviar una respuesta de error)
            Console.WriteLine($"Error al modificar el post: {ex.Message}");
            throw;
        }
    }

}
