namespace EasyIdentityServer.DTO.Abstractions;

public interface ISecretKeyGenerator
{
    public Task<string> GenerateAsync(int keyLength = 64);
}