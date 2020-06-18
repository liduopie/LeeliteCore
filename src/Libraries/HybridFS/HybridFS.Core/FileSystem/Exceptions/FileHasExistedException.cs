using System.IO;

namespace HybridFS.FileSystem.Exceptions
{
    public class FileHasExistedException : IOException
    {
        public FileHasExistedException(string message, string fileName)
        {
            Message = message;
            FileName = fileName;
        }

        //
        // 摘要:
        //     Gets the name of the file that cannot be found.
        //
        // 返回结果:
        //     The name of the file, or null if no file name was passed to the constructor for
        //     this instance.
        public string FileName { get; }

        //
        // 摘要:
        //     Gets the error message that explains the reason for the exception.
        //
        // 返回结果:
        //     The error message.
        public override string Message { get; }
    }
}
