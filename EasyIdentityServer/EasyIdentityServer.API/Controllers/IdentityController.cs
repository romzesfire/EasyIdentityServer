using EasyIdentityServer.DTO.Abstractions;
using EasyIdentityServer.DTO.Model;
using Microsoft.AspNetCore.Mvc;

namespace EasyIdentityServer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private readonly ISecretKeyGenerator _keyGenerator;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRegister _userRegister;
    private readonly ITokenGenerator _tokenGenerator;
    
    public IdentityController(ISecretKeyGenerator keyGenerator, ITokenGenerator tokenGenerator,
        IHttpContextAccessor httpContextAccessor, IUserRegister userRegister)
    {
        _keyGenerator = keyGenerator;
        _tokenGenerator = tokenGenerator;
        _httpContextAccessor = httpContextAccessor;
        _userRegister = userRegister;
    }

    [HttpGet("Register")]
    public async Task<IActionResult> GetSecretKey([FromQuery] UserCreationModel model)
    {
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
        var credentials = await _userRegister.Register(model, ip);
        
        return Ok(credentials);
    }

    [HttpGet("Token")]
    public async Task<IActionResult> GetToken([FromQuery] UserCredentials credentials)
    {
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
        var token = await _tokenGenerator.Generate(credentials, ip);
        return Ok(token);
    }
}