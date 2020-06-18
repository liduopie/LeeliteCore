using System;
using System.IO;
using System.Security.Cryptography;
using Coldairarrow.Util;

namespace HybridFS.FileStore.Models
{
    /// <summary>
    /// 文件条目构建工厂
    /// </summary>
    public static class FileEntryFactory
    {
        /// <summary>
        /// 根据文件流构建一个文件条目
        /// </summary>
        /// <param name="inputStream">输入文件流</param>
        /// <returns>返回一个文件条目信息</returns>
        public static FileEntry CreateFileEntryByStream(Stream inputStream)
        {
            var nowTime = DateTime.UtcNow;
            var entry = new FileEntry();

            entry.Id = IdHelper.GetLongId();
            entry.Content = new byte[0];
            entry.CreationTimeUtc = nowTime;
            entry.LastVisitTimeUtc = nowTime;
            entry.Length = inputStream.Length;
            
            entry.ReferenceCount = 1;
            entry.Visits = 0;

            using (MD5 md5 = MD5.Create())
            {
                inputStream.Position = 0;
                //开始加密
                byte[] output = md5.ComputeHash(inputStream);

                entry.MD5 = BitConverter.ToString(output).Replace("-", "");
            }

            return entry;
        }
    }
}
