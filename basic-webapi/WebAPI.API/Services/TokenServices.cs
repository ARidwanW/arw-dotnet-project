using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Domain;

namespace WebAPI.API.Services;

public class TokenServices
{
    public string CreateToken(AppUser user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email)
        };
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
        ("ThisIsSup3r53cR3TThisIsSup3r53cR3TThisIsSup3r53cR3TThisIsSup3r53cR3T"));
        //* At least 12 characters to secret key
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string serialize = tokenHandler.WriteToken(token);
        return serialize;
    }
}
