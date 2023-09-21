namespace IdentityProj.Common.Configuration;

public class JwtSettings
{
    public string? Secret { get; init; }

    public string? AccessTokenLifeTime { get; init; }

    public string? RefreshTokenLifeTime { get; init; }
}