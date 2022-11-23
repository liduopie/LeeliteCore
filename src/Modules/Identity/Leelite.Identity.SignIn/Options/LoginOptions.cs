using System.Collections.Generic;

using Leelite.Commons.Lifetime;

namespace Leelite.Identity.SignIn.Options
{
    public class LoginOptions : ISingleton
    {
        public LoginOptions()
        {
            Logins = new List<LoginType>()
            {
                LoginType.Password,
                LoginType.Mobile,
                LoginType.QRcode
            };
        }

        public IList<LoginType> Logins { get; set; }

        public bool EnabledExternalLogins { get; set; } = true;
    }
}
