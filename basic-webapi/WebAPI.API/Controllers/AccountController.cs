using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.API.Services;
using WebAPI.Domain;
using WebAPI.Domain.DTOs;

namespace WebAPI.API.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenServices _token;  
    public AccountController(UserManager<AppUser> userManager, TokenServices token)
    {
        _userManager = userManager;
        _token = token;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var user = await _userManager.FindByEmailAsync(loginDTO.Email);
        if (user is null)
        {
            return Unauthorized();
        }
        var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
        if (result)
        {
            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Token = _token.CreateToken(user),
                UserName = user.UserName
            });
        }
        return Unauthorized();
    }
}
