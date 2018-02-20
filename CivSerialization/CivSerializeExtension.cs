using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSerialization
{
    public static class CivSerializeExtension
    {
        public static void AutoDeserialize(object serializable, ICivSerializationReader writer)
        {
            throw new NotImplementedException();
        }

        public static void AutoSerialize(object serializable, ICivSerializationWriter writer)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(this ICivSerializer serializer) where T : ICivSerializable
        {
            throw new NotImplementedException();
        }

        public static T GetValue<T>(this ICivSerializationReader reader) where T : ICivSerializable
        {
            throw new NotImplementedException();
        }

        public static T AddValue<T>(this ICivSerializationWriter writer, string name) where T : ICivSerializable
        {
            throw new NotImplementedException();
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CivAutoSerializableAttribute : Attribute
    {
        public bool IsWhitelist { get; set; } = false;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CivSerializableAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CivNonSerializableAttribute : Attribute
    {
    }
}
