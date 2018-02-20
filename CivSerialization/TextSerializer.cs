using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CivSerialization
{
    public class TextSerializer : ICivSerializer
    {
        public ICollection<KeyValuePair<Guid, Type>> KnownTypes => _knownTypes;
        private readonly KnownTypeStorage _knownTypes = new KnownTypeStorage();

        public object Deserialize(StreamReader reader, Type type)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(StreamReader reader)
        {
            throw new NotImplementedException();
        }

        public void Serialize(StreamWriter writer, object value)
        {
            throw new NotImplementedException();
        }
    }
}
