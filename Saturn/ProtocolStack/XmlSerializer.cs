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
        protected override string InnerSerialization(object obj)
        {
            var xsSubmit = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            using (StringWriter sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xsSubmit.Serialize(writer, obj);
                return sww.ToString(); // Your XML
            }
        }
    }
}
