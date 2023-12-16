using System.ComponentModel.DataAnnotations;

namespace Leelite.Web.Areas.Identity.Pages.Account.Models.Password
{
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class PasswordInputModel
    {
        [Required(ErrorMessage = "密码字段不能为空。")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "自动登录")]
        public bool RememberMe { get; set; }
    }
}
