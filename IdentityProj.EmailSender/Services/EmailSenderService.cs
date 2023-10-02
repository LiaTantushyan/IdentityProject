using System.Net;
using System.Net.Mail;
using IdentityProj.Common.Models;
using IdentityProj.EmailSender.Data;
using IdentityProj.EmailSender.Data.Entity;
using IdentityProj.EmailSender.Models;
using IdentityProj.EmailSender.Models.Configuration;

namespace IdentityProj.EmailSender.Services;

public class EmailSenderService
{
    private readonly EmailSettings _emailSettings;
    private readonly EmailSenderDbContext _dbContext;

    public EmailSenderService(
        EmailSettings emailSettings,
        EmailSenderDbContext dbContext)
    {
        _dbContext = dbContext;
        _emailSettings = emailSettings;
    }

    public async Task<ResultInfoDto> SendEmailAsync(EmailModel model)
    {
        var sendResult = await TrySendEmailAsync(model);

        _dbContext.Add(new SentEmailRecord
        {
            SentDate = DateTime.UtcNow,
            ReceiverId = model.ReceiverId,
            ReceiverEmail = model.Receiver,
            Content = model.Content,
            IsDelivered = sendResult.Succeeded,
            FailDescription = sendResult.Errors.FirstOrDefault()
        });

        await _dbContext.SaveChangesAsync();

        return sendResult;
    }

    private async Task<ResultInfoDto> TrySendEmailAsync(EmailModel model)
    {
        var sendResult = new ResultInfoDto();

        var message = new MailMessage();

        message.To.Add(new MailAddress(model.Receiver));

        message.Body = model.Content;
        message.Subject = model.Subject;
        message.From = new MailAddress(_emailSettings.Email, "Test IdentityProj");

        var smtp = new SmtpClient
        {
            EnableSsl = true,
            Port = _emailSettings.Port,
            Host = _emailSettings.Host,
            UseDefaultCredentials = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
        };

        try
        {
            await smtp.SendMailAsync(message);
            sendResult.Succeeded = true;
        }
        catch (Exception e)
        {
            sendResult.Errors = new[] { e.Message };
        }

        return sendResult;
    }
}