using BLL.Interfaces;
using Domain.DTO.Requests;
using Domain.DTO.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M7BookAPI.Controllers;


public class AccountController: APIBaseController
{
    private readonly ISecurityService _securityService; 
    public AccountController(ISecurityService securityService)
    {
         _securityService = securityService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest )
    {
        var result = await _securityService.SignIn(loginRequest.username, loginRequest.password);

        if (result is null) return BadRequest();

        else  return Ok(new LoginResponse() {AccessToken = result});
    }
}
