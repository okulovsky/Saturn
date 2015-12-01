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

    class JsonSerializer : Attribute, ITextSerializer
    {
        string SimpleSerialization(object obj,  string entryFieldName, string entryFieldValue)
        {
            var jsonObject = JObject.FromObject(obj);

            if (entryFieldName != null)
                jsonObject.Property(entryFieldName).Value = entryFieldValue;

            return jsonObject.ToString();
        }

        public string SerializeToString(object obj)
        {
            var property = obj.GetType().GetProperties().Where(z => z.GetCustomAttributes(typeof(EntryFieldAttribute),false).Any()).FirstOrDefault();
            var field = obj.GetType().GetFields().Where(z => z.GetCustomAttributes(typeof(EntryFieldAttribute),false).Any()).FirstOrDefault();

            if (property != null && field != null)
                throw new Exception();

            if (property == null && field == null)
                return SimpleSerialization(obj, null, null);

            object entry = null;
            string fieldName = null;
            if (property != null)
            {
                entry = property.GetValue(obj);
                fieldName = property.Name;
            }
            else
            {
                entry = field.GetValue(obj);
                fieldName = field.Name;
            }
           
            if (entry == null)
                return SimpleSerialization(obj, null, null);

            if (entry is string)
                return SimpleSerialization(obj, fieldName, entry as string);

            var innerSerializer = entry.GetType().GetCustomAttributes(false).OfType<ISerializer>().FirstOrDefault();
            if (innerSerializer == null)
                return SimpleSerialization(obj, fieldName, SimpleSerialization(entry, null, null));
            if (innerSerializer is IBinarySerializer)
                return SimpleSerialization(obj, fieldName, Convert.ToBase64String((innerSerializer as IBinarySerializer).SerializeToBytes(entry)));
            if (innerSerializer is ITextSerializer)
                return SimpleSerialization(obj, fieldName, (innerSerializer as ITextSerializer).SerializeToString(entry));
            throw new Exception("Should not reach this place");
        }
    }
}
