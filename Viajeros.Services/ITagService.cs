using Viajeros.Data.Models;

namespace Viajeros.Services
{
    public interface ITagService
    {
        public Tag GetTag(int id);
        public List<Tag> GetAllTags();
        public void AddTag(Tag tag);
        public void RemoveTag(Tag tag);
        public void UpdateTag(Tag tag);
        public Task<Tag> GetTagAsync(int id);
        public Task<List<Tag>> GetAllTagsAsync();
        public Task AddTagAsync(Tag tag);
        public Task RemoveTagAsync(Tag tag);
        public Task UpdateTagAsync(Tag tag);
    }
}
