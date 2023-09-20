namespace IdentityProj.Common.Configuration;

public class JwtSettings
{
    public string? Secret { get; init; }

    public TimeSpan TokenLifeTime { get; init; }
}