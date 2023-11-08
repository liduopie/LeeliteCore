using Leelite.Core.Module;

namespace Leelite.Dev.Generator.Projects
{
    public class ProjectGenerator : GeneratorBase
    {
        private readonly ProjectInfo _projectInfo;

        public ProjectGenerator(ProjectInfo info, ModuleOptions moduleOptions, Action<GeneratorOptions> action = null) : base(moduleOptions, action)
        {
            _projectInfo = info;

            Options.TemplateDirectory = Path.Combine(Options.TemplateDirectory, "project");

            switch (_projectInfo.ProjectType)
            {
                case TypeConsts.Lib:
                    Options.TemplateDirectory = Path.Combine(Options.TemplateDirectory, TypeConsts.Lib);
                    break;
                case TypeConsts.Web:
                    Options.TemplateDirectory = Path.Combine(Options.TemplateDirectory, TypeConsts.Web);
                    break;
                case TypeConsts.WebApi:
                    Options.TemplateDirectory = Path.Combine(Options.TemplateDirectory, TypeConsts.WebApi);
                    break;
                default:
                    break;
            }
        }

        public void Init()
        {
            var parameters = new GeneratorParameters();

            parameters.Add("ModuleName", _projectInfo.ModuleName);
            parameters.Add("Namespace", _projectInfo.Namespace);
            parameters.Add("IsModule", _projectInfo.IsModule.ToString());

            base.Init(parameters);
        }
    }
}
