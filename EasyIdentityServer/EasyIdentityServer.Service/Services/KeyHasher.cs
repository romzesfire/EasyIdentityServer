using System.Security.Cryptography;
using System.Text;
using EasyIdentityServer.DTO;

namespace EasyIdentityServer.Service.Services;

public class KeyHasher : IKeyHasher
{
    public KeyHasher()
    {
        
    }
    
    public byte[] Hash(string key)
    {
        var hasher = SHA512.Create();
        var bytes = Encoding.UTF8.GetBytes(key);
        var hash = hasher.ComputeHash(bytes);
        return hash;
    }
}