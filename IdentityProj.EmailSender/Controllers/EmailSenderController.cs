using IdentityProj.EmailSender.Models;
using IdentityProj.EmailSender.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.EmailSender.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmailSenderController : Controller
{
    private readonly EmailSenderService _emailService;

    public EmailSenderController(EmailSenderService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(EmailModel model)
    {
        var result = await _emailService.SendEmailAsync(model);

        return Json(result);
    }
}