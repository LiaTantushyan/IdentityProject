using IdentityProj.Common.Models;
using IdentityProj.Common.Models.Email;
using IdentityProj.EmailSender.Data;
using IdentityProj.EmailSender.Data.Entity;
using IdentityProj.EmailSender.Models;
using IdentityProj.EmailSender.Models.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IdentityProj.EmailSender.Services;

public class EmailSenderService
{
    private readonly EmailSettings _emailSettings;

    private readonly EmailSenderDbContext _dbContext;

    public EmailSenderService(EmailSenderDbContext dbContext, EmailSettings emailSettings)
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
        var resultInfo = new ResultInfoDto();

        var apiKey = _emailSettings.ApiKey;

        var client = new SendGridClient(apiKey);

        var msg = MailHelper.CreateSingleEmail(new EmailAddress(_emailSettings.GMail), new EmailAddress(model.Receiver),
            model.Subject, "xxx", "yyy");

        try
        {
            var response = await client.SendEmailAsync(msg);

            resultInfo.Succeeded = response.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            resultInfo.Errors = new[] { e.Message };
        }

        return resultInfo;
    }
}