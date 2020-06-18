using System;
using System.IO;
using Mono.TextTemplating;

namespace Leelite.Modules.Dev.Generator.Codes
{
    public class CodeGenerator : GeneratorBase
    {
        private readonly AggregateInfo _aggregateInfo;

        public CodeGenerator(AggregateInfo info, Action<GeneratorOptions> action = null) : base(action)
        {
            _aggregateInfo = info;

            // 测试
            //Options.TemplateDirectory = @"C:\Users\Lee\Documents\GitHub\Leelite\src\Modules\Dev\Leelite.Modules.Dev\templates\code\";
            Options.TemplateDirectory = Path.Combine(Options.TemplateDirectory, "code");
        }

        public void Init()
        {
            var parameters = new GeneratorParameters();

            parameters.Add("ClassName", _aggregateInfo.ClassName);
            parameters.Add("ClassFullName", _aggregateInfo.ClassFullName);
            parameters.Add("Namespace", _aggregateInfo.Namespace);
            parameters.Add("AssemblyPath", _aggregateInfo.AssemblyPath);

            base.Init(parameters);
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        public override void Generating()
        {
            TemplateGenerator.Refs.Add(_aggregateInfo.AssemblyPath);
            TemplateGenerator.Refs.Add(Path.Combine(Directory.GetCurrentDirectory(), @"Modules\Leelite.Framework\netcoreapp3.1\Leelite.Framework.Models.dll"));
            TemplateGenerator.Refs.Add(Path.Combine(Directory.GetCurrentDirectory(), @"Modules\Leelite.Framework\netcoreapp3.1\Leelite.Framework.Domain.dll"));
            TemplateGenerator.Imports.Add(_aggregateInfo.Namespace);

            base.Generating();
        }
    }
}
