using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{

    class EntryFieldAttribute : Attribute
    { }

    interface ISerializer
    {
      
    }

    interface ITextSerializer : ISerializer
    {
        string SerializeToString(object obj);
    }


    interface IBinarySerializer : ITextSerializer
    {
        byte[] SerializeToBytes(object obj);
    }

    class EncodingBinaryFrame : Attribute, IBinarySerializer
    {
        ITextSerializer innerSerializer;
        public EncodingBinaryFrame(Type textSerializer, string containerFieldName=null)
        {
            innerSerializer = textSerializer.GetConstructor(new Type[0]).Invoke(new object[0]) as ITextSerializer;
        }



        public byte[] SerializeToBytes(object obj)
        {
            return System.Text.Encoding.UTF8.GetBytes(innerSerializer.SerializeToString(obj));
        }


        public string SerializeToString(object obj)
        {
            return innerSerializer.SerializeToString(obj);
        }
    }


}
