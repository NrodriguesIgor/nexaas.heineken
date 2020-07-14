using nexaas.heineken.model.XMLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nexaas.heineken.model.Layouts
{
    public class SAFX202
    {
        public SAFX202(SAFX202Model sale, CartItem cartItem, EmpresaEstabelecimento estabelecimento)
        {
            Det nfeInfo = null;
            if (sale.document.NFe != null)
            {
                nfeInfo = sale.document.NFe.NFe.InfNFe.Det.FirstOrDefault(x => x.Prod.cProd == cartItem.sellable.code);
            }

            COD_EMPRESA = estabelecimento.COD_EMPRESA;
            COD_ESTAB = estabelecimento.COD_ESTAB;
            NUM_EQUIP = "000000000";
            NUM_CUPOM = sale.document.number.ToString().PadLeft(6, '0');
            DATA_EMISSAO = sale.activated_at.Value.ToString("yyyymmdd");
            NUM_ITEM = nfeInfo.NItem;
            IND_PRODUTO = "1";
            COD_PRODUTO = nfeInfo.Prod.cProd.RemoveDots();
            COD_SERVICO = "@";
            COD_CFO = "0000";
            COD_CONTA = "0021101026";

            QTDE = cartItem.quantity.RemoveDots().PadLeft(17, '0');
            VLR_UNIT = cartItem.sellable.sell_value.ToString().RemoveDots().PadLeft(19, '0'); ;
            VLR_ITEM = (int.Parse(cartItem.quantity.Split('.')[0]) * cartItem.sellable.sell_value).ToString().RemoveDots().PadLeft(17, '0');
            VLR_DESC = cartItem.discount.ToString().RemoveDots().PadLeft(17, '0');
            VLR_ACRES = "00000".PadLeft(17, '0');
            VLR_TOT_LIQ = "000000".PadLeft(17, '0');

            if (nfeInfo.Imposto.ICMS != null && nfeInfo.Imposto.ICMS.ICMS00 != null)
            {
                COD_SITUACAO_A = nfeInfo.Imposto.ICMS.ICMS00.orig;
                COD_SITUACAO_B = nfeInfo.Imposto.ICMS.ICMS00.CST;
                VLR_BASE_ICMS = nfeInfo.Imposto.ICMS.ICMS00.vBC.RemoveDots().PadLeft(17, '0');
                VLR_ICMS = nfeInfo.Imposto.ICMS.ICMS00.vICMS.RemoveDots().PadLeft(17, '0');
                VLR_ALIQ_ICMS = nfeInfo.Imposto.ICMS.ICMS00.pICMS.RemoveDots().PadLeft(7, '0');
            }
            else
            {
                COD_SITUACAO_A = "0";
                COD_SITUACAO_B = "00";
                VLR_BASE_ICMS = "0".RemoveDots().PadLeft(17, '0');
                VLR_ICMS = "0".RemoveDots().PadLeft(17, '0');
                VLR_ALIQ_ICMS = "0".RemoveDots().PadLeft(7, '0');
            }

            if (nfeInfo.Imposto.PIS != null && nfeInfo.Imposto.PIS.PISAliq != null)
            {
                COD_SIT_TRIB_PIS = nfeInfo.Imposto.PIS.PISAliq.CST;
                QTD_BASE_PIS = "000000000000000000";
                VLR_ALIQ_PIS_R = nfeInfo.Imposto.PIS.PISAliq.pPIS.RemoveDots();
                VLR_BASE_PIS = nfeInfo.Imposto.PIS.PISAliq.vBC.RemoveDots().PadLeft(17, '0');
                VLR_PIS = nfeInfo.Imposto.PIS.PISAliq.vPIS.RemoveDots().PadLeft(17, '0');
                VLR_ALIQ_PIS = nfeInfo.Imposto.PIS.PISAliq.pPIS.RemoveDots().PadLeft(7, '0');
            }
            else
            {
                COD_SIT_TRIB_PIS = "00";
                QTD_BASE_PIS = "000000000000000000";
                VLR_ALIQ_PIS_R = "000000000000000000";
                VLR_BASE_PIS = "0".RemoveDots().PadLeft(17, '0');
                VLR_PIS = "0".RemoveDots().PadLeft(17, '0');
                VLR_ALIQ_PIS = "0".RemoveDots().PadLeft(7, '0');
            }

            if (nfeInfo.Imposto.COFINS != null && nfeInfo.Imposto.COFINS.COFINSAliq != null)
            {
                COD_SIT_TRIB_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.CST;
                QTD_BASE_COFINS = "000000000000000000";
                VLR_ALIQ_COFINS_R = "000000000000000000";
                VLR_BASE_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.vBC.RemoveDots().PadLeft(17, '0');
                VLR_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.vCOFINS.RemoveDots().PadLeft(17, '0');
                VLR_ALIQ_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.pCOFINS.RemoveDots().PadLeft(7, '0');
            }
            else
            {
                COD_SIT_TRIB_COFINS = "00";
                QTD_BASE_COFINS = "000000000000000000";
                VLR_ALIQ_COFINS_R = "000000000000000000";
                VLR_BASE_COFINS = "0".RemoveDots().PadLeft(17, '0');
                VLR_COFINS = "0".RemoveDots().PadLeft(17, '0');
                VLR_ALIQ_COFINS = "0".RemoveDots().PadLeft(7, '0');
            }

            VLR_BASE_PIS_ST = "000000000000000000";
            VLR_PIS_ST = "000000000000000000";
            VLR_ALIQ_PIS_ST = "00000000";
            VLR_BASE_COFINS_ST = "000000000000000000";
            VLR_COFINS_ST = "000000000000000000";
            VLR_ALIQ_COFINS_ST = "00000000";
            VLR_DESP_ACS = "000000000000000000";
            COD_NAT_REC = sale.company.FirstOrDefault()?.fiscal_informations.cnae_code;
            VLR_EXC_BASE_PISCOFINS = "000000000000000000";
        }


        public string COD_EMPRESA { get; set; }
        public string COD_ESTAB { get; set; }
        public string NUM_EQUIP { get; set; }
        public string NUM_CUPOM { get; set; }
        public string DATA_EMISSAO { get; set; }
        public string NUM_ITEM { get; set; }
        public string IND_PRODUTO { get; set; }
        public string COD_PRODUTO { get; set; }
        public string COD_SERVICO { get; set; }
        public string COD_CFO { get; set; }
        public string COD_CONTA { get; set; }
        public string COD_SITUACAO_A { get; set; }
        public string COD_SITUACAO_B { get; set; }
        public string QTDE { get; set; }
        public string VLR_UNIT { get; set; }
        public string VLR_ITEM { get; set; }
        public string VLR_DESC { get; set; }
        public string VLR_ACRES { get; set; }
        public string VLR_TOT_LIQ { get; set; }
        public string VLR_BASE_ICMS { get; set; }
        public string VLR_ICMS { get; set; }
        public string VLR_ALIQ_ICMS { get; set; }
        public string COD_SIT_TRIB_PIS { get; set; }
        public string QTD_BASE_PIS { get; set; }
        public string VLR_ALIQ_PIS_R { get; set; }
        public string VLR_BASE_PIS { get; set; }
        public string VLR_PIS { get; set; }
        public string VLR_ALIQ_PIS { get; set; }
        public string COD_SIT_TRIB_COFINS { get; set; }
        public string QTD_BASE_COFINS { get; set; }
        public string VLR_ALIQ_COFINS_R { get; set; }
        public string VLR_BASE_COFINS { get; set; }
        public string VLR_COFINS { get; set; }
        public string VLR_ALIQ_COFINS { get; set; }
        public string VLR_BASE_PIS_ST { get; set; }
        public string VLR_PIS_ST { get; set; }
        public string VLR_ALIQ_PIS_ST { get; set; }
        public string VLR_BASE_COFINS_ST { get; set; }
        public string VLR_COFINS_ST { get; set; }
        public string VLR_ALIQ_COFINS_ST { get; set; }
        public string VLR_DESP_ACS { get; set; }
        public string COD_OBSERVACAO { get; set; }
        public string COD_NAT_REC { get; set; }
        public string VLR_EXC_BASE_PISCOFINS { get; set; }











    }
}
