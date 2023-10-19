using IdentityProj.Common.Models;
using IdentityProj.Common.Models.Email;
using Refit;

namespace IdentityProj.Common.Interfaces.EmailSender;

public interface IEmailSenderApi
{
    [Post("/Email/Send")]
    public Task<ResultInfoDto> SendEmailAsync([Body] EmailModel model);
}