using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class Transp
    {
        [XmlElement("modFrete")]
        public string ModFrete { get; set; }
    }
}
