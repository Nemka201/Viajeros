using Viajeros.Data.Models;

namespace Viajeros.Services;

public interface IUserService
{
    public User GetUser(int id);
    public List<User> GetUsers();
    public void DeleteUser(User user);
    public void UpdateUser(User user);
    public void AddUser(User user);
    public User? Login(string email, string password);
    public void Logout();

    // Async

    public Task<User> GetUserAsync(int id);
    public Task<List<User>> GetUsersAsync();
    public Task DeleteUserAsync(User user);
    public Task UpdateUserAsync(User user);
    public Task AddUserAsync(User user);
    public Task<User>? LoginAsync(string email, string password);
    public Task LogoutAsync();
}
