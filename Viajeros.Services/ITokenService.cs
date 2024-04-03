using Viajeros.Data.Models;
namespace Viajeros.Services;

public interface ITokenService
{
    User BuildToken(User user);
}
