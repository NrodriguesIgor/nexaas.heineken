using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class DetPag
    {
        [XmlElement("tPag")]
        public string TPag { get; set; }

        [XmlElement("vPag")]
        public string VPag { get; set; }
    }
}
