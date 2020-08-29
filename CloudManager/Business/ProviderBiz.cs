using CloudManager.Common;
using CloudManager.Common.Helper;
using CloudManager.Modeld;
using CloudManager.Properties;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public class ProviderBiz : IProviderBiz
    {
        private IInfrastructureBiz _infrastructureBiz;
        private IFileHelper _fileHelper;
        public ProviderBiz(IInfrastructureBiz infrastructureBiz, IFileHelper fileHelper)
        {
            _infrastructureBiz = infrastructureBiz;
            _fileHelper = fileHelper;
        }
        public async Task<CommandResult> Create(Provider provider)
        {
            _fileHelper.CreateDirectory(provider);
            var result = await _infrastructureBiz.Create(provider.infrastructures);
            result.ResultMessages.Add(new ResultMessage()
            {
                IsSuccessed = true,
                Message = string.Format(Resources.Create, Provider.GetName() + " " + provider.Name)
            });
            return result;
        }

        public CommandResult Delete(Provider provider)
        {
            var result = new CommandResult();
            result.ResultMessages.AddRange(_infrastructureBiz.Delete(provider.infrastructures).ResultMessages);

            result.ResultMessages.Add(new ResultMessage()
            {
                IsSuccessed = _fileHelper.DeleteDirectory(provider),
                Message = string.Format(Resources.Delete, Provider.GetName() + " " + provider.Name)
            });

            return result;
        }
    }
}
