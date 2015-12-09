using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Saturn.ProtocolStack
{
    public class XmlSerializer : TextSerializer
    {
        class Doc
        {
            public object Document { get; set; }
        }
        protected override string InnerSerialization(object obj)
        {
            var doc = new Doc { Document = obj };
            var myXmlNode = JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(doc));
            var result = myXmlNode.InnerXml;
            return result;
        }
    }
}
