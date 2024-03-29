namespace WebAPI.Domain.DTOs;

public class UserDTO
{
    public string DisplayName { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public string[] Roles { get; set; }
}
