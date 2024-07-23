using Viajeros.Data.Models;
using Viajeros.UnitOfWork;

namespace Viajeros.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        public void AddTag(Tag tag)
        {
            _unitOfWork.TagRepository.Add(tag);
            _unitOfWork.Save();
        }

        public async Task AddTagAsync(Tag tag)
        {
            await _unitOfWork.TagRepository.AddAsync(tag);
            await _unitOfWork.SaveAsync();
        }

        public List<Tag> GetAllTags()
        {
            return _unitOfWork.TagRepository.GetAll();
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _unitOfWork.TagRepository.GetAllAsync();
        }

        public Tag GetTag(int id)
        {
            return _unitOfWork.TagRepository.FindById(id);
        }

        public async Task<Tag> GetTagAsync(int id)
        {
            return await _unitOfWork.TagRepository.FindByIdAsync(id);
        }

        public void RemoveTag(Tag tag)
        {
            _unitOfWork.TagRepository.Delete(tag);
            _unitOfWork.Save();
        }

        public async Task RemoveTagAsync(Tag tag)
        {
            _unitOfWork.TagRepository.Delete(tag);
            await _unitOfWork.SaveAsync();
        }

        public void UpdateTag(Tag tag)
        {
            _unitOfWork.TagRepository.Edit(tag);
            _unitOfWork.Save();
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            _unitOfWork.TagRepository.Edit(tag);
            await _unitOfWork.SaveAsync();
        }
    }
}
