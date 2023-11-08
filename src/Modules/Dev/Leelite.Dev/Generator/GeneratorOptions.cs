namespace Leelite.Dev.Generator
{
    public class GeneratorOptions
    {
        public GeneratorOptions()
        {
            TemplateDirectory = @"Leelite.Dev\templates";
            OutputDirectory = "output";
        }

        public string TemplateDirectory { get; set; }
        public string OutputDirectory { get; set; }
    }
}
