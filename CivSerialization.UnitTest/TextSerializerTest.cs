using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CivSerialization;

namespace CivSerialization.UnitTest
{
    [TestClass]
    public class TextSerializerTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            ReadWriteTest(new SimpleClass() { value = 42 });
        }

        [TestMethod]
        public void PrimitiveTest()
        {
            ReadWriteTest("hello serial");
            ReadWriteTest('c');
            ReadWriteTest(true);
            ReadWriteTest(DateTime.Now);
            ReadWriteTest(123UL);
            ReadWriteTest(456L);
            ReadWriteTest(68U);
            ReadWriteTest(89);
            ReadWriteTest((ushort)21);
            ReadWriteTest((short)43);
            ReadWriteTest(3.14f);
            ReadWriteTest(2.71);
            ReadWriteTest(0.5772M);
        }

        private void ReadWriteTest<T>(T initial)
        {
            var serializer = new TextSerializer();

            T source = initial;
            T result = default(T);

            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);

                serializer.Serialize(writer, initial);
                writer.Flush();

                var reader = new StreamReader(stream);
                result = (T)serializer.Deserialize(reader, typeof(T));
            }

            Assert.Equals(source, initial);
        }
    }

    class SimpleClass : ICivSerializable
    {
        public int value = 0;

        public SimpleClass()
        {
        }
        public override bool Equals(object obj)
        {
            return value == (obj as SimpleClass)?.value;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        private SimpleClass(ICivSerializationReader reader, ICivSerializable parent)
        {
            value = reader.GetInt32(nameof(value));
        }
        public void DoSerialize(ICivSerializationWriter writer)
        {
            writer.AddValue(nameof(value), value);
        }
    }
}
