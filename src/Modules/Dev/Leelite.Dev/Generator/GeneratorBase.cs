using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Mono.TextTemplating;

namespace Leelite.Modules.Dev.Generator
{
    public abstract class GeneratorBase
    {
        public GeneratorBase(Action<GeneratorOptions> action = null)
        {
            Options = new GeneratorOptions();

            action?.Invoke(Options);
        }

        public GeneratorOptions Options { get; set; } = new GeneratorOptions();

        public GeneratorParameters Parameters { get; set; } = new GeneratorParameters();

        public TemplateGenerator TemplateGenerator { get; set; }

        public IList<string> Templates { get; set; }

        public IList<CodeFileInfo> CodeFileInfos { get; set; } = new List<CodeFileInfo>();

        public StringBuilder Logs { get; set; } = new StringBuilder();

        public virtual void Init(GeneratorParameters parameters)
        {
            if (parameters == null) parameters = new GeneratorParameters();


            Templates = GetTemplateFiles(Options.TemplateDirectory);

            Logs.AppendLine($"发现Template '{Templates.Count}' 个。");

            foreach (var item in parameters)
            {
                Parameters.Add(item.Key, item.Value);
            }

            var pathBuilder = new GeneratorPathBuilder(Options, Parameters);

            foreach (var template in Templates)
            {
                CodeFileInfos.Add(pathBuilder.Build(template));
            }

            TemplateGenerator = new TemplateGenerator();

            foreach (var item in Parameters)
            {
                TemplateGenerator.TryAddParameter(item.Key + "=" + item.Value);
            }
        }


        /// <summary>
        /// 检查代码文件存在状态
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, bool> CheckFiles()
        {
            var fileExistsState = new Dictionary<string, bool>();

            foreach (var file in CodeFileInfos)
            {
                fileExistsState.Add(file.RelativePath, File.Exists(file.AbsolutePath));
            }

            return fileExistsState;
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        public virtual void Generating()
        {
            foreach (var file in CodeFileInfos)
            {
                if (!Directory.Exists(file.AbsolutePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(file.AbsolutePath));
                }

                TemplateGenerator.ProcessTemplateAsync(file.TemplatePath, file.AbsolutePath);
                if (TemplateGenerator.Errors.HasErrors)
                {
                    Logs.AppendLine($"Processing '{file.TemplatePath}' failed.");
                }

                foreach (System.CodeDom.Compiler.CompilerError err in TemplateGenerator.Errors)
                    if (err.IsWarning)
                        Logs.AppendLine($"{err.FileName}({err.Line},{err.Column}): WARNING {err.ErrorText}");
                    else
                        Logs.AppendLine($"{err.FileName}({err.Line},{err.Column}): ERROR {err.ErrorText}");

            }
        }


        private IList<string> GetTemplateFiles(string path)
        {
            var templates = new List<string>();

            if (!Directory.Exists(path))
            {
                return templates;
            }

            templates.AddRange(Directory.GetFiles(path, "*.t4"));

            var dirs = Directory.GetDirectories(path);

            foreach (var dir in dirs)
            {
                templates.AddRange(GetTemplateFiles(dir));
            }

            return templates;
        }
    }
}
