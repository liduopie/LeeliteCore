using System;
using System.Collections.Generic;
using System.Text;
using Leelite.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Identity.SignIn.Password.Interfaces
{
    public interface IPasswordService : IUserPasswordStore<User>
    {
    }
}
