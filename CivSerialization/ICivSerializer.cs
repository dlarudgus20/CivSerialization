using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CivSerialization
{
    public interface ICivSerializer
    {
        ICollection<KeyValuePair<Guid, Type>> KnownTypes { get; }

        void Serialize(StreamWriter writer, object value);
        object Deserialize(StreamReader reader, Type type);
        object Deserialize(StreamReader reader);
    }

    public interface ICivSerializable
    {
        void DoSerialize(ICivSerializationWriter writer);
    }

    public interface ICivSerializationReader
    {
        object GetValue(string name, Type type);
        object GetValue(string name);
        T GetCollection<T>() where T : ICollection<object>, new();

        string GetString(string name);
        char GetCharacter(string name);
        bool GetBoolean(string name);
        DateTime GetDateTime(string name);
        ulong GetUInt64(string name);
        long GetInt64(string name);
        uint GetUInt32(string name);
        int GetInt32(string name);
        ushort GetUInt16(string name);
        short GetInt16(string name);
        byte GetByte(string name);
        sbyte GetSByte(string name);
        float GetSingle(string name);
        double GetDouble(string name);
        decimal GetDecimal(string name);
    }

    public interface ICivSerializationWriter
    {
        void AddValue(string name, object value);
        void AddValue(string name, IEnumerable<object> value);

        void AddValue(string name, string value);
        void AddValue(string name, char value);
        void AddValue(string name, bool value);
        void AddValue(string name, DateTime value);
        void AddValue(string name, ulong value);
        void AddValue(string name, long value);
        void AddValue(string name, uint value);
        void AddValue(string name, int value);
        void AddValue(string name, ushort value);
        void AddValue(string name, short value);
        void AddValue(string name, byte value);
        void AddValue(string name, sbyte value);
        void AddValue(string name, float value);
        void AddValue(string name, double value);
        void AddValue(string name, decimal value);
    }
}
