using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class NFe
    {
        [XmlElement(ElementName = "infNFe")]
        public InfNFe InfNFe { get; set; }

        [XmlElement(ElementName = "infNFeSupl")]
        public InfNFeSupl InfNFeSupl { get; set; }
    }


    [XmlRoot(ElementName = "nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public class NfeProc
    {
        [XmlElement("NFe")]
        public NFe NFe { get; set; }

        [XmlElement("protNFe")]
        public ProtNFe ProtNFe { get; set; }

        [XmlAttribute("versao")]
        public string versao { get; set; }
    }

    public class Example
    {
        public NfeProc nfeProc { get; set; }
    }

}
