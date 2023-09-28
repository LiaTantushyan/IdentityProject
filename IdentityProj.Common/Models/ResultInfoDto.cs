namespace IdentityProj.Common.Models;

public class ResultInfoDto
{
    public bool Succeeded { get; set; }

    public IEnumerable<string> Errors { get; set; } = null!;
}