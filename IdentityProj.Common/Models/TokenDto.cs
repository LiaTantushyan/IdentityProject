namespace IdentityProj.Common.Models;

public class TokenDto : ResultInfoDto
{
    public string AccessToken { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}