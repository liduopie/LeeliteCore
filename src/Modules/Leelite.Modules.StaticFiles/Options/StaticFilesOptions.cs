using System.Collections.Generic;

namespace Leelite.Modules.StaticFiles.Options
{
    public class StaticFilesOptions
    {
        public IList<PathOptions> Paths { get; set; } = new List<PathOptions>();
    }
}
