using EasyIdentityServer.Domain.Model;

namespace EasyIdentityServer.DTO.Abstractions;

public interface IUserRecorder
{
    public void Record(User user);
}