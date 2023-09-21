namespace IdentityProj.Common.Models;

public class TokenDto : ResultInfoDto
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}