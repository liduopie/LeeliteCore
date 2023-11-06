using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Identity.SignIn.Password.Services.Models
{
    public class UpdatePasswordRequest
    {
        public long Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
