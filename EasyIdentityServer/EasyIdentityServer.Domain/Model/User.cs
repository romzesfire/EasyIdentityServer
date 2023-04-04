using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace EasyIdentityServer.Domain.Model;

public class User
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public byte[] SecretKeyHash { get; set; }
    public IPAddress IpAddress { get; set; }

    public User() { }
    public User(Guid userId, byte[] secretKeyHash, IPAddress ip)
    {
        UserId = userId;
        SecretKeyHash = secretKeyHash;
        IpAddress = ip;
    }
}