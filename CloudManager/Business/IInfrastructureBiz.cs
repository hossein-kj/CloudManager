using CloudManager.Common;
using CloudManager.Modeld;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public interface IInfrastructureBiz
    {
        Task<CommandResult> Create(List<Infrastructure> infrastructures);
        CommandResult Delete(List<Infrastructure> infrastructures);
    }
}