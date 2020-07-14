using System;
using System.IO;
using System.Xml.Serialization;

namespace nexaas.heineken.model
{
    public class NFeSerialization
    {
        public T GetObjectFromFile<T>(string arquivo) where T : class
        {
            var serialize = new XmlSerializer(typeof(T));

            try
            {
                return (T)serialize.Deserialize(new StringReader(arquivo));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
