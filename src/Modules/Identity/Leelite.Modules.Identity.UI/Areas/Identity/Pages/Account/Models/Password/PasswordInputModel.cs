using System.ComponentModel.DataAnnotations;

namespace Leelite.Modules.Identity.UI.Areas.Identity.Pages.Account.Models.Password
{
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
