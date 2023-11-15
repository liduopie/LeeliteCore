using System;
using System.IO;

using Leelite.Core.Module;

using Mono.TextTemplating;

namespace Leelite.Dev.Generator.Codes
{
    public class CodeGenerator : GeneratorBase
    {
        private readonly AggregateInfo _aggregateInfo;

        public CodeGenerator(AggregateInfo info, ModuleOptions moduleOptions, Action<GeneratorOptions> action = null) : base(moduleOptions, action)
        {
            _aggregateInfo = info;

            // 测试
            // Options.TemplateDirectory = @"E:\GitHub\LeeliteCore\src\Modules\Dev\Leelite.Modules.Dev\templates\code\";
            Options.TemplateDirectory = Path.Combine(Options.TemplateDirectory, "code");
        }

        public void Init()
        {
            var parameters = new GeneratorParameters();

            parameters.Add("ClassName", _aggregateInfo.ClassName);
            parameters.Add("ClassFullName", _aggregateInfo.ClassFullName);
            parameters.Add("ModuleName", _aggregateInfo.ModuleName);
            parameters.Add("Namespace", _aggregateInfo.Namespace);
            parameters.Add("AssemblyPath", Path.Combine(AppContext.BaseDirectory, _aggregateInfo.AssemblyPath));

            base.Init(parameters);
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        public override void Generating()
        {
            TemplateGenerator.Refs.Add(Path.Combine(AppContext.BaseDirectory, _aggregateInfo.AssemblyPath));
            TemplateGenerator.Refs.Add(Path.Combine(AppContext.BaseDirectory, "Leelite.Framework.Models.dll"));
            TemplateGenerator.Refs.Add(Path.Combine(AppContext.BaseDirectory, "Leelite.Framework.Domain.dll"));
            TemplateGenerator.Imports.Add(_aggregateInfo.Namespace);

            base.Generating();
        }
    }
}
