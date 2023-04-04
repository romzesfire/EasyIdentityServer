using System.ComponentModel.DataAnnotations;
using System.Net;

namespace EasyIdentityServer.DTO.Model;

public class UserCreationModel
{
    [Required]
    public Guid UserId { get; set; }
}