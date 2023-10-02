namespace IdentityProj.EmailSender.Data.Entity;

public class SentEmailRecord
{
    public long Id { get; set; }

    public DateTime SentDate { get; set; }

    public string Content { get; set; } = null!;

    public string ReceiverEmail { get; set; } = null!;

    public long ReceiverId { get; set; }

    public bool IsDelivered { get; set; }

    public string? FailDescription { get; set; }
}