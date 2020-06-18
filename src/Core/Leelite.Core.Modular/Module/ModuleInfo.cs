using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Core.Modular.Module
{
    public class ModuleInfo
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public IList<string> Assemblys { get; set; } = new List<string>();

        public IList<string> Views { get; set; } = new List<string>();
    }
}
