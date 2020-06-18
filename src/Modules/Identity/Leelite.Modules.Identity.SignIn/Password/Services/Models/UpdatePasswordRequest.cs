using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.Identity.Services.Models
{
    public class UpdatePasswordRequest
    {
        public long Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
