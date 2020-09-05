using System.Collections.Generic;
using System.Xml.Serialization;

namespace nexaas.heineken.model.CFeModels
{
    public class CFe
    {
        [XmlElement(ElementName = "infCFe")]
        public infCFe infCFe { get; set; }

        //[XmlElement(ElementName = "Signature")]
        //public Signature Signature { get; set; }
    }

    public class infCFe
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("versao")]
        public string versao { get; set; }

        [XmlAttribute("versaoDadosEnt")]
        public string versaoDadosEnt { get; set; }

        [XmlAttribute("versaoSB")]
        public string versaoSB { get; set; }

        [XmlElement(ElementName = "ide")]
        public ide ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public emit emit { get; set; }

        [XmlElement(ElementName = "dest")]
        public dest dest { get; set; }

        [XmlElement(ElementName = "det")]
        public List<det> det { get; set; }

        [XmlElement(ElementName = "total")]
        public total total { get; set; }

        [XmlElement(ElementName = "pgto")]
        public pgto pgto { get; set; }

        [XmlElement(ElementName = "infAdic")]
        public infAdic infAdic { get; set; }
    }

    public class total
    {
        [XmlElement(ElementName = "ICMSTot")]
        public ICMSTot ICMSTot { get; set; }

        [XmlElement(ElementName = "vCFe")]
        public string vCFe { get; set; }

        [XmlElement(ElementName = "vCFeLei12741")]
        public string vCFeLei12741 { get; set; }
    }

    public class ICMSTot
    {
        [XmlElement(ElementName = "vICMS")]
        public string vICMS { get; set; }

        [XmlElement(ElementName = "vProd")]
        public string vProd { get; set; }

        [XmlElement(ElementName = "vDesc")]
        public string vDesc { get; set; }

        [XmlElement(ElementName = "vPIS")]
        public string vPIS { get; set; }

        [XmlElement(ElementName = "vCOFINS")]
        public string vCOFINS { get; set; }

        [XmlElement(ElementName = "vPISST")]
        public string vPISST { get; set; }

        [XmlElement(ElementName = "vCOFINSST")]
        public string vCOFINSST { get; set; }

        [XmlElement(ElementName = "vOutro")]
        public string vOutro { get; set; }
    }

    public class pgto
    {
        [XmlElement(ElementName = "MP")]
        public MP MP { get; set; }

        [XmlElement(ElementName = "vTroco")]
        public string vTroco { get; set; }
    }

    public class MP
    {
        [XmlElement(ElementName = "cMP")]
        public string cMP { get; set; }

        [XmlElement(ElementName = "vMP")]
        public string vMP { get; set; }
    }

    public class ide
    {
        [XmlElement(ElementName = "cUF")]
        public string cUF { get; set; }

        [XmlElement(ElementName = "cNF")]
        public string cNF { get; set; }

        [XmlElement(ElementName = "mod")]
        public string mod { get; set; }

        [XmlElement(ElementName = "nserieSAT")]
        public string nserieSAT { get; set; }

        [XmlElement(ElementName = "nCFe")]
        public string nCFe { get; set; }

        [XmlElement(ElementName = "dEmi")]
        public string dEmi { get; set; }

        [XmlElement(ElementName = "hEmi")]
        public string hEmi { get; set; }

        [XmlElement(ElementName = "cDV")]
        public string cDV { get; set; }

        [XmlElement(ElementName = "tpAmb")]
        public string tpAmb { get; set; }

        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement(ElementName = "signAC")]
        public string signAC { get; set; }

        [XmlElement(ElementName = "assinaturaQRCODE")]
        public string assinaturaQRCODE { get; set; }

        [XmlElement(ElementName = "numeroCaixa")]
        public string numeroCaixa { get; set; }
    }

    public class det
    {
        [XmlAttribute("nItem")]
        public string nItem { get; set; }

        [XmlElement(ElementName = "prod")]
        public prod prod { get; set; }

        [XmlElement(ElementName = "imposto")]
        public imposto imposto { get; set; }
    }

    public class prod
    {
        [XmlElement(ElementName = "cProd")]
        public string cProd { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string xProd { get; set; }

        [XmlElement(ElementName = "NCM")]
        public string NCM { get; set; }

        [XmlElement(ElementName = "CFOP")]
        public string CFOP { get; set; }

        [XmlElement(ElementName = "uCom")]
        public string uCom { get; set; }

        [XmlElement(ElementName = "qCom")]
        public string qCom { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public string vUnCom { get; set; }

        [XmlElement(ElementName = "vProd")]
        public string vProd { get; set; }

        [XmlElement(ElementName = "indRegra")]
        public string indRegra { get; set; }

        [XmlElement(ElementName = "vItem")]
        public string vItem { get; set; }
    }

    public class imposto
    {
        [XmlElement(ElementName = "vItem12741")]
        public string vItem12741 { get; set; }

        [XmlElement(ElementName = "ICMS")]
        public ICMS ICMS { get; set; }

        [XmlElement(ElementName = "PIS")]
        public PIS PIS { get; set; }

        [XmlElement(ElementName = "COFINS")]
        public COFINS COFINS { get; set; }
    }

    public class ICMS
    {
        [XmlElement(ElementName = "ICMS00")]
        public ICMS00 ICMS00 { get; set; }

        [XmlElement(ElementName = "ICMS40")]
        public ICMS40 ICMS40 { get; set; }
    }

    public class ICMS00
    {
        [XmlElement(ElementName = "Orig")]
        public string Orig { get; set; }

        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

        [XmlElement(ElementName = "pICMS")]
        public string pICMS { get; set; }

        [XmlElement(ElementName = "vICMS")]
        public string vICMS { get; set; }
    }

    public class ICMS40
    {
        [XmlElement(ElementName = "Orig")]
        public string Orig { get; set; }

        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }
    }

    public class PIS
    {
        [XmlElement(ElementName = "PISAliq")]
        public PISAliq PISAliq { get; set; }

        [XmlElement(ElementName = "PISNT")]
        public PISNT PISNT { get; set; }
    }

    public class PISAliq
    {
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

        [XmlElement(ElementName = "vBC")]
        public string vBC { get; set; }

        [XmlElement(ElementName = "pPIS")]
        public string pPIS { get; set; }

        [XmlElement(ElementName = "vPIS")]
        public string vPIS { get; set; }
    }

    public class PISNT
    {
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }
    }

    public class COFINS
    {
        [XmlElement(ElementName = "COFINSAliq")]
        public COFINSAliq COFINSAliq { get; set; }

        [XmlElement(ElementName = "COFINSNT")]
        public COFINSNT COFINSNT { get; set; }
    }

    public class COFINSAliq
    {
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }

        [XmlElement(ElementName = "vBC")]
        public string vBC { get; set; }

        [XmlElement(ElementName = "pCOFINS")]
        public string pCOFINS { get; set; }

        [XmlElement(ElementName = "vCOFINS")]
        public string vCOFINS { get; set; }
    }

    public class COFINSNT
    {
        [XmlElement(ElementName = "CST")]
        public string CST { get; set; }
    }


    public class emit
    {
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string xNome { get; set; }

        [XmlElement(ElementName = "xFant")]
        public string xFant { get; set; }

        [XmlElement(ElementName = "enderEmit")]
        public enderEmit enderEmit { get; set; }

        [XmlElement(ElementName = "IE")]
        public string IE { get; set; }

        [XmlElement(ElementName = "cRegTrib")]
        public string cRegTrib { get; set; }

        [XmlElement(ElementName = "cRegTribISSQN")]
        public string cRegTribISSQN { get; set; }

        [XmlElement(ElementName = "indRatISSQN")]
        public string indRatISSQN { get; set; }
    }

    public class enderEmit
    {
        [XmlElement(ElementName = "xLgr")]
        public string xLgr { get; set; }

        [XmlElement(ElementName = "nro")]
        public string nro { get; set; }

        [XmlElement(ElementName = "xBairro")]
        public string xBairro { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string xMun { get; set; }

        [XmlElement(ElementName = "CEP")]
        public string CEP { get; set; }
    }

    public class dest { }


    public class infAdic
    {
        [XmlElement(ElementName = "infCpl")]
        public string infCpl { get; set; }

        [XmlElement(ElementName = "obsFisco")]
        public obsFisco obsFisco { get; set; }
    }

    public class obsFisco
    {
        [XmlElement(ElementName = "xTexto")]
        public string xTexto { get; set; }
    }

    public class Signature
    {
        [XmlAttribute("xmlns")]
        public string xmlns { get; set; }

        //[XmlElement(ElementName = "SignedInfo")]
        //public SignedInfo SignedInfo { get; set; }

        [XmlElement(ElementName = "SignatureValue")]
        public string SignatureValue { get; set; }

        //[XmlElement(ElementName = "KeyInfo")]
        //public KeyInfo KeyInfo { get; set; }
    }

    public class SignedInfo
    {
        [XmlElement(ElementName = "CanonicalizationMethod")]
        public CanonicalizationMethod CanonicalizationMethod { get; set; }

        [XmlElement(ElementName = "SignatureMethod")]
        public SignatureMethod SignatureMethod { get; set; }

        [XmlElement(ElementName = "Reference")]
        public Reference Reference { get; set; }
    }

    public class CanonicalizationMethod
    {
        [XmlAttribute("Algorithm")]
        public string Algorithm { get; set; }
    }

    public class SignatureMethod
    {
        [XmlAttribute("Algorithm")]
        public string Algorithm { get; set; }
    }

    public class Reference
    {
        [XmlAttribute("URI")]
        public string URI { get; set; }

        [XmlElement(ElementName = "Transforms")]
        public Transforms Transforms { get; set; }

        [XmlElement(ElementName = "DigestMethod")]
        public DigestMethod DigestMethod { get; set; }

        [XmlElement(ElementName = "DigestValue")]
        public string DigestValue { get; set; }
    }

    public class Transforms
    {
        [XmlElement(ElementName = "Transform")]
        public List<Transform> Transform { get; set; }
    }

    public class Transform
    {
        [XmlAttribute("Algorithm")]
        public string Algorithm { get; set; }
    }

    public class DigestMethod
    {
        [XmlAttribute("Algorithm")]
        public string Algorithm { get; set; }
    }

    public class KeyInfo
    {
        [XmlElement(ElementName = "X509Data")]
        public X509Data X509Data { get; set; }
    }

    public class X509Data
    {
        [XmlElement(ElementName = "X509Certificate")]
        public string X509Certificate { get; set; }
    }

}