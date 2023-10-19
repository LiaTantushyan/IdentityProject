using IdentityProj.Common.Models.Email;
using IdentityProj.EmailSender.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProj.EmailSender.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]/[action]")]
public class EmailController : Controller
{
    private readonly EmailSenderService _emailService;

    public EmailController(EmailSenderService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] EmailModel model)
    {
        var result = await _emailService.SendEmailAsync(model);

        return Json(result);
    }
}