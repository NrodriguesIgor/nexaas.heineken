using System;
using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class InfProt
    {
        [XmlElement("tpAmb")]
        public string TpAmb { get; set; }

        [XmlElement("verAplic")]
        public string VerAplic { get; set; }

        [XmlElement("chNFe")]
        public string ChNFe { get; set; }

        [XmlElement("dhRecbto")]
        public DateTime DhRecbto { get; set; }

        [XmlElement("nProt")]
        public string NProt { get; set; }

        [XmlElement("digVal")]
        public string DigVal { get; set; }

        [XmlElement("cStat")]
        public string CStat { get; set; }

        [XmlElement("xMotivo")]
        public string XMotivo { get; set; }
    }
}
