using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class ProtNFe
    {
        [XmlAttribute("versao")]
        public string Versao { get; set; }

        [XmlElement("infProt")]
        public InfProt InfProt { get; set; }
    }
}
