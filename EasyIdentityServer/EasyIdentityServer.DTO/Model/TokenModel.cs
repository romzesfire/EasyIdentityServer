namespace EasyIdentityServer.DTO.Model;

public class TokenModel
{
    public Guid UserId { get; set; }
    public string Token { get; set; }

    public TokenModel(Guid userId, string token)
    {
        UserId = userId;
        Token = token;
    }
}