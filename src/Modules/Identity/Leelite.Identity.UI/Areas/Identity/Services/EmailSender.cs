using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Leelite.Web.Areas.Identity.Services
{
    internal class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
