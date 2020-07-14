using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class Imposto
    {
        public string vItem12741 { get; set; }

        [XmlElement("ICMS")]
        public ICMS ICMS { get; set; }

        [XmlElement("PIS")]
        public PIS PIS { get; set; }

        [XmlElement("COFINS")]
        public COFINS COFINS { get; set; }

        [XmlElement("vTotTrib")]
        public string vTotTrib { get; set; }
    }
}
