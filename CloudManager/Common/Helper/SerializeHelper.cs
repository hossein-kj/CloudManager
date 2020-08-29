using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudManager.Common.Helper
{
    public class SerializeHelper : ISerializeHelper
    {
        public string Serialize<T>(T data)
        {

            return JsonConvert.SerializeObject
            (data, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
