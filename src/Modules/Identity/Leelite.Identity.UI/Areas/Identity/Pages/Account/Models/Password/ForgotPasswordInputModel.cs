using System.ComponentModel.DataAnnotations;

namespace Leelite.Web.Areas.Identity.Pages.Account.Models.Password
{
    public class ForgotPasswordInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
