using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class Det
    {
        [XmlElement("prod")]
        public Prod Prod { get; set; }

        [XmlElement("imposto")]
        public Imposto Imposto { get; set; }

        [XmlAttribute("nItem")]
        public string NItem { get; set; }
        
    }
}
