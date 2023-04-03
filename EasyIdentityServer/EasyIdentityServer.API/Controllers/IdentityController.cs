using EasyIdentityServer.DTO.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EasyIdentityServer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController : ControllerBase
{
    private ISecretKeyGenerator _keyGenerator;
    private IHttpContextAccessor _httpContextAccessor;
    public IdentityController(ISecretKeyGenerator keyGenerator, IHttpContextAccessor httpContextAccessor)
    {
        _keyGenerator = keyGenerator;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("Register")]
    public async Task<IActionResult> GetSecretKey()
    {
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        return Ok(ip);
    }

    [HttpGet("Token")]
    public async Task<IActionResult> GetToken()
    {
        
        return Ok();
    }
}