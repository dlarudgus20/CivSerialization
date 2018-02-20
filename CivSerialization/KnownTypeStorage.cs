using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivSerialization
{
    class KnownTypeStorage : ICollection<KeyValuePair<Guid, Type>>, IReadOnlyCollection<KeyValuePair<Guid, Type>>
    {
        private List<KeyValuePair<Guid, Type>> _list = new List<KeyValuePair<Guid, Type>>();

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        /*public object Deserialize(SerializationInfo info, string name, Type baseType)
        {
            var key = (Guid)info.GetValue(name + "_GUID", typeof(Guid));
            if (key == Guid.Empty)
                return null;

            Type type = _list.Where(pr => pr.Key == key).Select(pr => pr.Value).FirstOrDefault();
            if (type == null || !type.IsSubclassOf(baseType))
                throw new SerializationException();

            return info.GetValue(name, type);
        }

        public void Serialize(SerializationInfo info, string name, object value)
        {
            if (value == null)
            {
                info.AddValue(name + "_GUID", Guid.Empty);
            }
            else
            {
                Guid guid;
                try
                {
                    guid = _list.Where(pr => pr.Value == value.GetType()).Select(pr => pr.Key).First();
                }
                catch (InvalidOperationException)
                {
                    throw new SerializationException();
                }

                info.AddValue(name + "_GUID", guid);
                info.AddValue(name, value);
            }
        }*/

        public void Add(KeyValuePair<Guid, Type> item)
        {
            if (item.Key == Guid.Empty)
                throw new ArgumentException("guid is empty", nameof(item));
            if (!item.Value.IsSerializable)
                throw new ArgumentException("type is not serializable", nameof(item));

            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(KeyValuePair<Guid, Type> item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(KeyValuePair<Guid, Type>[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<Guid, Type>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public bool Remove(KeyValuePair<Guid, Type> item)
        {
            return _list.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
