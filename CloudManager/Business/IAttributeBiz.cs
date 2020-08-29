using CloudManager.Common;
using CloudManager.Modeld;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public interface IAttributeBiz
    {
        Task<CommandResult> Create(string path, List<Attribute> attributes);
        CommandResult Delete(string path);
    }
}