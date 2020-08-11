using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace nexaas.heineken.model.CFEModels
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class CFe
    {

        private CFeInfCFe infCFeField;

        private Signature signatureField;

        /// <remarks/>
        public CFeInfCFe infCFe
        {
            get
            {
                return this.infCFeField;
            }
            set
            {
                this.infCFeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFe
    {

        private CFeInfCFeIde ideField;

        private CFeInfCFeEmit emitField;

        private object destField;

        //private CFeInfCFeDet detField;

        private CFeInfCFeTotal totalField;

        private CFeInfCFePgto pgtoField;

        private CFeInfCFeInfAdic infAdicField;

        private string idField;

        private decimal versaoField;

        private decimal versaoDadosEntField;

        private ushort versaoSBField;

        /// <remarks/>
        public CFeInfCFeIde ide
        {
            get
            {
                return this.ideField;
            }
            set
            {
                this.ideField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFeEmit emit
        {
            get
            {
                return this.emitField;
            }
            set
            {
                this.emitField = value;
            }
        }

        /// <remarks/>
        public object dest
        {
            get
            {
                return this.destField;
            }
            set
            {
                this.destField = value;
            }
        }

        ///// <remarks/>
        //public CFeInfCFeDet det
        //{
        //    get
        //    {
        //        return this.detField;
        //    }
        //    set
        //    {
        //        this.detField = value;
        //    }
        //}

        [XmlElement("det")]
        public List<CFeInfCFeDet> det { get; set; }


        /// <remarks/>
        public CFeInfCFeTotal total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFePgto pgto
        {
            get
            {
                return this.pgtoField;
            }
            set
            {
                this.pgtoField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFeInfAdic infAdic
        {
            get
            {
                return this.infAdicField;
            }
            set
            {
                this.infAdicField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal versao
        {
            get
            {
                return this.versaoField;
            }
            set
            {
                this.versaoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal versaoDadosEnt
        {
            get
            {
                return this.versaoDadosEntField;
            }
            set
            {
                this.versaoDadosEntField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort versaoSB
        {
            get
            {
                return this.versaoSBField;
            }
            set
            {
                this.versaoSBField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeIde
    {

        private byte cUFField;

        private uint cNFField;

        private byte modField;

        private uint nserieSATField;

        private byte nCFeField;

        private uint dEmiField;

        private uint hEmiField;

        private byte cDVField;

        private byte tpAmbField;

        private ulong cNPJField;

        private string signACField;

        private string assinaturaQRCODEField;

        private ushort numeroCaixaField;

        /// <remarks/>
        public byte cUF
        {
            get
            {
                return this.cUFField;
            }
            set
            {
                this.cUFField = value;
            }
        }

        /// <remarks/>
        public uint cNF
        {
            get
            {
                return this.cNFField;
            }
            set
            {
                this.cNFField = value;
            }
        }

        /// <remarks/>
        public byte mod
        {
            get
            {
                return this.modField;
            }
            set
            {
                this.modField = value;
            }
        }

        /// <remarks/>
        public uint nserieSAT
        {
            get
            {
                return this.nserieSATField;
            }
            set
            {
                this.nserieSATField = value;
            }
        }

        /// <remarks/>
        public byte nCFe
        {
            get
            {
                return this.nCFeField;
            }
            set
            {
                this.nCFeField = value;
            }
        }

        /// <remarks/>
        public uint dEmi
        {
            get
            {
                return this.dEmiField;
            }
            set
            {
                this.dEmiField = value;
            }
        }

        /// <remarks/>
        public uint hEmi
        {
            get
            {
                return this.hEmiField;
            }
            set
            {
                this.hEmiField = value;
            }
        }

        /// <remarks/>
        public byte cDV
        {
            get
            {
                return this.cDVField;
            }
            set
            {
                this.cDVField = value;
            }
        }

        /// <remarks/>
        public byte tpAmb
        {
            get
            {
                return this.tpAmbField;
            }
            set
            {
                this.tpAmbField = value;
            }
        }

        /// <remarks/>
        public ulong CNPJ
        {
            get
            {
                return this.cNPJField;
            }
            set
            {
                this.cNPJField = value;
            }
        }

        /// <remarks/>
        public string signAC
        {
            get
            {
                return this.signACField;
            }
            set
            {
                this.signACField = value;
            }
        }

        /// <remarks/>
        public string assinaturaQRCODE
        {
            get
            {
                return this.assinaturaQRCODEField;
            }
            set
            {
                this.assinaturaQRCODEField = value;
            }
        }

        /// <remarks/>
        public ushort numeroCaixa
        {
            get
            {
                return this.numeroCaixaField;
            }
            set
            {
                this.numeroCaixaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeEmit
    {

        private ulong cNPJField;

        private string xNomeField;

        private string xFantField;

        private CFeInfCFeEmitEnderEmit enderEmitField;

        private ulong ieField;

        private byte cRegTribField;

        private byte cRegTribISSQNField;

        private string indRatISSQNField;

        /// <remarks/>
        public ulong CNPJ
        {
            get
            {
                return this.cNPJField;
            }
            set
            {
                this.cNPJField = value;
            }
        }

        /// <remarks/>
        public string xNome
        {
            get
            {
                return this.xNomeField;
            }
            set
            {
                this.xNomeField = value;
            }
        }

        /// <remarks/>
        public string xFant
        {
            get
            {
                return this.xFantField;
            }
            set
            {
                this.xFantField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFeEmitEnderEmit enderEmit
        {
            get
            {
                return this.enderEmitField;
            }
            set
            {
                this.enderEmitField = value;
            }
        }

        /// <remarks/>
        public ulong IE
        {
            get
            {
                return this.ieField;
            }
            set
            {
                this.ieField = value;
            }
        }

        /// <remarks/>
        public byte cRegTrib
        {
            get
            {
                return this.cRegTribField;
            }
            set
            {
                this.cRegTribField = value;
            }
        }

        /// <remarks/>
        public byte cRegTribISSQN
        {
            get
            {
                return this.cRegTribISSQNField;
            }
            set
            {
                this.cRegTribISSQNField = value;
            }
        }

        /// <remarks/>
        public string indRatISSQN
        {
            get
            {
                return this.indRatISSQNField;
            }
            set
            {
                this.indRatISSQNField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeEmitEnderEmit
    {

        private string xLgrField;

        private byte nroField;

        private string xBairroField;

        private string xMunField;

        private uint cEPField;

        /// <remarks/>
        public string xLgr
        {
            get
            {
                return this.xLgrField;
            }
            set
            {
                this.xLgrField = value;
            }
        }

        /// <remarks/>
        public byte nro
        {
            get
            {
                return this.nroField;
            }
            set
            {
                this.nroField = value;
            }
        }

        /// <remarks/>
        public string xBairro
        {
            get
            {
                return this.xBairroField;
            }
            set
            {
                this.xBairroField = value;
            }
        }

        /// <remarks/>
        public string xMun
        {
            get
            {
                return this.xMunField;
            }
            set
            {
                this.xMunField = value;
            }
        }

        /// <remarks/>
        public uint CEP
        {
            get
            {
                return this.cEPField;
            }
            set
            {
                this.cEPField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDet
    {

        private CFeInfCFeDetProd prodField;

        private CFeInfCFeDetImposto impostoField;

        private byte nItemField;

        /// <remarks/>
        public CFeInfCFeDetProd prod
        {
            get
            {
                return this.prodField;
            }
            set
            {
                this.prodField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFeDetImposto imposto
        {
            get
            {
                return this.impostoField;
            }
            set
            {
                this.impostoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte nItem
        {
            get
            {
                return this.nItemField;
            }
            set
            {
                this.nItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetProd
    {

        private uint cProdField;

        private string xProdField;

        private uint nCMField;

        private ushort cFOPField;

        private string uComField;

        private decimal qComField;

        private decimal vUnComField;

        private decimal vProdField;

        private string indRegraField;

        private decimal vItemField;

        /// <remarks/>
        public uint cProd
        {
            get
            {
                return this.cProdField;
            }
            set
            {
                this.cProdField = value;
            }
        }

        /// <remarks/>
        public string xProd
        {
            get
            {
                return this.xProdField;
            }
            set
            {
                this.xProdField = value;
            }
        }

        /// <remarks/>
        public uint NCM
        {
            get
            {
                return this.nCMField;
            }
            set
            {
                this.nCMField = value;
            }
        }

        /// <remarks/>
        public ushort CFOP
        {
            get
            {
                return this.cFOPField;
            }
            set
            {
                this.cFOPField = value;
            }
        }

        /// <remarks/>
        public string uCom
        {
            get
            {
                return this.uComField;
            }
            set
            {
                this.uComField = value;
            }
        }

        /// <remarks/>
        public decimal qCom
        {
            get
            {
                return this.qComField;
            }
            set
            {
                this.qComField = value;
            }
        }

        /// <remarks/>
        public decimal vUnCom
        {
            get
            {
                return this.vUnComField;
            }
            set
            {
                this.vUnComField = value;
            }
        }

        /// <remarks/>
        public decimal vProd
        {
            get
            {
                return this.vProdField;
            }
            set
            {
                this.vProdField = value;
            }
        }

        /// <remarks/>
        public string indRegra
        {
            get
            {
                return this.indRegraField;
            }
            set
            {
                this.indRegraField = value;
            }
        }

        /// <remarks/>
        public decimal vItem
        {
            get
            {
                return this.vItemField;
            }
            set
            {
                this.vItemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImposto
    {

        private CFeInfCFeDetImpostoICMS iCMSField;

        private CFeInfCFeDetImpostoPIS pISField;

        private CFeInfCFeDetImpostoCOFINS cOFINSField;

        /// <remarks/>
        public CFeInfCFeDetImpostoICMS ICMS
        {
            get
            {
                return this.iCMSField;
            }
            set
            {
                this.iCMSField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFeDetImpostoPIS PIS
        {
            get
            {
                return this.pISField;
            }
            set
            {
                this.pISField = value;
            }
        }

        /// <remarks/>
        public CFeInfCFeDetImpostoCOFINS COFINS
        {
            get
            {
                return this.cOFINSField;
            }
            set
            {
                this.cOFINSField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoICMS
    {

        private CFeInfCFeDetImpostoICMSICMS00 iCMS00Field;

        /// <remarks/>
        public CFeInfCFeDetImpostoICMSICMS00 ICMS00
        {
            get
            {
                return this.iCMS00Field;
            }
            set
            {
                this.iCMS00Field = value;
            }
        }

        public CFeInfCFeDetImpostoICMSICMS40 ICMS40 { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoICMSICMS00
    {

        private byte origField;

        private byte cSTField;

        private decimal pICMSField;

        private decimal vICMSField;

        /// <remarks/>
        public byte Orig
        {
            get
            {
                return this.origField;
            }
            set
            {
                this.origField = value;
            }
        }

        /// <remarks/>
        public byte CST
        {
            get
            {
                return this.cSTField;
            }
            set
            {
                this.cSTField = value;
            }
        }

        /// <remarks/>
        public decimal pICMS
        {
            get
            {
                return this.pICMSField;
            }
            set
            {
                this.pICMSField = value;
            }
        }

        /// <remarks/>
        public decimal vICMS
        {
            get
            {
                return this.vICMSField;
            }
            set
            {
                this.vICMSField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoICMSICMS40
    {
        public byte Orig { get; set; }

        public byte CST { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoPIS
    {

        private CFeInfCFeDetImpostoPISPISAliq pISAliqField;

        /// <remarks/>
        public CFeInfCFeDetImpostoPISPISAliq PISAliq
        {
            get
            {
                return this.pISAliqField;
            }
            set
            {
                this.pISAliqField = value;
            }
        }

        public CFeInfCFeDetImpostoPISPISNT PISNT { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoPISPISAliq
    {

        private byte cSTField;

        private decimal vBCField;

        private decimal pPISField;

        private decimal vPISField;

        /// <remarks/>
        public byte CST
        {
            get
            {
                return this.cSTField;
            }
            set
            {
                this.cSTField = value;
            }
        }

        /// <remarks/>
        public decimal vBC
        {
            get
            {
                return this.vBCField;
            }
            set
            {
                this.vBCField = value;
            }
        }

        /// <remarks/>
        public decimal pPIS
        {
            get
            {
                return this.pPISField;
            }
            set
            {
                this.pPISField = value;
            }
        }

        /// <remarks/>
        public decimal vPIS
        {
            get
            {
                return this.vPISField;
            }
            set
            {
                this.vPISField = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoPISPISNT
    {
        public string CST { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoCOFINS
    {

        private CFeInfCFeDetImpostoCOFINSCOFINSAliq cOFINSAliqField;

        /// <remarks/>
        public CFeInfCFeDetImpostoCOFINSCOFINSAliq COFINSAliq
        {
            get
            {
                return this.cOFINSAliqField;
            }
            set
            {
                this.cOFINSAliqField = value;
            }
        }

        public CFeInfCFeDetImpostoCOFINSCOFINSNT COFINSNT { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeDetImpostoCOFINSCOFINSAliq
    {

        private byte cSTField;

        private decimal vBCField;

        private decimal pCOFINSField;

        private decimal vCOFINSField;

        /// <remarks/>
        public byte CST
        {
            get
            {
                return this.cSTField;
            }
            set
            {
                this.cSTField = value;
            }
        }

        /// <remarks/>
        public decimal vBC
        {
            get
            {
                return this.vBCField;
            }
            set
            {
                this.vBCField = value;
            }
        }

        /// <remarks/>
        public decimal pCOFINS
        {
            get
            {
                return this.pCOFINSField;
            }
            set
            {
                this.pCOFINSField = value;
            }
        }

        /// <remarks/>
        public decimal vCOFINS
        {
            get
            {
                return this.vCOFINSField;
            }
            set
            {
                this.vCOFINSField = value;
            }
        }
    }

    public partial class CFeInfCFeDetImpostoCOFINSCOFINSNT
    {
        public string CST { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeTotal
    {

        private CFeInfCFeTotalICMSTot iCMSTotField;

        private decimal vCFeField;

        private decimal vCFeLei12741Field;

        /// <remarks/>
        public CFeInfCFeTotalICMSTot ICMSTot
        {
            get
            {
                return this.iCMSTotField;
            }
            set
            {
                this.iCMSTotField = value;
            }
        }

        /// <remarks/>
        public decimal vCFe
        {
            get
            {
                return this.vCFeField;
            }
            set
            {
                this.vCFeField = value;
            }
        }

        /// <remarks/>
        public decimal vCFeLei12741
        {
            get
            {
                return this.vCFeLei12741Field;
            }
            set
            {
                this.vCFeLei12741Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeTotalICMSTot
    {

        private decimal vICMSField;

        private decimal vProdField;

        private decimal vDescField;

        private decimal vPISField;

        private decimal vCOFINSField;

        private decimal vPISSTField;

        private decimal vCOFINSSTField;

        private decimal vOutroField;

        /// <remarks/>
        public decimal vICMS
        {
            get
            {
                return this.vICMSField;
            }
            set
            {
                this.vICMSField = value;
            }
        }

        /// <remarks/>
        public decimal vProd
        {
            get
            {
                return this.vProdField;
            }
            set
            {
                this.vProdField = value;
            }
        }

        /// <remarks/>
        public decimal vDesc
        {
            get
            {
                return this.vDescField;
            }
            set
            {
                this.vDescField = value;
            }
        }

        /// <remarks/>
        public decimal vPIS
        {
            get
            {
                return this.vPISField;
            }
            set
            {
                this.vPISField = value;
            }
        }

        /// <remarks/>
        public decimal vCOFINS
        {
            get
            {
                return this.vCOFINSField;
            }
            set
            {
                this.vCOFINSField = value;
            }
        }

        /// <remarks/>
        public decimal vPISST
        {
            get
            {
                return this.vPISSTField;
            }
            set
            {
                this.vPISSTField = value;
            }
        }

        /// <remarks/>
        public decimal vCOFINSST
        {
            get
            {
                return this.vCOFINSSTField;
            }
            set
            {
                this.vCOFINSSTField = value;
            }
        }

        /// <remarks/>
        public decimal vOutro
        {
            get
            {
                return this.vOutroField;
            }
            set
            {
                this.vOutroField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFePgto
    {

        private CFeInfCFePgtoMP mpField;

        private decimal vTrocoField;

        /// <remarks/>
        public CFeInfCFePgtoMP MP
        {
            get
            {
                return this.mpField;
            }
            set
            {
                this.mpField = value;
            }
        }

        /// <remarks/>
        public decimal vTroco
        {
            get
            {
                return this.vTrocoField;
            }
            set
            {
                this.vTrocoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFePgtoMP
    {

        private byte cMPField;

        private decimal vMPField;

        /// <remarks/>
        public byte cMP
        {
            get
            {
                return this.cMPField;
            }
            set
            {
                this.cMPField = value;
            }
        }

        /// <remarks/>
        public decimal vMP
        {
            get
            {
                return this.vMPField;
            }
            set
            {
                this.vMPField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeInfAdic
    {

        private CFeInfCFeInfAdicObsFisco obsFiscoField;

        /// <remarks/>
        public CFeInfCFeInfAdicObsFisco obsFisco
        {
            get
            {
                return this.obsFiscoField;
            }
            set
            {
                this.obsFiscoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CFeInfCFeInfAdicObsFisco
    {

        private string xTextoField;

        private string xCampoField;

        /// <remarks/>
        public string xTexto
        {
            get
            {
                return this.xTextoField;
            }
            set
            {
                this.xTextoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string xCampo
        {
            get
            {
                return this.xCampoField;
            }
            set
            {
                this.xCampoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", IsNullable = false)]
    public partial class Signature
    {

        private SignatureSignedInfo signedInfoField;

        private string signatureValueField;

        private SignatureKeyInfo keyInfoField;

        /// <remarks/>
        public SignatureSignedInfo SignedInfo
        {
            get
            {
                return this.signedInfoField;
            }
            set
            {
                this.signedInfoField = value;
            }
        }

        /// <remarks/>
        public string SignatureValue
        {
            get
            {
                return this.signatureValueField;
            }
            set
            {
                this.signatureValueField = value;
            }
        }

        /// <remarks/>
        public SignatureKeyInfo KeyInfo
        {
            get
            {
                return this.keyInfoField;
            }
            set
            {
                this.keyInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfo
    {

        private SignatureSignedInfoCanonicalizationMethod canonicalizationMethodField;

        private SignatureSignedInfoSignatureMethod signatureMethodField;

        private SignatureSignedInfoReference referenceField;

        /// <remarks/>
        public SignatureSignedInfoCanonicalizationMethod CanonicalizationMethod
        {
            get
            {
                return this.canonicalizationMethodField;
            }
            set
            {
                this.canonicalizationMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoSignatureMethod SignatureMethod
        {
            get
            {
                return this.signatureMethodField;
            }
            set
            {
                this.signatureMethodField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoReference Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoCanonicalizationMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoSignatureMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReference
    {

        private SignatureSignedInfoReferenceTransform[] transformsField;

        private SignatureSignedInfoReferenceDigestMethod digestMethodField;

        private string digestValueField;

        private string uRIField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Transform", IsNullable = false)]
        public SignatureSignedInfoReferenceTransform[] Transforms
        {
            get
            {
                return this.transformsField;
            }
            set
            {
                this.transformsField = value;
            }
        }

        /// <remarks/>
        public SignatureSignedInfoReferenceDigestMethod DigestMethod
        {
            get
            {
                return this.digestMethodField;
            }
            set
            {
                this.digestMethodField = value;
            }
        }

        /// <remarks/>
        public string DigestValue
        {
            get
            {
                return this.digestValueField;
            }
            set
            {
                this.digestValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string URI
        {
            get
            {
                return this.uRIField;
            }
            set
            {
                this.uRIField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceTransform
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureSignedInfoReferenceDigestMethod
    {

        private string algorithmField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Algorithm
        {
            get
            {
                return this.algorithmField;
            }
            set
            {
                this.algorithmField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfo
    {

        private SignatureKeyInfoX509Data x509DataField;

        /// <remarks/>
        public SignatureKeyInfoX509Data X509Data
        {
            get
            {
                return this.x509DataField;
            }
            set
            {
                this.x509DataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureKeyInfoX509Data
    {

        private string x509CertificateField;

        /// <remarks/>
        public string X509Certificate
        {
            get
            {
                return this.x509CertificateField;
            }
            set
            {
                this.x509CertificateField = value;
            }
        }
    }


}
