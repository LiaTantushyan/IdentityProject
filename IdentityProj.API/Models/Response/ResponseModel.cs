namespace IdentityProj.Models.Response;

public class ResponseModel
{
    public bool Succeeded { get; set; }

    public IEnumerable<string>? Errors { get; set; }
}