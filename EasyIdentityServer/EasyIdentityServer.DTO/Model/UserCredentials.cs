using System.ComponentModel.DataAnnotations;

namespace EasyIdentityServer.DTO.Model;

public class UserCredentials
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string SecretKey { get; set; }

    public UserCredentials() { }
    public UserCredentials(Guid userId, string key)
    {
        UserId = userId;
        SecretKey = key;
    }
}