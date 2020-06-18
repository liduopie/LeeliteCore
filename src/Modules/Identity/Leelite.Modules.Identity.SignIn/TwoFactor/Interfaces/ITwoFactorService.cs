using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Modules.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.SignIn.TwoFactor.Interfaces
{
    public interface ITwoFactorService :
        IUserTwoFactorStore<User>,
        IUserTwoFactorRecoveryCodeStore<User>
    {
    }
}
