using System.IO;
using System.Linq;

using HybridFS.Utility;

using Leelite.Modules.FileStorage.Models.FileItemAgg;
using Leelite.Modules.FileStorage.Options;

namespace Leelite.Modules.FileStorage.Utility
{
    public static class PathGenerator
    {
        public static string GeneratePath(FileItem file, FileStorageOptions options)
        {
            var fullPath = PathHelper.Combine(options.RootPath, file.TenantId.ToString(), file.ModuleCode);

            var ext = Path.GetExtension(file.Name);


            var classifyPath = "";
            foreach (var item in options.ClassifyOptions)
            {
                if (item.Extensions.Split(',').Any(c => c == ext))
                    classifyPath = item.DirectoryName;
            }

            fullPath = PathHelper.Combine(fullPath, classifyPath);

            var datePath = "";

            switch (options.DirectoryRule)
            {
                case DirectoryNameRule.Year:
                    datePath = file.CreationTime.Value.ToString("yyyy");
                    break;
                case DirectoryNameRule.Month:
                    datePath = file.CreationTime.Value.ToString("yyyy/yyyy-MM");
                    break;
                case DirectoryNameRule.Day:
                    datePath = file.CreationTime.Value.ToString("yyyy/yyyy-MM/yyyy-MM-dd");
                    break;
                default:
                    break;
            }

            fullPath = PathHelper.Combine(fullPath, datePath, Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext);

            return fullPath;
        }
    }
}
