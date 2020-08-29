using CloudManager.Business;
using CloudManager.Common;
using CloudManager.Common.Exceptions;
using CloudManager.Common.Model;
using CloudManager.Modeld;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudManager.Api
{
    public class InfrastructureController
    {
        private IProviderBiz _providerBiz;
        private IInfrastructureBiz _infrastructureBiz;
        public InfrastructureController(IProviderBiz providerBiz,IInfrastructureBiz infrastructureBiz)
        {
            _providerBiz = providerBiz;
            _infrastructureBiz = infrastructureBiz;
        }
        public async Task<CommandResult> Create(JObject data)
        {
            dynamic infrustructureDto = data;
            JArray resourceArray = infrustructureDto.Resources;
            var resources = resourceArray.ToObject<List<Resource>>();

            string providerName = infrustructureDto.ProviderName;

            if (string.IsNullOrEmpty(providerName))
                providerName = "AWS";

            string infrastructureName = infrustructureDto.InfrastructureName;

            if (string.IsNullOrEmpty(infrastructureName))
                throw new ValidateException("Infrastructure Name");


         
            var infrastructure = new Infrastructure() { Name = infrastructureName,
                Resources = resources
            };

            var provider = new Provider()
            {
                Name = providerName,
                infrastructures = new List<Infrastructure>()
                {
                    infrastructure
                }
            };

            infrastructure.Provider = provider;

            return await _providerBiz.Create(provider);
        }

        public CommandResult Delete(JObject data)
        {
            dynamic providerDto = data;

            string providerName = providerDto.Name;

            if (string.IsNullOrEmpty(providerName))
                providerName = "AWS";

            string infrastructureName = providerDto.InfrastructureName;

            if (string.IsNullOrEmpty(infrastructureName))
                throw new ValidateException("Infrastructure Name");

          
            var infrastructure = new Infrastructure()
            {
                Name = infrastructureName,
            };

            var provider = new Provider()
            {
                Name = providerName,
                infrastructures = new List<Infrastructure>()
                {
                    infrastructure
                }
            };

            infrastructure.Provider = provider;

            return _infrastructureBiz.Delete(provider.infrastructures);
        }
    }
}
