namespace EasyIdentityServer.DTO.Exception;

public class UserNotExistException : System.Exception
{
    public UserNotExistException() : base("This user is not exist")
    {
        
    }
}