using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class ICMS
    {
        [XmlElement("ICMSSN102")]
        public ICMSSN102 ICMSSN102 { get; set; }

        [XmlElement("ICMS00")]
        public ICMS00 ICMS00 { get; set; }
    }
}
