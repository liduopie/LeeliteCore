namespace Leelite.Modules.Dev.Generator.Projects
{
    public class ProjectInfo
    {
        public string ModuleName { get; set; }
        public string Namespace { get; set; }

        public string ProjectType { get; set; }

        public bool IsModule { get; set; }
    }


    public static class TypeConsts
    {
        public const string Lib = "lib";
        public const string Web = "web";
        public const string WebApi = "webapi";
    }
}
