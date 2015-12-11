using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.ProtocolStack
{
    public class TypeWrapper
    {
        public readonly Type Type;
        public readonly FieldInfo Field;
        
        public TypeWrapper(Type t)
        {
            Type = t;
            Field = t.GetFields().Where(z => z.GetCustomAttributes(typeof(EntryFieldAttribute), false).Any()).FirstOrDefault();
            if (Field.FieldType != typeof(object)) throw new Exception("'Entry' field must be an object");
        }

        public object GetValue(object obj)
        {
            return Field.GetValue(obj);
        }

        public void SetValue(object obj, object value)
        {
            Field.SetValue(obj, value);
        }

    }
}
