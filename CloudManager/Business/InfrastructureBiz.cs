using CloudManager.Common;
using CloudManager.Common.Helper;
using CloudManager.Modeld;
using CloudManager.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public class InfrastructureBiz : IInfrastructureBiz
    {
        private IResourceBiz _resourceBiz;
        private IFileHelper _fileHelper;
        public InfrastructureBiz(IResourceBiz resourceBiz, IFileHelper fileHelper)
        {
            _resourceBiz = resourceBiz;
            _fileHelper = fileHelper;
        }
        public async Task<CommandResult> Create(List<Infrastructure> infrastructures)
        {
            var result = new CommandResult();
            foreach (var infrastructure in infrastructures)
            {
                _fileHelper.CreateDirectory(infrastructure);
                var path = infrastructure.Provider.Name + "/" + infrastructure.Name;
                var messages = await _resourceBiz.Create(path, infrastructure.Resources);
                result.ResultMessages.AddRange(messages.ResultMessages);
                result.ResultMessages.Add(new ResultMessage()
                {
                    IsSuccessed = true,
                    Message = string.Format(Resources.Create, Infrastructure.GetName() + " " + infrastructure.Name)
                });
            }
            return result;
        }

        public CommandResult Delete(List<Infrastructure> infrastructures)
        {
            var result = new CommandResult();
            foreach (var infrastructure in infrastructures)
            {
                var path = infrastructure.Provider.Name + "/" + infrastructure.Name;

                var resources = GetResources(path);

                infrastructure.Resources = resources;


                result.ResultMessages.AddRange(_resourceBiz.Delete(path,infrastructure.Resources).ResultMessages);

                result.ResultMessages.Add(new ResultMessage()
                {
                    IsSuccessed = _fileHelper.DeleteDirectory(infrastructure),
                    Message = string.Format(Resources.Delete, Infrastructure.GetName() + " " + infrastructure.Name)
                });
            }

            return result;
        }

        private List<Resource> GetResources(string path)
        {
            var directories = _fileHelper.GetDirectories(new PathHelper() { Path=path});
            var resources = directories.Select(dir => {
                var res = new Resource() { Name = dir.Name };
                return res;
            }).ToList();

            foreach (var res in resources)
            {
                GetResources(path + "/" + res.Name);
            }

            return resources;
        }
    }
}
