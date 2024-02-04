using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Token = _token.CreateToken(user, roles),
                UserName = user.UserName
            });
        }
        return Unauthorized();
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterUserDTO register)
    {
        if(await _userManager.Users.AnyAsync(x => x.UserName == register.UserName))
        {
            return BadRequest("username taken");
        }
        var user = new AppUser()
        {
            DisplayName = register.DisplayName,
            Email = register.Email,
            UserName = register.UserName
        };
        var result = await _userManager.CreateAsync(user, register.Password);
        await _userManager.AddToRoleAsync(user, "User");
        var roles = await _userManager.GetRolesAsync(user);
        if (result.Succeeded)
        {
            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Token = _token.CreateToken(user, roles)
            });
        }
        return BadRequest("fail create user");
    }
}
