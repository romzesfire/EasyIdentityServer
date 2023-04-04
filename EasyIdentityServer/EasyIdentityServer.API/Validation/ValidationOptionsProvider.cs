using System.Net;
using EasyIdentityServer.DTO.Exception;
using EasyTradeLibs.Abstractions;
using EasyTradeLibs.Validation;

namespace EasyIdentityServer.API.Validation;

public class ValidationOptionsProvider : IValidationOptionsProvider
{
    private Dictionary<Type, ValidationOptions> _options;

    public ValidationOptionsProvider()
    {
        _options = new Dictionary<Type, ValidationOptions>(new TypeComparer())
        {
            {
                typeof(InvalidCredentialsException), 
                new ValidationOptions()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
            },
            {
                typeof(RegisterExistUserException), 
                new ValidationOptions()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
            },
            {
                typeof(UserNotExistException), 
                new ValidationOptions()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                }
            },
        };
    }

    public Dictionary<Type, ValidationOptions> Get() => _options;
}