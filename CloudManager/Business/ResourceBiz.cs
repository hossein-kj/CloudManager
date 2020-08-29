using CloudManager.Common;
using CloudManager.Common.Helper;
using CloudManager.Modeld;
using CloudManager.Properties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudManager.Business
{
    public class ResourceBiz : IResourceBiz
    {
        private IAttributeBiz _attributeBiz;
        private IFileHelper _fileHelper;

        public ResourceBiz(IAttributeBiz attributeBiz, IFileHelper fileHelper)
        {
            _attributeBiz = attributeBiz;
            _fileHelper = fileHelper;
        }


        public async Task<CommandResult> Create(string path, List<Resource> resources)
        {
            var result = new CommandResult();
            foreach (var resource in resources)
            {
                var messages = await CreateResource(path + "/" + resource.Name, resource);

                result.ResultMessages.AddRange(messages.ResultMessages);
                result.ResultMessages.Add(new ResultMessage() { IsSuccessed = true, Message = string.Format(Resources.Create, Resource.GetName() + " " + resource.Name) });
            }
            return result;
        }

        private async Task<CommandResult> CreateResource(string path, Resource resource)
        {
            var result = new CommandResult();
            _fileHelper.CreateDirectory(new PathHelper() { Path = path });
            var messages = await _attributeBiz.Create(path + "/" + resource.Name+".json", resource.Attributes);
            result.ResultMessages.AddRange(messages.ResultMessages);
            foreach (var subResource in resource.Resources)
            {
                var subMessages = await CreateResource(path + "/" + subResource.Name, subResource);
                result.ResultMessages.AddRange(subMessages.ResultMessages);
            }


            result.ResultMessages.Add(new ResultMessage() { IsSuccessed = true, Message = string.Format(Resources.Create, Resource.GetName() + " " + resource.Name) });
            return result;
        }



        public CommandResult Delete(string path, List<Resource> resources)
        {
            var result = new CommandResult();
            foreach (var resource in resources)
            {
                var messages = DeleteResource(path + "/" + resource.Name, resource);
                result.ResultMessages.AddRange(messages.ResultMessages);
                result.ResultMessages.Add(new ResultMessage()
                {
                    IsSuccessed = true,
                    Message = string.Format(Resources.Delete, Resource.GetName() + " " + resource.Name)
                });
            }
            return result;
        }


        private CommandResult DeleteResource(string path, Resource resource)
        {
            var result = new CommandResult();

            if (resource.Attributes.Count > 0)
                result.ResultMessages.AddRange(_attributeBiz.Delete(path + "/" + resource.Name + ".json").ResultMessages);


            foreach (var subResource in resource.Resources)
            {
                var subMessages = DeleteResource(path + "/" + subResource.Name, subResource);
                result.ResultMessages.AddRange(subMessages.ResultMessages);
            }
            return result;
        }
    }
}
