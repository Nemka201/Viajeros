using Viajeros.Data.Models;
using Viajeros.Data.Utilities;
using Viajeros.UnitOfWork;

namespace Viajeros.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly TokenService _tokenService;

    public UserService(IUnitOfWork unitOfWork, TokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
    }

    public void AddUser(User user)
    {
        // Password encrypt SHA256
        user.Password = SHA256Encrypter.Convert(user.Password);
        _unitOfWork.UserRepository.Add(user);
        // Create JWT
        var token = _tokenService.BuildToken(user);
        _unitOfWork.Save();
    }

    public async Task AddUserAsync(User user)
    {
        // Password encrypt SHA256
        user.Password = SHA256Encrypter.Convert(user.Password);
        user = _tokenService.BuildToken(user);
        _unitOfWork.UserRepository.Add(user);
        // Create JWT
        await _unitOfWork.SaveAsync();
    }

    public void DeleteUser(User user)
    {
        _unitOfWork.UserRepository.Delete(user);
        _unitOfWork.Save();
    }

    public async Task DeleteUserAsync(User user)
    {
        await _unitOfWork.UserRepository.DeleteAsync(user);
        await _unitOfWork.SaveAsync();
    }

    public User GetUser(int id)
    {
        return _unitOfWork.UserRepository.FindById(id);
    }

    public async Task<User> GetUserAsync(int id)
    {
        return await _unitOfWork.UserRepository.FindByIdAsync(id);
    }

    public List<User> GetUsers()
    {
        return _unitOfWork.UserRepository.GetAll();
    }

    public Task<List<User>> GetUsersAsync()
    {
        return _unitOfWork.UserRepository.GetAllAsync();
    }

    public User? Login(string username, string password)
    {
        // Search for user in DB
        var user = _unitOfWork.UserRepository.FindBy(e => e.UserName == username).FirstOrDefault();
        // Compare password
        if (user == null || !user.Password.Equals(SHA256Encrypter.Convert(password)))
        {
            return null;
        }
        // Return JWT
        return _tokenService.BuildToken(user);
    }

    public async Task<User>? LoginAsync(string username, string password)
    {
        // Search for user in DB
        List<User> users = await _unitOfWork.UserRepository.FindByAsync(e => e.UserName == username);
        User? user = users.FirstOrDefault();
        // Compare password
        if (user == null || !user.Password.Equals(SHA256Encrypter.Convert(password)))
        {
            return null;
        }
        // Return JWT
        return _tokenService.BuildToken(user);

    }

    public void Logout()
    {
        throw new NotImplementedException();
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        _unitOfWork.UserRepository.Edit(user);
        _unitOfWork.Save();
    }

    public async Task UpdateUserAsync(User user)
    {
        _unitOfWork.UserRepository.Edit(user);
        await _unitOfWork.SaveAsync();
    }
}
