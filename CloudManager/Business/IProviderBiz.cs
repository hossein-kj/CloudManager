using CloudManager.Common;
using CloudManager.Modeld;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public interface IProviderBiz
    {
        Task<CommandResult> Create(Provider provider);
        CommandResult Delete(Provider provider);
    }
}