using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    public abstract class TextSerializer : Attribute, ITextSerializer
    {
        protected abstract string InnerSerialization(object obj);


        static readonly Dictionary<Type, TypeWrapper> wrappers = new Dictionary<Type, TypeWrapper>();
       

        public string SerializeToString(object obj)
        {
            var type = obj.GetType();
            if (!wrappers.ContainsKey(type))
                wrappers[type] = new TypeWrapper(type);
            var wrapper = wrappers[type]; 

            var entry = wrapper.GetValue(obj);

            if (entry == null || entry is string)
                return InnerSerialization(obj);

            var innerSerializer = entry.GetType().GetCustomAttributes(false).OfType<ISerializer>().FirstOrDefault();
            if (innerSerializer == null)
                return InnerSerialization(obj);

            object temp=null;
            if (innerSerializer is IBinarySerializer)
                temp=Convert.ToBase64String((innerSerializer as IBinarySerializer).SerializeToBytes(entry));
            else if (innerSerializer is ITextSerializer)
                temp=(innerSerializer as ITextSerializer).SerializeToString(entry);
            else 
                throw new Exception("Should not reach this place");

            wrapper.SetValue(obj, temp);
            var result = InnerSerialization(obj);
            wrapper.SetValue(obj, entry);
            return result;
        }
    }
}
