using System.Collections.Generic;
using System.Xml.Serialization;

namespace nexaas.heineken.model.XMLModels
{
    public class InfNFe
    {
        public string Versao { get; set; }
        public string Id { get; set; }

        [XmlElement("ide")]
        public Ide Ide { get; set; }

        [XmlElement("emit")]
        public Emit Emit { get; set; }

        [XmlElement("dest")]
        public Dest Dest { get; set; }

        [XmlElement("det")]
        public List<Det> Det { get; set; }

        [XmlElement("total")]
        public Total Total { get; set; }
        public Transp Transp { get; set; }
        public Pag Pag { get; set; }
        public InfRespTec InfRespTec { get; set; }
    }
}
