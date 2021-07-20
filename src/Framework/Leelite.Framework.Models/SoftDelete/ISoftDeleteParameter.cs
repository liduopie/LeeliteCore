using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Framework.Models.SoftDelete
{
    public interface ISoftDeleteParameter
    {
        bool IgnoreDelete { get; set; }
    }
}
