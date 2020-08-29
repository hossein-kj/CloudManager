using CloudManager.Common;
using CloudManager.Modeld;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public interface IResourceBiz
    {
        Task<CommandResult> Create(string path, List<Resource> resources);
        CommandResult Delete(string path, List<Resource> resources);
    }
}