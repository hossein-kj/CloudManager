using CloudManager.Common.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace CloudManager.Common.Helper
{
    public interface IFileHelper
    {
        bool CreateDirectory(IPath path);
        bool DeleteDirectory(IPath path);
        bool DeleteFile(IPath path);
        bool FileExist(IPath path);
        DirectoryInfo[] GetDirectories(IPath path, string searchPatern = "*", SearchOption searchOption = SearchOption.TopDirectoryOnly);
        Task<string> ReadAsync(IPath path, FileMode fileMode = FileMode.Open, FileAccess fileAccess = FileAccess.ReadWrite, FileShare fileShare = FileShare.ReadWrite | FileShare.Delete);
        Task<bool> WriteAsync(IPath path, string file, FileMode fileMode = FileMode.Create, FileAccess fileAccess = FileAccess.ReadWrite, FileShare fileShare = FileShare.ReadWrite | FileShare.Delete);
    }
}