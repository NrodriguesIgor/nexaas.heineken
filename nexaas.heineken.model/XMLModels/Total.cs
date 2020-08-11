using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class Total
    {
        [XmlElement("ICMSTot")]
        public ICMSTot ICMSTot { get; set; }

        [XmlElement("VCFe")]
        public string VCFe { get; set; }

        [XmlElement("vNF")]
        public string vNF { get; set; }

        [XmlElement("VCFeLei12741")]
        public string VCFeLei12741 { get; set; }
    }
}
