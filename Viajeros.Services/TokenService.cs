using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Viajeros.Data.Models;

namespace Viajeros.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    public TokenService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public User BuildToken(User user)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var expiresToken = DateTime.UtcNow.AddHours(_jwtSettings.LifeTime);
        var header = new JwtHeader(signingCredentials);
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Rol)
        };

        var payload = new JwtPayload(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresToken);

        var token = new JwtSecurityToken(header, payload);

        user.Token = new JwtSecurityTokenHandler().WriteToken(token);
        user.Password = null;

        return user;
    }
    public static Claim[] GetClaims(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        var claims = jwtToken.Claims.ToArray();
        return claims;
    }
}
