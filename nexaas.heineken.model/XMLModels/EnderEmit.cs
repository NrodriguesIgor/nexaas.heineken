using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class EnderEmit
    {
        [XmlElement("xLgr")]
        public string XLgr { get; set; }

        [XmlElement("nro")]
        public string Nro { get; set; }

        public string XCpl { get; set; }

        [XmlElement("xBairro")]
        public string XBairro { get; set; }

        [XmlElement("xMun")]
        public string XMun { get; set; }

        [XmlElement("CEP")]
        public string CEP { get; set; }

        [XmlElement("cMun")]
        public string CMun { get; set; }

        [XmlElement("UF")]
        public string UF { get; set; }

        public string CPais { get; set; }

        public string XPais { get; set; }

        public string Fone { get; set; }
    }
}
