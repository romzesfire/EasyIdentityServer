using System.Security.Cryptography;
using EasyIdentityServer.DTO.Abstractions;

namespace EasyIdentityServer.Service.Services;

public class SecretKeyGenerator : ISecretKeyGenerator
{
    private string GenerateKey(int keyLength)
    {
        var bytes = new Span<byte>(new byte[keyLength]);
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToBase64String(bytes);
    }
    public async Task<string> GenerateAsync(int keyLength = 64)
    {
        return await Task.Run(() => GenerateKey(keyLength));
    }
}