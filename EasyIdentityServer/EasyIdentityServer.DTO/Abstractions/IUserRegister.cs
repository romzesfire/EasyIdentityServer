using System.Net;
using EasyIdentityServer.DTO.Model;

namespace EasyIdentityServer.DTO.Abstractions;

public interface IUserRegister
{
    Task<UserCredentials> Register(UserCreationModel userCreationModel, IPAddress ip);
}