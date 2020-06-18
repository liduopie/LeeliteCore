using System.IO;

namespace Leelite.Modules.Dev.Generator
{
    public class GeneratorPathBuilder
    {
        private readonly GeneratorOptions _options;
        private readonly GeneratorParameters _parameters;

        public GeneratorPathBuilder(GeneratorOptions options, GeneratorParameters parameters)
        {
            _options = options;
            _parameters = parameters;
        }

        public CodeFileInfo Build(string templatePath)
        {
            var fileInfo = new CodeFileInfo();

            fileInfo.TemplatePath = templatePath;
            fileInfo.TemplateRelativePath = Path.GetRelativePath(_options.TemplateDirectory, fileInfo.TemplatePath);

            fileInfo.RelativePath = Path.Combine(Path.GetDirectoryName(fileInfo.TemplateRelativePath), Path.GetFileNameWithoutExtension(fileInfo.TemplateRelativePath));

            foreach (var item in _parameters)
            {
                fileInfo.RelativePath = fileInfo.RelativePath.Replace("{{" + item.Key + "}}", item.Value);
            }

            fileInfo.AbsolutePath = Path.Combine(_options.OutputDirectory, fileInfo.RelativePath);

            fileInfo.FileName = Path.GetFileName(fileInfo.RelativePath);

            return fileInfo;
        }
    }
}
