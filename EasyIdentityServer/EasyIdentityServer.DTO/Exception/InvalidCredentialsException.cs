namespace EasyIdentityServer.DTO.Exception;

public class InvalidCredentialsException : System.Exception
{
    public InvalidCredentialsException() : base("Invalid credentials")
    {
        
    }
}