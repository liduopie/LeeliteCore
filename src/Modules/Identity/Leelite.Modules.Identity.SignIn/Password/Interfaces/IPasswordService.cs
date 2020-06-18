using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Modules.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.SignIn.Password.Interfaces
{
    public interface IPasswordService : IUserPasswordStore<User>
    {
    }
}
