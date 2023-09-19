namespace IdentityProj.Common.Models;

public class ResultInfoDTO
{
    public bool Succeeded { get; set; }

    public IEnumerable<string>? Errors { get; set; }
}