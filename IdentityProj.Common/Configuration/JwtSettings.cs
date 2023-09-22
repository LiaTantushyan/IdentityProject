namespace IdentityProj.Common.Configuration;

public class JwtSettings
{
    public string? Secret { get; init; }

    public TimeSpan AccessTokenLifeTime { get; init; }

    public TimeSpan RefreshTokenLifeTime { get; init; }
}