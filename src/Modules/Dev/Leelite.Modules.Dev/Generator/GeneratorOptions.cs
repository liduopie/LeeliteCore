using System.IO;

namespace Leelite.Modules.Dev.Generator
{
    public class GeneratorOptions
    {
        public GeneratorOptions()
        {
            TemplateDirectory = Path.Combine(Directory.GetCurrentDirectory(), @"Modules\Leelite.Modules.Dev\templates");
            OutputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "output");
        }

        public string TemplateDirectory { get; set; }
        public string OutputDirectory { get; set; }
    }
}
