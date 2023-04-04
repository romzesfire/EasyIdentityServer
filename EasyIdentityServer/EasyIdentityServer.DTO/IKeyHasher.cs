namespace EasyIdentityServer.DTO;

public interface IKeyHasher
{
    public byte[] Hash(string key);
}

