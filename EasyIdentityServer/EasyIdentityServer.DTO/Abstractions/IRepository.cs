namespace EasyIdentityServer.DTO.Abstractions;

public interface IRepository<in TId, TEnt>
{
    public Task<(bool, TEnt?)> TryGet(TId id);
}