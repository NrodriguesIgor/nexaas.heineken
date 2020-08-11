using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class Emit
    {
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement("xNome")]
        public string XNome { get; set; }

        [XmlElement("emit")]
        public string XFant { get; set; }

        [XmlElement("enderEmit")]
        public EnderEmit EnderEmit { get; set; }

        [XmlElement("IE")]
        public string IE { get; set; }

        public string CRegTrib { get; set; }

        public string CRegTribISSQN { get; set; }

        public string IndRatISSQN { get; set; }

        [XmlElement("CRT")]
        public string CRT { get; set; }
    }
}
