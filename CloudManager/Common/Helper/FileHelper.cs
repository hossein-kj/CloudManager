using CloudManager.Common.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Common.Helper
{
    public class FileHelper : IFileHelper
    {
        public async Task<string> ReadAsync(IPath path, FileMode fileMode = FileMode.Open, FileAccess fileAccess = FileAccess.ReadWrite, FileShare fileShare = FileShare.ReadWrite | FileShare.Delete)
        {
            var realPath = GetRealPath(path.Path);

            using (var fs = new FileStream(realPath, fileMode, fileAccess, fileShare))
            {
                using (var strReader = new StreamReader(fs, Encoding.UTF8))
                {
                    return await strReader.ReadToEndAsync();
                }
            }
        }

        public async Task<bool> WriteAsync(IPath path, string file, FileMode fileMode = FileMode.Create, FileAccess fileAccess = FileAccess.ReadWrite, FileShare fileShare = FileShare.ReadWrite | FileShare.Delete)
        {
            var realPath = GetRealPath(path.Path);

            using (var fs = new FileStream(realPath, fileMode, fileAccess, fileShare))
            {
                using (var strWriter = new StreamWriter(fs, Encoding.UTF8))
                {
                    await strWriter.WriteAsync(file);
                }
            }
            return true;
        }

        public bool CreateDirectory(IPath path)
        {
            var realPath = GetRealPath(path.Path);
            if (!DirectoryExists(realPath))
            {
                Directory.CreateDirectory(realPath);
            }

            return true;
        }

        public bool DeleteDirectory(IPath path)
        {
            var realPath = GetRealPath(path.Path);
            if (DirectoryExists(realPath))
            {
                Directory.Delete(realPath, false);
            }

            return true;
        }

        public bool DeleteFile(IPath path)
        {
            var realPath = GetRealPath(path.Path);
            if (FileExist(path))
            {
                File.Delete(realPath);
            }

            return true;
        }

        public bool FileExist(IPath path)
        {
            var realPath = GetRealPath(path.Path);
            return File.Exists(realPath);
        }

        public virtual DirectoryInfo[] GetDirectories(IPath path, string searchPatern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var realPath = GetRealPath(path.Path);

            var currentDirInfo = new DirectoryInfo(realPath);
            return currentDirInfo.GetDirectories(searchPatern, searchOption);
        }

        private bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        private string GetRealPath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}
