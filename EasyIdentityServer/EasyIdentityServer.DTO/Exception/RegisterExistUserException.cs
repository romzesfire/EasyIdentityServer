namespace EasyIdentityServer.DTO.Exception;

public class RegisterExistUserException : System.Exception
{
    public RegisterExistUserException() : base("Try register of exist user")
    {
        
    }
}