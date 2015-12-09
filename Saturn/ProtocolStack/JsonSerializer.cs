using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    class JsonSerializer : TextSerializer
    {
        override protected string InnerSerialization(object obj)
        {
            var jsonObject = JObject.FromObject(obj);
            return jsonObject.ToString();
        }
    }
}
