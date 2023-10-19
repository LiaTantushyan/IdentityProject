namespace IdentityProj.EmailSender.Models.Configuration;

public class EmailSettings
{
    public string ApiKey { get; set; } = null!;

    public string SendFrom { get; set; } = null!;
    
    public string GMail { get; set; } = null!;

    public string WriteUsTemplateId { get; set; } = null!;

    public string ConfirmTemplateId { get; set; } = null!;

    public string EmailNotificationId { get; set; } = null!;
}