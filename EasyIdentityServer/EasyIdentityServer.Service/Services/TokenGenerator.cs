using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using EasyIdentityServer.Domain.Model;
using EasyIdentityServer.DTO;
using EasyIdentityServer.DTO.Abstractions;
using EasyIdentityServer.DTO.Exception;
using EasyIdentityServer.DTO.Model;
using EasyTradeLibs.Constants;
using Microsoft.IdentityModel.Tokens;

namespace EasyIdentityServer.Service.Services;

public class TokenGenerator : ITokenGenerator
{
    private readonly IRepository<Guid, User> _usersRepository;
    private readonly IKeyHasher _hasher;

    public TokenGenerator(IRepository<Guid, User> usersRepository, IKeyHasher hasher)
    {
        _usersRepository = usersRepository;
        _hasher = hasher;
    }

    public async Task<TokenModel> Generate(UserCredentials credentials, IPAddress ip)
    {
        var userExist = await _usersRepository.TryGet(credentials.UserId);
        var hashCredential = _hasher.Hash(credentials.SecretKey);
        if (!userExist.Item1)
        {
            throw new UserNotExistException();
        }
        var user = userExist.Item2;
        if (!hashCredential.SequenceEqual(user.SecretKeyHash))
        {
            throw new InvalidCredentialsException();
        }
        if (!ip.Equals(user.IpAddress))
        {
            throw new InvalidCredentialsException();
        }
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, credentials.UserId.ToString()),
            new (ClaimTypes.Role, "User")
        };
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new TokenModel(credentials.UserId, token);
    }
}