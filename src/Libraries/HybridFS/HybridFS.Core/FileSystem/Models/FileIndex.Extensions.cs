namespace HybridFS.FileSystem.Models
{
    public static class FileIndexExtensions
    {
        public static HybridFileInfo ToFileInfo(this FileIndex file)
        {
            var info = new HybridFileInfo();

            info.Id = file.Id;
            info.Path = file.Path;
            info.DirectoryPath = file.DirectoryPath;
            info.Name = file.Name;
            info.Extension = file.Extension;
            info.Length = file.Length;
            info.MD5 = file.MD5;
            info.LastModifiedUtc = file.LastModifiedUtc;
            info.Visits = file.Visits;
            info.LastVisitTimeUtc = file.LastVisitTimeUtc;

            return info;
        }

        public static HybridDirectoryInfo ToDirectoryInfo(this FileIndex file)
        {
            var info = new HybridDirectoryInfo();

            info.Id = file.Id;
            info.Path = file.Path;
            info.DirectoryPath = file.DirectoryPath;
            info.Name = file.Name;
            info.Length = file.Length;
            info.LastModifiedUtc = file.LastModifiedUtc;
            info.Visits = file.Visits;
            info.LastVisitTimeUtc = file.LastVisitTimeUtc;

            return info;
        }
    }
}
