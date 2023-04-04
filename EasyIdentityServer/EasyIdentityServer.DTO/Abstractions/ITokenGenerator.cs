using System.Net;
using EasyIdentityServer.DTO.Model;

namespace EasyIdentityServer.DTO.Abstractions;

public interface ITokenGenerator
{
    Task<TokenModel> Generate(UserCredentials credentials, IPAddress ip);
}