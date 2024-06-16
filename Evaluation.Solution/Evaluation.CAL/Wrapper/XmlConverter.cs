using Evaluation.CAL.DTO;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;

namespace Evaluation.CAL.Wrapper
{
    public static class XmlConverter
    {
        public static string FromClass<T>(T data)
        {
            string response = string.Empty;

            var ms = new MemoryStream();
            try
            {
                ms = FromClassToStream(data, new XmlSerializerNamespaces());

                if (ms != null)
                {
                    ms.Position = 0;
                    using (var sr = new StreamReader(ms))
                        response = sr.ReadToEnd();
                }

            }
            finally
            {
                // don't want memory leaks...
                ms.Flush();
                ms.Dispose();
                ms = null;
            }

            return response;
        }

        public static MemoryStream FromClassToStream<T>(T data, XmlSerializerNamespaces ns = null)
        {
            var stream = default(MemoryStream);

            if (data != null)
            {
                var settings = new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8,
                    Indent = true,
                    ConformanceLevel = ConformanceLevel.Auto,
                    CheckCharacters = true,
                    OmitXmlDeclaration = true
                };

                try
                {
                    XmlSerializer serializer = XmlSerializerFactoryNoThrow.Create(typeof(T));

                    stream = new MemoryStream();
                    using (XmlWriter writer = XmlWriter.Create(stream, settings))
                    {
                        ns.Add("", "");
                        serializer.Serialize(writer, data, ns);
                        writer.Flush();
                    }
                    stream.Position = 0;
                }
                catch (Exception)
                {
                    stream = default(MemoryStream);
                }
            }
            return stream;
        }

        public static T ToClass<T>(string data)
        {
            var response = default(T);

            if (!string.IsNullOrEmpty(data))
            {
                var settings = new XmlReaderSettings()
                {
                    IgnoreWhitespace = true,
                    DtdProcessing = DtdProcessing.Ignore
                };

                XmlSerializer serializer = XmlSerializerFactoryNoThrow.Create(typeof(T));

                using (var sr = new StringReader(data))
                using (var reader = XmlReader.Create(sr, settings))
                    response = (T)Convert.ChangeType(serializer.Deserialize(reader), typeof(T));
            }
            return response;
        }
    }

    // ref: http://stackoverflow.com/questions/1127431/xmlserializer-giving-filenotfoundexception-at-constructor/39642834#39642834
    public static class XmlSerializerFactoryNoThrow
    {
        public static Dictionary<Type, XmlSerializer> cache = new Dictionary<Type, XmlSerializer>();

        private static readonly object SyncRootCache = new object();

        public static XmlSerializer Create(Type type)
        {
            XmlSerializer serializer;

            lock (SyncRootCache)
                if (cache.TryGetValue(type, out serializer))
                    return serializer;

            //multiple variable of type of one type is same instance
            lock (type)
            {
                //constructor XmlSerializer.FromTypes does not throw the first chance exception           
                serializer = XmlSerializer.FromTypes(new[] { type })[0];
            }

            lock (SyncRootCache) cache[type] = serializer;
            return serializer;
        }
    }
}
