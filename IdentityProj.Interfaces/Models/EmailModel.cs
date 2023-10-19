namespace IdentityProj.Interfaces.Models;

public class EmailModel
{
    public string Content { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Receiver { get; set; } = null!;

    public int ReceiverId { get; set; }
}