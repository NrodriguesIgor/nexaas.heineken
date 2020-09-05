using nexaas.heineken.model.XMLModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace nexaas.heineken.model.Layouts
{
    public class SAFX202
    {
        public SAFX202() { }

        public SAFX202(SAFX202Model sale, CartItem cartItem, EmpresaEstabelecimento estabelecimento)
        {
            if (sale.document.CFe != null)
            {

                Det nfeInfo = null;
                if (sale.document.NFe != null)
                {
                    nfeInfo = sale.document.NFe.NFe.InfNFe.Det.FirstOrDefault(x => x.Prod.cProd == cartItem.sellable.code);
                }

                if (nfeInfo != null)
                {
                    COD_EMPRESA = estabelecimento.COD_EMPRESA;
                    COD_ESTAB = estabelecimento.COD_ESTAB;
                    NUM_EQUIP = "";//sale.company.FirstOrDefault().fiscal_informations.sat_association_code;
                    NUM_CUPOM = sale.document.number.ToString();
                    DATA_EMISSAO = sale.activated_at.Value.ToString("yyyymmdd");
                    NUM_ITEM = nfeInfo.NItem;
                    IND_PRODUTO = "1";
                    COD_PRODUTO = nfeInfo.Prod.cProd.RemoveDots();
                    COD_SERVICO = "@";
                    COD_CFO = nfeInfo.Prod.cFOP;
                    COD_CONTA = "21101026";

                    QTDE = cartItem.quantity.RemoveDots();
                    VLR_UNIT = cartItem.sellable.sell_value.ToString().RemoveDots();
                    VLR_ITEM = (int.Parse(cartItem.quantity.Split('.')[0]) * cartItem.sellable.sell_value).ToString().RemoveDots();
                    VLR_DESC = cartItem.discount.ToString().RemoveDots();
                    VLR_ACRES = "0";
                    VLR_TOT_LIQ = sale.document.NFe.NFe.InfNFe.Total.vNF.ToString().RemoveDots();

                    if (nfeInfo.Imposto.ICMS != null && nfeInfo.Imposto.ICMS.ICMS00 != null)
                    {
                        COD_SITUACAO_A = nfeInfo.Imposto.ICMS.ICMS00.orig;
                        COD_SITUACAO_B = nfeInfo.Imposto.ICMS.ICMS00.CST;
                        VLR_BASE_ICMS = nfeInfo.Imposto.ICMS.ICMS00.vBC.RemoveDots();
                        VLR_ICMS = nfeInfo.Imposto.ICMS.ICMS00.vICMS.RemoveDots();
                        VLR_ALIQ_ICMS = nfeInfo.Imposto.ICMS.ICMS00.pICMS.RemoveDots();
                    }
                    else
                    {
                        COD_SITUACAO_A = "";
                        COD_SITUACAO_B = "";
                        VLR_BASE_ICMS = "0";
                        VLR_ICMS = "0";
                        VLR_ALIQ_ICMS = "0";
                    }

                    if (nfeInfo.Imposto.PIS != null && nfeInfo.Imposto.PIS.PISAliq != null)
                    {
                        COD_SIT_TRIB_PIS = nfeInfo.Imposto.PIS.PISAliq.CST;
                        QTD_BASE_PIS = "0";
                        VLR_ALIQ_PIS_R = "0";
                        VLR_BASE_PIS = nfeInfo.Imposto.PIS.PISAliq.vBC.RemoveDots();
                        VLR_PIS = nfeInfo.Imposto.PIS.PISAliq.vPIS.RemoveDots();
                        VLR_ALIQ_PIS = nfeInfo.Imposto.PIS.PISAliq.pPIS.RemoveDots();
                    }
                    else
                    {
                        COD_SIT_TRIB_PIS = "0";
                        QTD_BASE_PIS = "0";
                        VLR_ALIQ_PIS_R = "0";
                        VLR_BASE_PIS = "0";
                        VLR_PIS = "0";
                        VLR_ALIQ_PIS = "0";
                    }

                    if (nfeInfo.Imposto.COFINS != null && nfeInfo.Imposto.COFINS.COFINSAliq != null)
                    {
                        COD_SIT_TRIB_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.CST;
                        QTD_BASE_COFINS = "0";
                        VLR_ALIQ_COFINS_R = "0";
                        VLR_BASE_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.vBC.RemoveDots();
                        VLR_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.vCOFINS.RemoveDots();
                        VLR_ALIQ_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.pCOFINS.RemoveDots();
                    }
                    else
                    {
                        COD_SIT_TRIB_COFINS = "0";
                        QTD_BASE_COFINS = "0";
                        VLR_ALIQ_COFINS_R = "0";
                        VLR_BASE_COFINS = "0";
                        VLR_COFINS = "0";
                        VLR_ALIQ_COFINS = "0";
                    }

                    VLR_BASE_PIS_ST = "0";
                    VLR_PIS_ST = "0";
                    VLR_ALIQ_PIS_ST = "0";
                    VLR_BASE_COFINS_ST = "0";
                    VLR_COFINS_ST = "0";
                    VLR_ALIQ_COFINS_ST = "0";
                    VLR_DESP_ACS = "0";
                    COD_NAT_REC = sale.company.FirstOrDefault().fiscal_informations.cnae_code;
                    VLR_EXC_BASE_PISCOFINS = "0";
                }
                else if (sale.document.CFe != null)
                {
                    var detProd = sale.document.CFe.infCFe.det.FirstOrDefault(x => 
                        x.prod.cProd.ToString().PadLeft(18, '0') == cartItem.sellable.code);

                    if (detProd != null)
                    {
                        COD_EMPRESA = estabelecimento.COD_EMPRESA;
                        COD_ESTAB = estabelecimento.COD_ESTAB;
                        NUM_EQUIP = "";//sale.company.FirstOrDefault().fiscal_informations.sat_association_code;
                        NUM_CUPOM = sale.document.number.ToString();
                        DATA_EMISSAO = sale.activated_at.Value.ToString("yyyyMMdd");
                        NUM_ITEM = detProd.nItem.ToString();
                        IND_PRODUTO = "1";
                        COD_PRODUTO = detProd.prod.cProd.ToString();
                        COD_SERVICO = "@";
                        COD_CFO = detProd.prod.CFOP.ToString();
                        COD_CONTA = "021101026";

                        QTDE = cartItem.quantity?.Split(".")[0].ToString();
                        VLR_UNIT = cartItem.sellable.sell_value.ToString().RemoveDots().RemoveSpecialCharacters();
                        VLR_ITEM = (int.Parse(cartItem.quantity.Split('.')[0]) * cartItem.sellable.sell_value).ToString().RemoveDots().RemoveSpecialCharacters();
                        VLR_DESC = cartItem.discount.ToString().RemoveDots().RemoveSpecialCharacters();
                        VLR_ACRES = "0";
                        VLR_TOT_LIQ = sale.document.CFe.infCFe.total.vCFe.ToString().RemoveDots().RemoveSpecialCharacters();

                        if (detProd.imposto.ICMS != null &&
                            detProd.imposto.ICMS.ICMS00 != null)
                        {
                            COD_SITUACAO_A = detProd.imposto.ICMS.ICMS00.Orig.ToString().RemoveSpecialCharacters();
                            COD_SITUACAO_B = detProd.imposto.ICMS.ICMS00.CST.ToString().RemoveSpecialCharacters();
                            VLR_BASE_ICMS = (double.Parse(VLR_ITEM) * double.Parse(QTDE)).ToString();
                            VLR_ICMS = detProd.imposto.ICMS.ICMS00.vICMS.ToString().RemoveDots().RemoveSpecialCharacters();
                            VLR_ALIQ_ICMS = detProd.imposto.ICMS.ICMS00.pICMS.ToString().RemoveDots().RemoveSpecialCharacters();
                        }
                        else if (detProd.imposto.ICMS != null &&
                            detProd.imposto.ICMS.ICMS40 != null)
                        {
                            COD_SITUACAO_A = detProd.imposto.ICMS.ICMS40.Orig.ToString().RemoveSpecialCharacters();
                            COD_SITUACAO_B = detProd.imposto.ICMS.ICMS40.CST.ToString().RemoveSpecialCharacters();
                            VLR_BASE_ICMS = "0";
                            VLR_ICMS = "0";
                            VLR_ALIQ_ICMS = "0";
                        }
                        else
                        {
                            COD_SITUACAO_A = "";
                            COD_SITUACAO_B = "";
                            VLR_BASE_ICMS = "0";
                            VLR_ICMS = "0";
                            VLR_ALIQ_ICMS = "0";
                        }

                        if (detProd.imposto.PIS != null &&
                            detProd.imposto.PIS.PISAliq != null)
                        {
                            COD_SIT_TRIB_PIS = detProd.imposto.PIS.PISAliq.CST.ToString().RemoveSpecialCharacters();
                            QTD_BASE_PIS = "0";
                            VLR_ALIQ_PIS_R = "0";
                            VLR_BASE_PIS = detProd.imposto.PIS.PISAliq.vBC.ToString().RemoveDots().RemoveSpecialCharacters();
                            VLR_PIS = detProd.imposto.PIS.PISAliq.vPIS.ToString().RemoveDots().RemoveSpecialCharacters();
                            VLR_ALIQ_PIS = detProd.imposto.PIS.PISAliq.pPIS.ToString().RemoveDots().RemoveSpecialCharacters();
                        }
                        else if (detProd.imposto.PIS != null &&
                            detProd.imposto.PIS.PISNT != null)
                        {
                            COD_SIT_TRIB_PIS = detProd.imposto.PIS.PISNT.CST.ToString().RemoveSpecialCharacters();
                            QTD_BASE_PIS = "0";
                            VLR_ALIQ_PIS_R = "0";
                            VLR_BASE_PIS = "0";
                            VLR_PIS = "0";
                            VLR_ALIQ_PIS = "0";
                        }
                        else
                        {
                            COD_SIT_TRIB_PIS = "0";
                            QTD_BASE_PIS = "0";
                            VLR_ALIQ_PIS_R = "0";
                            VLR_BASE_PIS = "0";
                            VLR_PIS = "0";
                            VLR_ALIQ_PIS = "0";
                        }

                        if (detProd.imposto.COFINS != null &&
                            detProd.imposto.COFINS.COFINSAliq != null)
                        {
                            COD_SIT_TRIB_COFINS = detProd.imposto.COFINS.COFINSAliq.CST.ToString().RemoveDots().RemoveSpecialCharacters();
                            QTD_BASE_COFINS = "0";
                            VLR_ALIQ_COFINS_R = "0";
                            VLR_BASE_COFINS = detProd.imposto.COFINS.COFINSAliq.vBC.ToString().RemoveDots().RemoveSpecialCharacters();
                            VLR_COFINS = detProd.imposto.COFINS.COFINSAliq.vCOFINS.ToString().RemoveDots().RemoveSpecialCharacters();
                            VLR_ALIQ_COFINS = detProd.imposto.COFINS.COFINSAliq.pCOFINS.ToString().RemoveDots().RemoveSpecialCharacters();
                        }
                        else if (detProd.imposto.COFINS != null &&
                            detProd.imposto.COFINS.COFINSNT != null)
                        {
                            COD_SIT_TRIB_COFINS = detProd.imposto.COFINS.COFINSNT.CST.ToString().RemoveDots().RemoveSpecialCharacters();
                            QTD_BASE_COFINS = "0";
                            VLR_ALIQ_COFINS_R = "0";
                            VLR_BASE_COFINS = "0";
                            VLR_COFINS = "0";
                            VLR_ALIQ_COFINS = "0";
                        }
                        else
                        {
                            COD_SIT_TRIB_COFINS = "0";
                            QTD_BASE_COFINS = "0";
                            VLR_ALIQ_COFINS_R = "0";
                            VLR_BASE_COFINS = "0";
                            VLR_COFINS = "0";
                            VLR_ALIQ_COFINS = "0";
                        }

                        VLR_BASE_PIS_ST = "0";
                        VLR_PIS_ST = "0";
                        VLR_ALIQ_PIS_ST = "0";
                        VLR_BASE_COFINS_ST = "0";
                        VLR_COFINS_ST = "0";
                        VLR_ALIQ_COFINS_ST = "0";
                        VLR_DESP_ACS = "0";
                        COD_NAT_REC = "0";//sale.company.FirstOrDefault().fiscal_informations.cnae_code;
                        VLR_EXC_BASE_PISCOFINS = "0";
                    }
                }
            }

            if (sale.document.status.Equals("cancelled"))
            {
                COD_SIT_TRIB_PIS = "49";
                COD_SIT_TRIB_COFINS = "49";
            }
        }


        public IList<SAFX202> DataGen(SAFX202Model sale, CartItem cartItem, EmpresaEstabelecimento estabelecimento)
        {
            IList<SAFX202> result = new List<SAFX202>();

            if (sale.document.CFe != null)
            {
                IList<Det> nfeInfolist = sale.document.NFe?.NFe?.InfNFe?.Det;

                if (nfeInfolist != null && nfeInfolist.Any())
                {
                    foreach (Det nfeInfo in nfeInfolist)
                    {
                        if (nfeInfo.Prod.cProd == cartItem.sellable.code)
                        {
                            SAFX202 model = new SAFX202
                            {
                                COD_EMPRESA = estabelecimento.COD_EMPRESA,
                                COD_ESTAB = estabelecimento.COD_ESTAB,
                                NUM_EQUIP = "",//sale.company.FirstOrDefault().fiscal_informations.sat_association_code;
                                NUM_CUPOM = sale.document.number.ToString(),
                                DATA_EMISSAO = sale.activated_at.Value.ToString("yyyymmdd"),
                                NUM_ITEM = nfeInfo.NItem,
                                IND_PRODUTO = "1",
                                COD_PRODUTO = nfeInfo.Prod.cProd.RemoveDots(),
                                COD_SERVICO = "@",
                                COD_CFO = nfeInfo.Prod.cFOP,
                                COD_CONTA = "21101026",

                                QTDE = cartItem.quantity.RemoveDots(),
                                VLR_UNIT = cartItem.sellable.sell_value.ToString().RemoveDots(),
                                VLR_ITEM = (int.Parse(cartItem.quantity.Split('.')[0]) * cartItem.sellable.sell_value).ToString().RemoveDots(),
                                VLR_DESC = cartItem.discount.ToString().RemoveDots(),
                                VLR_ACRES = "0",
                                VLR_TOT_LIQ = sale.document.NFe.NFe.InfNFe.Total.vNF.ToString().RemoveDots()
                            };

                            if (nfeInfo.Imposto.ICMS != null && nfeInfo.Imposto.ICMS.ICMS00 != null)
                            {
                                model.COD_SITUACAO_A = nfeInfo.Imposto.ICMS.ICMS00.orig;
                                model.COD_SITUACAO_B = nfeInfo.Imposto.ICMS.ICMS00.CST;
                                model.VLR_BASE_ICMS = nfeInfo.Imposto.ICMS.ICMS00.vBC.RemoveDots();
                                model.VLR_ICMS = nfeInfo.Imposto.ICMS.ICMS00.vICMS.RemoveDots();
                                model.VLR_ALIQ_ICMS = nfeInfo.Imposto.ICMS.ICMS00.pICMS.RemoveDots();
                            }
                            else
                            {
                                model.COD_SITUACAO_A = "";
                                model.COD_SITUACAO_B = "";
                                model.VLR_BASE_ICMS = "0";
                                model.VLR_ICMS = "0";
                                model.VLR_ALIQ_ICMS = "0";
                            }

                            if (nfeInfo.Imposto.PIS != null && nfeInfo.Imposto.PIS.PISAliq != null)
                            {
                                model.COD_SIT_TRIB_PIS = nfeInfo.Imposto.PIS.PISAliq.CST;
                                model.QTD_BASE_PIS = "0";
                                model.VLR_ALIQ_PIS_R = "0";
                                model.VLR_BASE_PIS = nfeInfo.Imposto.PIS.PISAliq.vBC.RemoveDots();
                                model.VLR_PIS = nfeInfo.Imposto.PIS.PISAliq.vPIS.RemoveDots();
                                model.VLR_ALIQ_PIS = nfeInfo.Imposto.PIS.PISAliq.pPIS.RemoveDots();
                            }
                            else
                            {
                                model.COD_SIT_TRIB_PIS = "0";
                                model.QTD_BASE_PIS = "0";
                                model.VLR_ALIQ_PIS_R = "0";
                                model.VLR_BASE_PIS = "0";
                                model.VLR_PIS = "0";
                                model.VLR_ALIQ_PIS = "0";
                            }

                            if (nfeInfo.Imposto.COFINS != null && nfeInfo.Imposto.COFINS.COFINSAliq != null)
                            {
                                model.COD_SIT_TRIB_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.CST;
                                model.QTD_BASE_COFINS = "0";
                                model.VLR_ALIQ_COFINS_R = "0";
                                model.VLR_BASE_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.vBC.RemoveDots();
                                model.VLR_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.vCOFINS.RemoveDots();
                                model.VLR_ALIQ_COFINS = nfeInfo.Imposto.COFINS.COFINSAliq.pCOFINS.RemoveDots();
                            }
                            else
                            {
                                model.COD_SIT_TRIB_COFINS = "0";
                                model.QTD_BASE_COFINS = "0";
                                model.VLR_ALIQ_COFINS_R = "0";
                                model.VLR_BASE_COFINS = "0";
                                model.VLR_COFINS = "0";
                                model.VLR_ALIQ_COFINS = "0";
                            }

                            model.VLR_BASE_PIS_ST = "0";
                            model.VLR_PIS_ST = "0";
                            model.VLR_ALIQ_PIS_ST = "0";
                            model.VLR_BASE_COFINS_ST = "0";
                            model.VLR_COFINS_ST = "0";
                            model.VLR_ALIQ_COFINS_ST = "0";
                            model.VLR_DESP_ACS = "0";
                            model.COD_NAT_REC = sale.company.FirstOrDefault().fiscal_informations.cnae_code;
                            model.VLR_EXC_BASE_PISCOFINS = "0";

                            if (sale.document.status.Equals("cancelled"))
                            {
                                model.COD_SIT_TRIB_PIS = "49";
                                model.COD_SIT_TRIB_COFINS = "49";
                            }

                            result.Add(model);
                        }
                    }
                }
                else
                {
                    IList<CFeModels.det> detProdList = sale.document.CFe?.infCFe?.det;
                    var ide = sale.document.CFe?.infCFe?.ide;

                    if (detProdList != null && detProdList.Any())
                    {
                        foreach (CFeModels.det detProd in detProdList)
                        {
                            var prod = detProd.prod.cProd.ToString().PadLeft(18, '0');
                            if (prod == cartItem.sellable.code)
                            {
                                SAFX202 model = new SAFX202
                                {
                                    COD_EMPRESA = estabelecimento.COD_EMPRESA,
                                    COD_ESTAB = estabelecimento.COD_ESTAB,
                                    NUM_EQUIP = ide?.nserieSAT.ToString(),
                                    NUM_CUPOM = sale.document.number.ToString(),
                                    DATA_EMISSAO = sale.activated_at.Value.ToString("yyyyMMdd"),
                                    NUM_ITEM = detProd.nItem.ToString(),
                                    IND_PRODUTO = "5",
                                    COD_PRODUTO = detProd.prod.cProd.TrimStart('0'),
                                    COD_SERVICO = "@",
                                    COD_CFO = detProd.prod.CFOP.ToString(),
                                    COD_CONTA = "021101026",

                                    QTDE = cartItem.quantity?.Split(".")[0].ToString(),
                                    VLR_UNIT = cartItem.sellable.sell_value.ToString().RemoveDots().RemoveSpecialCharacters(),
                                    VLR_ITEM = (int.Parse(cartItem.quantity.Split('.')[0]) * cartItem.sellable.sell_value).ToString().RemoveDots().RemoveSpecialCharacters(),
                                    VLR_DESC = cartItem.discount.ToString().RemoveDots().RemoveSpecialCharacters(),
                                    VLR_ACRES = "0",
                                    //VLR_TOT_LIQ = sale.document.CFe.infCFe.total.vCFe.ToString().RemoveDots().RemoveSpecialCharacters()
                                };

                                model.VLR_TOT_LIQ = model.VLR_ITEM;

                                if (detProd.imposto.ICMS != null &&
                                    detProd.imposto.ICMS.ICMS00 != null)
                                {
                                    model.COD_SITUACAO_A = detProd.imposto.ICMS.ICMS00.Orig.ToString().RemoveSpecialCharacters();
                                    model.COD_SITUACAO_B = detProd.imposto.ICMS.ICMS00.CST.ToString().RemoveSpecialCharacters();
                                    model.VLR_BASE_ICMS = (double.Parse(model.VLR_UNIT) * double.Parse(model.QTDE)).ToString();
                                    model.VLR_ICMS = detProd.imposto.ICMS.ICMS00.vICMS.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.VLR_ALIQ_ICMS = detProd.imposto.ICMS.ICMS00.pICMS.ToString().RemoveDots().RemoveSpecialCharacters();
                                }
                                else if (detProd.imposto.ICMS != null &&
                                    detProd.imposto.ICMS.ICMS40 != null)
                                {
                                    model.COD_SITUACAO_A = detProd.imposto.ICMS.ICMS40.Orig.ToString().RemoveSpecialCharacters();
                                    model.COD_SITUACAO_B = detProd.imposto.ICMS.ICMS40.CST.ToString().RemoveSpecialCharacters();
                                    model.VLR_BASE_ICMS = "0";
                                    model.VLR_ICMS = "0";
                                    model.VLR_ALIQ_ICMS = "0";
                                }
                                else
                                {
                                    model.COD_SITUACAO_A = "";
                                    model.COD_SITUACAO_B = "";
                                    model.VLR_BASE_ICMS = "0";
                                    model.VLR_ICMS = "0";
                                    model.VLR_ALIQ_ICMS = "0";
                                }

                                if (detProd.imposto.PIS != null &&
                                    detProd.imposto.PIS.PISAliq != null)
                                {
                                    model.COD_SIT_TRIB_PIS = detProd.imposto.PIS.PISAliq.CST.ToString().RemoveSpecialCharacters();
                                    model.QTD_BASE_PIS = "0";
                                    model.VLR_ALIQ_PIS_R = "0";
                                    model.VLR_BASE_PIS = detProd.imposto.PIS.PISAliq.vBC.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.VLR_PIS = detProd.imposto.PIS.PISAliq.vPIS.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.VLR_ALIQ_PIS = detProd.imposto.PIS.PISAliq.pPIS.ToString().RemoveDots().RemoveSpecialCharacters();
                                }
                                else if (detProd.imposto.PIS != null &&
                                    detProd.imposto.PIS.PISNT != null)
                                {
                                    model.COD_SIT_TRIB_PIS = detProd.imposto.PIS.PISNT.CST.ToString().RemoveSpecialCharacters();
                                    model.QTD_BASE_PIS = "0";
                                    model.VLR_ALIQ_PIS_R = "0";
                                    model.VLR_BASE_PIS = (double.Parse(model.VLR_UNIT) * double.Parse(model.QTDE)).ToString();
                                    model.VLR_PIS = "0";
                                    model.VLR_ALIQ_PIS = "0";
                                }
                                else
                                {
                                    model.COD_SIT_TRIB_PIS = "0";
                                    model.QTD_BASE_PIS = "0";
                                    model.VLR_ALIQ_PIS_R = "0";
                                    model.VLR_BASE_PIS = "0";
                                    model.VLR_PIS = "0";
                                    model.VLR_ALIQ_PIS = "0";
                                }

                                if (detProd.imposto.COFINS != null &&
                                    detProd.imposto.COFINS.COFINSAliq != null)
                                {
                                    model.COD_SIT_TRIB_COFINS = detProd.imposto.COFINS.COFINSAliq.CST.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.QTD_BASE_COFINS = "0";
                                    model.VLR_ALIQ_COFINS_R = "0";
                                    model.VLR_BASE_COFINS = detProd.imposto.COFINS.COFINSAliq.vBC.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.VLR_COFINS = detProd.imposto.COFINS.COFINSAliq.vCOFINS.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.VLR_ALIQ_COFINS = detProd.imposto.COFINS.COFINSAliq.pCOFINS.ToString().RemoveDots().RemoveSpecialCharacters();
                                }
                                else if (detProd.imposto.COFINS != null &&
                                    detProd.imposto.COFINS.COFINSNT != null)
                                {
                                    model.COD_SIT_TRIB_COFINS = detProd.imposto.COFINS.COFINSNT.CST.ToString().RemoveDots().RemoveSpecialCharacters();
                                    model.QTD_BASE_COFINS = "0";
                                    model.VLR_ALIQ_COFINS_R = "0";
                                    model.VLR_BASE_COFINS = (double.Parse(model.VLR_UNIT) * double.Parse(model.QTDE)).ToString();
                                    model.VLR_COFINS = "0";
                                    model.VLR_ALIQ_COFINS = "0";
                                }
                                else
                                {
                                    model.COD_SIT_TRIB_COFINS = "0";
                                    model.QTD_BASE_COFINS = "0";
                                    model.VLR_ALIQ_COFINS_R = "0";
                                    model.VLR_BASE_COFINS = "0";
                                    model.VLR_COFINS = "0";
                                    model.VLR_ALIQ_COFINS = "0";
                                }

                                model.VLR_BASE_PIS_ST = "0";
                                model.VLR_PIS_ST = "0";
                                model.VLR_ALIQ_PIS_ST = "0";
                                model.VLR_BASE_COFINS_ST = "0";
                                model.VLR_COFINS_ST = "0";
                                model.VLR_ALIQ_COFINS_ST = "0";
                                model.VLR_DESP_ACS = "0";
                                model.COD_NAT_REC = " ";//sale.company.FirstOrDefault().fiscal_informations.cnae_code;
                                model.VLR_EXC_BASE_PISCOFINS = "0";

                                if (sale.document.status.Equals("cancelled"))
                                {
                                    model.COD_SIT_TRIB_PIS = "49";
                                    model.COD_SIT_TRIB_COFINS = "49";

                                    model.VLR_BASE_ICMS = "0";
                                    model.VLR_ICMS = "0";
                                    model.VLR_ALIQ_ICMS = "0";

                                    model.VLR_ALIQ_PIS_R = "0";
                                    model.VLR_BASE_PIS = "0";
                                    model.VLR_PIS = "0";
                                    model.VLR_ALIQ_PIS = "0";


                                    model.QTD_BASE_COFINS = "0";
                                    model.VLR_ALIQ_COFINS_R = "0";
                                    model.VLR_BASE_COFINS = "0";
                                    model.VLR_COFINS = "0";
                                    model.VLR_ALIQ_COFINS = "0";
                                }

                                result.Add(model);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public string COD_EMPRESA { get; set; } = "";
        public string COD_ESTAB { get; set; } = "";
        public string NUM_EQUIP { get; set; } = "";
        public string NUM_CUPOM { get; set; } = "";
        public string DATA_EMISSAO { get; set; } = "";
        public string NUM_ITEM { get; set; } = "";
        public string IND_PRODUTO { get; set; } = "";
        public string COD_PRODUTO { get; set; } = "";
        public string COD_SERVICO { get; set; } = "@";
        public string COD_CFO { get; set; } = "";
        public string COD_CONTA { get; set; } = "";
        public string COD_SITUACAO_A { get; set; } = "";
        public string COD_SITUACAO_B { get; set; } = "";
        public string QTDE { get; set; } = "";
        public string VLR_UNIT { get; set; } = "0";
        public string VLR_ITEM { get; set; } = "0";
        public string VLR_DESC { get; set; } = "0";
        public string VLR_ACRES { get; set; } = "0";
        public string VLR_TOT_LIQ { get; set; } = "0";
        public string VLR_BASE_ICMS { get; set; } = "0";
        public string VLR_ICMS { get; set; } = "0";
        public string VLR_ALIQ_ICMS { get; set; } = "0";
        public string COD_SIT_TRIB_PIS { get; set; } = "";
        public string QTD_BASE_PIS { get; set; } = "";
        public string VLR_ALIQ_PIS_R { get; set; } = "0";
        public string VLR_BASE_PIS { get; set; } = "0";
        public string VLR_PIS { get; set; } = "0";
        public string VLR_ALIQ_PIS { get; set; } = "0";
        public string COD_SIT_TRIB_COFINS { get; set; } = "";
        public string QTD_BASE_COFINS { get; set; } = "";
        public string VLR_ALIQ_COFINS_R { get; set; } = "0";
        public string VLR_BASE_COFINS { get; set; } = "0";
        public string VLR_COFINS { get; set; } = "0";
        public string VLR_ALIQ_COFINS { get; set; } = "0";
        public string VLR_BASE_PIS_ST { get; set; } = "0";
        public string VLR_PIS_ST { get; set; } = "0";
        public string VLR_ALIQ_PIS_ST { get; set; } = "0";
        public string VLR_BASE_COFINS_ST { get; set; } = "0";
        public string VLR_COFINS_ST { get; set; } = "0";
        public string VLR_ALIQ_COFINS_ST { get; set; } = "0";
        public string VLR_DESP_ACS { get; set; } = "0";
        public string COD_OBSERVACAO { get; set; } = "";
        public string COD_NAT_REC { get; set; } = "";
        public string VLR_EXC_BASE_PISCOFINS { get; set; } = "0";
    }


    public class SAFX202Csv
    {
        public SAFX202Csv() { }

        public SAFX202Csv(SAFX202Model sale, CartItem cartItem, EmpresaEstabelecimento estabelecimento)
        {
            Det nfeInfo = null;
            if (sale.document.NFe != null)
            {
                nfeInfo = sale.document.NFe.NFe.InfNFe.Det.FirstOrDefault(x => x.Prod.cProd == cartItem.sellable.code);
            }

            if (nfeInfo != null)
            {
                if (sale != null)
                {
                    if (sale.document != null)
                    {
                        var documento = sale.document.NFe;
                        
                        if (documento != null)
                        {
                            var nota = documento.NFe;
                            var ProtNota = documento.ProtNFe;

                            if (nota != null || ProtNota != null)
                            {
                                var infoNota = nota.InfNFe;

                                if (infoNota != null)
                                {
                                    var emitente = infoNota.Emit;

                                    COD_EMPRESA = estabelecimento.COD_EMPRESA;
                                    CNPJEmissor = emitente.CNPJ;
                                    Empresa = emitente.XNome;
                                    Status = sale.document.status; // Traduzir
                                    Modelo = nota.InfNFe.Ide.mod;
                                    NumeroEquipamentoSAT = "";
                                    Numero = ""; // Não sei o que é
                                    Serie = infoNota.Ide.serie;
                                    NumeroNFSe = infoNota.Ide.nNF;
                                    ChaveAcesso = ProtNota.InfProt.ChNFe;
                                    Protocolo = ProtNota.InfProt.NProt;
                                    DataEmissao = nota.InfNFe.Ide.dhEmi;

                                    CPFCNPJDestinatario = "";
                                    Destinatario = "";
                                    MunicipioPrestador = "";

                                    NaturezaOperacao = nota.InfNFe.Ide.natOp;
                                    RetornoOrgaoAutorizador = ProtNota.InfProt.XMotivo;

                                    ValorDocumento = infoNota.Total.ICMSTot.vNF;

                                    CFOP = "";
                                    DESCRICAOCFOP = "";

                                    CodigoProduto = nfeInfo.Prod.cProd;
                                    DescrcaoProduto = nfeInfo.Prod.xProd;
                                    NCM = nfeInfo.Prod.nCM;
                                    UNIDADEMEDIDA = "0";

                                    ValorUnitarioProduto = nfeInfo.Prod.vUnCom;
                                    DescontoProduto = cartItem.discount;

                                    ValorProdutoDepoisDesconto = (double.Parse(ValorUnitarioProduto) - DescontoProduto).ToString();
                                    Quantidade = nfeInfo.Prod.qTrib;
                                    VrTotalProduto = nfeInfo.Prod.vProd;

                                    BCICMS = nfeInfo.Imposto?.ICMS?.ICMS00?.vBC;
                                    ValorICMS = nfeInfo.Imposto?.ICMS?.ICMS00?.vICMS;

                                    INSS = "0";
                                    IRRF = "0";
                                    CSLL = "0";

                                    CstCofins = nfeInfo.Imposto?.COFINS?.COFINSAliq?.CST;

                                    QuantidadeBaseCalculoCOFINSPauta = "0";
                                    AliquotaCOFINSReaisPauta = "0";

                                    ValorBaseCOFINSAliquota = nfeInfo.Imposto?.COFINS?.COFINSAliq?.vBC;
                                    AliqCofins = nfeInfo.Imposto?.COFINS?.COFINSAliq?.pCOFINS;
                                    COFINS = nfeInfo.Imposto?.COFINS?.COFINSAliq?.vCOFINS;

                                    CstPis = "0";
                                    QuantidadeBaseCalculoPISPauta = "0";
                                    AliquotaPISReaisPauta = "0";
                                    ValorBasePISAliquota = "0";
                                    AliqPis = "0";
                                    PISPASEP = "0";
                                    CONTACONTABIL = "0";
                                    ISSNormal = "0";
                                    ISSRetido = "0";

                                    var pagamento = sale.payments.FirstOrDefault();
                                    if (pagamento != null)
                                        FormaPagamento = pagamento.type;
                                }
                            }
                        }
                    }
                }
            }
            else if (sale.document.CFe != null)
            {
                if (sale != null)
                {
                    if (sale.document != null)
                    {
                        var documento = sale.document;

                        if (documento != null)
                        {
                            var nota = documento.CFe;
                            if (nota != null)
                            {
                                var infoNota = nota.infCFe;
                                var prodItem = nota.infCFe.det.FirstOrDefault(x => x.prod.cProd.ToString().PadLeft(18, '0') == cartItem.sellable.code);

                                if (infoNota != null)
                                {
                                    var emitente = infoNota.emit;

                                    COD_EMPRESA = estabelecimento.COD_EMPRESA;
                                    CNPJEmissor = emitente.CNPJ.ToString();
                                    Empresa = emitente.xNome;
                                    Status = sale.document.status; // Traduzir
                                    Modelo = infoNota.ide.mod.ToString();
                                    NumeroEquipamentoSAT = "";
                                    Numero = ""; // Não sei o que é
                                    Serie = infoNota.ide.nserieSAT.ToString();
                                    NumeroNFSe = infoNota.ide.nCFe.ToString();
                                    ChaveAcesso = nota.infCFe.Id;
                                    Protocolo = "";


                                    string ano = nota.infCFe.ide.dEmi.ToString().Substring(0, 4);
                                    string mes = nota.infCFe.ide.dEmi.ToString().Substring(ano.Length, 2);
                                    string dia = nota.infCFe.ide.dEmi.ToString().Substring((ano.Length + mes.Length), 2);

                                    DataEmissao = DateTime.Parse($"{ano}-{mes}-{dia}");


                                    CPFCNPJDestinatario = "";
                                    Destinatario = "";
                                    MunicipioPrestador = "";

                                    NaturezaOperacao = "";
                                    RetornoOrgaoAutorizador = "";

                                    ValorDocumento = nota.infCFe.total.vCFe.ToString().RemoveSpecialCharacters();

                                    CFOP = "";
                                    DESCRICAOCFOP = "";

                                    CodigoProduto = prodItem.prod.cProd.ToString().RemoveSpecialCharacters();
                                    DescrcaoProduto = prodItem.prod.xProd;
                                    NCM = prodItem.prod.NCM.ToString().RemoveSpecialCharacters();
                                    UNIDADEMEDIDA = "0";

                                    ValorUnitarioProduto = prodItem.prod.vUnCom.ToString().RemoveSpecialCharacters();
                                    DescontoProduto = cartItem.discount;

                                    ValorProdutoDepoisDesconto = (double.Parse(ValorUnitarioProduto) - DescontoProduto).ToString().RemoveSpecialCharacters();
                                    Quantidade = "";
                                    VrTotalProduto = prodItem.prod.vProd.ToString().RemoveSpecialCharacters();

                                    BCICMS = "";
                                    ValorICMS = prodItem.imposto?.ICMS?.ICMS00?.vICMS.ToString().RemoveSpecialCharacters();

                                    INSS = "0";
                                    IRRF = "0";
                                    CSLL = "0";

                                    CstCofins = prodItem.imposto?.COFINS?.COFINSAliq?.CST.ToString().RemoveSpecialCharacters();

                                    QuantidadeBaseCalculoCOFINSPauta = "0";
                                    AliquotaCOFINSReaisPauta = "0";

                                    ValorBaseCOFINSAliquota = prodItem.imposto?.COFINS?.COFINSAliq?.vBC.ToString().RemoveSpecialCharacters();
                                    AliqCofins = prodItem.imposto?.COFINS?.COFINSAliq?.pCOFINS.ToString().RemoveSpecialCharacters();
                                    COFINS = prodItem.imposto?.COFINS?.COFINSAliq?.vCOFINS.ToString().RemoveSpecialCharacters();

                                    CstPis = "0";
                                    QuantidadeBaseCalculoPISPauta = "0";
                                    AliquotaPISReaisPauta = "0";
                                    ValorBasePISAliquota = "0";
                                    AliqPis = "0";
                                    PISPASEP = "0";
                                    CONTACONTABIL = "0";
                                    ISSNormal = "0";
                                    ISSRetido = "0";

                                    var pagamento = sale.payments.FirstOrDefault();
                                    if (pagamento != null)
                                        FormaPagamento = pagamento.type;
                                }
                            }
                        }
                    }
                }
            }
        }


        public IList<SAFX202Csv> DataGen(SAFX202Model sale, CartItem cartItem, EmpresaEstabelecimento estabelecimento)
        {
            IList<SAFX202Csv> result = new List<SAFX202Csv>();

            if (sale.document.CFe != null)
            {
                IList<Det> nfeInfolist = sale.document.NFe?.NFe?.InfNFe?.Det;

                if (nfeInfolist != null && nfeInfolist.Any())
                {
                    var emitente = sale.document.NFe?.NFe?.InfNFe.Emit;
                    var ide = sale.document.NFe?.NFe?.InfNFe.Ide;
                    var info = sale.document.NFe?.NFe?.InfNFe;

                    foreach (Det nfeInfo in nfeInfolist)
                    {
                        if (nfeInfo.Prod.cProd == cartItem.sellable.code)
                        {
                            SAFX202Csv model = new SAFX202Csv();

                            COD_EMPRESA = estabelecimento.COD_EMPRESA;
                            CNPJEmissor = emitente.CNPJ;
                            Empresa = emitente.XNome;
                            Status = sale.document.status; // Traduzir
                            Modelo = ide.mod;
                            NumeroEquipamentoSAT = "";
                            Numero = sale.document.number.ToString();
                            Serie = ide.serie;
                            NumeroNFSe = ide.nNF;
                            ChaveAcesso = sale.document.NFe.ProtNFe.InfProt.ChNFe;
                            Protocolo = sale.document.NFe.ProtNFe.InfProt.NProt;
                            DataEmissao = ide.dhEmi;

                            CPFCNPJDestinatario = "";
                            Destinatario = "";
                            MunicipioPrestador = "";

                            NaturezaOperacao = ide.natOp;
                            RetornoOrgaoAutorizador = sale.document.NFe.ProtNFe.InfProt.XMotivo;

                            ValorDocumento = sale.document.NFe.NFe.InfNFe.Total.ICMSTot.vNF;

                            CFOP = "";
                            DESCRICAOCFOP = "";

                            CodigoProduto = nfeInfo.Prod.cProd;
                            DescrcaoProduto = nfeInfo.Prod.xProd;
                            NCM = nfeInfo.Prod.nCM;
                            UNIDADEMEDIDA = "0";

                            ValorUnitarioProduto = nfeInfo.Prod.vUnCom;
                            DescontoProduto = cartItem.discount;

                            ValorProdutoDepoisDesconto = (double.Parse(ValorUnitarioProduto) - DescontoProduto).ToString();
                            Quantidade = nfeInfo.Prod.qTrib;
                            VrTotalProduto = nfeInfo.Prod.vProd;

                            BCICMS = nfeInfo.Imposto?.ICMS?.ICMS00?.vBC;
                            ValorICMS = nfeInfo.Imposto?.ICMS?.ICMS00?.vICMS;

                            INSS = "0";
                            IRRF = "0";
                            CSLL = "0";

                            CstCofins = nfeInfo.Imposto?.COFINS?.COFINSAliq?.CST;

                            QuantidadeBaseCalculoCOFINSPauta = "0";
                            AliquotaCOFINSReaisPauta = "0";

                            ValorBaseCOFINSAliquota = nfeInfo.Imposto?.COFINS?.COFINSAliq?.vBC;
                            AliqCofins = nfeInfo.Imposto?.COFINS?.COFINSAliq?.pCOFINS;
                            COFINS = nfeInfo.Imposto?.COFINS?.COFINSAliq?.vCOFINS;

                            CstPis = "0";
                            QuantidadeBaseCalculoPISPauta = "0";
                            AliquotaPISReaisPauta = "0";
                            ValorBasePISAliquota = "0";
                            AliqPis = "0";
                            PISPASEP = "0";
                            CONTACONTABIL = "0";
                            ISSNormal = "0";
                            ISSRetido = "0";

                            var pagamento = sale.payments.FirstOrDefault();
                            if (pagamento != null)
                                FormaPagamento = pagamento.type;

                            result.Add(model);
                        }
                    }
                }
                else
                {
                    IList<CFeModels.det> detProdList = sale.document.CFe?.infCFe?.det;

                    if (detProdList != null && detProdList.Any())
                    {
                        var emitente = sale.document.CFe?.infCFe.emit;
                        var ide = sale.document.CFe?.infCFe.ide;
                        var info = sale.document.CFe?.infCFe;

                        foreach (CFeModels.det detProd in detProdList)
                        {
                            var prod = detProd.prod.cProd.ToString().PadLeft(18, '0');
                            if (prod == cartItem.sellable.code)
                            {
                                SAFX202Csv model = new SAFX202Csv
                                {
                                    COD_EMPRESA = estabelecimento.COD_EMPRESA,
                                    CNPJEmissor = emitente.CNPJ.ToString(),
                                    Empresa = emitente.xNome,
                                    Status = sale.document.status,
                                    Modelo = ide.mod.ToString(),
                                    NumeroEquipamentoSAT = ide.nserieSAT.ToString(),
                                    Numero = ide.nCFe.ToString(),
                                    Serie = "",
                                    NumeroNFSe = "",
                                    ChaveAcesso = sale.document.CFe?.infCFe.Id,
                                    Protocolo = "",
                                    DataEmissao = sale.activated_at.Value
                                };

                                if (model.ChaveAcesso.Contains("CFe"))
                                {
                                    if (model.ChaveAcesso.Length > 3)
                                        model.ChaveAcesso = "'" + model.ChaveAcesso.Remove(0, 3);
                                }

                                model.CPFCNPJDestinatario = "";
                                model.Destinatario = "";
                                model.MunicipioPrestador = "";
                                model.NaturezaOperacao = "";
                                model.RetornoOrgaoAutorizador = "";
                                model.ValorDocumento = sale.document.CFe.infCFe.total.vCFe.Replace('.', ',');
                                model.CFOP = detProd.prod.CFOP.ToString();
                                model.DESCRICAOCFOP = "";
                                model.CodigoProduto = detProd.prod.cProd.TrimStart('0');
                                model.DescrcaoProduto = detProd.prod.xProd;
                                model.NCM = detProd.prod.NCM.ToString().RemoveSpecialCharacters();
                                model.UNIDADEMEDIDA = "0";
                                model.ValorUnitarioProduto = detProd.prod.vUnCom.Replace('.', ',');
                                model.DescontoProduto = cartItem.discount;

                                decimal vl = decimal.Parse(model.ValorUnitarioProduto.Replace('.', ','));
                                decimal desconto = vl - model.DescontoProduto;
                                model.ValorProdutoDepoisDesconto = desconto.ToString("F");
                                model.Quantidade = cartItem.quantity?.Split(".")[0].ToString();
                                model.VrTotalProduto = detProd.prod.vProd.Replace('.', ',');

                                if (detProd.imposto.ICMS != null &&
                                    detProd.imposto.ICMS.ICMS00 != null)
                                {
                                    model.ValorICMS = detProd.imposto.ICMS.ICMS00.vICMS.Replace('.', ',');
                                    model.ValorALIQICMS = detProd.imposto.ICMS.ICMS00.pICMS.Split(".")[0];
                                    model.BCICMS = (decimal.Parse(model.ValorUnitarioProduto.Replace('.', ',')) * decimal.Parse(model.Quantidade)).ToString();
                                }
                                else if (detProd.imposto.ICMS != null &&
                                    detProd.imposto.ICMS.ICMS40 != null)
                                {
                                    model.ValorICMS = "0";
                                    model.ValorALIQICMS = "0";
                                    model.BCICMS = "0";
                                }
                                else
                                {
                                    model.BCICMS = "0";
                                    model.ValorICMS = "0";
                                    model.ValorALIQICMS = "0";
                                }

                                model.INSS = "0";
                                model.IRRF = "0";
                                model.CSLL = "0";

                                if (detProd.imposto.COFINS != null &&
                                    detProd.imposto.COFINS.COFINSAliq != null)
                                {
                                    model.CstCofins = detProd.imposto?.COFINS?.COFINSAliq?.CST.Replace('.', ',');
                                    model.ValorBaseCOFINSAliquota = detProd.imposto?.COFINS?.COFINSAliq?.vBC.Replace('.', ',');

                                    decimal al = decimal.Parse(detProd.imposto?.COFINS?.COFINSAliq?.pCOFINS.Replace('.', ','));
                                    model.AliqCofins = (al * 100).ToString();
                                    model.COFINS = detProd.imposto?.COFINS?.COFINSAliq?.vCOFINS.Replace('.', ',');
                                }
                                else if (detProd.imposto.COFINS != null &&
                                    detProd.imposto.COFINS.COFINSNT != null)
                                {
                                    model.CstCofins = detProd.imposto?.COFINS?.COFINSNT?.CST.Replace('.', ',');
                                    model.ValorBaseCOFINSAliquota = (decimal.Parse(model.ValorUnitarioProduto.Replace('.', ',')) * decimal.Parse(model.Quantidade)).ToString();
                                    model.AliqCofins = "0";
                                    model.COFINS = "0";
                                }
                                else
                                {
                                    model.CstCofins = "0";
                                    model.ValorBaseCOFINSAliquota = "0";
                                    model.AliqCofins = "0";
                                    model.COFINS = "0";
                                }

                                model.QuantidadeBaseCalculoCOFINSPauta = "0";
                                model.AliquotaCOFINSReaisPauta = "0";

                                if (detProd.imposto.PIS != null &&
                                    detProd.imposto.PIS.PISAliq != null)
                                {
                                    model.CstPis = detProd.imposto.PIS.PISAliq.CST.Replace('.', ',');

                                    model.QuantidadeBaseCalculoPISPauta = "0";
                                    model.AliquotaPISReaisPauta = "0";
                                    model.ValorBasePISAliquota = detProd.imposto.PIS.PISAliq.vBC.Replace('.', ',');

                                    model.AliqPis = (decimal.Parse(detProd.imposto.PIS.PISAliq.pPIS.Replace('.', ',')) * 100).ToString();
                                    model.PISPASEP = detProd.imposto.PIS.PISAliq.vPIS.Replace('.', ',');
                                }
                                else if (detProd.imposto.PIS != null &&
                                    detProd.imposto.PIS.PISNT != null)
                                {
                                    model.CstPis = detProd.imposto.PIS.PISNT.CST.Replace('.', ',');
                                    model.QuantidadeBaseCalculoPISPauta = "0";
                                    model.AliquotaPISReaisPauta = "0";
                                    model.ValorBasePISAliquota = (decimal.Parse(model.ValorUnitarioProduto.Replace('.', ',')) * decimal.Parse(model.Quantidade)).ToString();
                                    model.AliqPis = "0";
                                    model.PISPASEP = "0";
                                }
                                else
                                {
                                    model.CstPis = "0";
                                    model.QuantidadeBaseCalculoPISPauta = "0";
                                    model.AliquotaPISReaisPauta = "0";
                                    model.ValorBasePISAliquota = "0";
                                    model.AliqPis = "0";
                                    model.PISPASEP = "0";
                                }

                                model.CONTACONTABIL = "0";
                                model.ISSNormal = "0";
                                model.ISSRetido = "0";

                                if (sale.document.status.Equals("cancelled"))
                                {
                                    //model.CstPis = "49";
                                    //model.CstCofins = "49";

                                    model.BCICMS = "0";
                                    model.ValorICMS = "0";
                                    model.ValorALIQICMS = "0";

                                    model.ValorBaseCOFINSAliquota = "0";
                                    model.AliqCofins = "0";
                                    model.COFINS = "0";

                                    model.QuantidadeBaseCalculoPISPauta = "0";
                                    model.AliquotaPISReaisPauta = "0";
                                    model.ValorBasePISAliquota = "0";
                                    model.AliqPis = "0";
                                    model.PISPASEP = "0";
                                }

                                var pagamento = sale.payments.FirstOrDefault();
                                if (pagamento != null)
                                    model.FormaPagamento = PaymentType(pagamento.type);

                                result.Add(model);
                            }
                        }
                    }
                }
            }

            return result;
        }

        private string PaymentType(string type)
        {
            string result = "";

            switch (type)
            {
                case "money": 
                    result = "dinheiro";
                    break;
                case "credit_card":
                    result = "cartão de credito";
                    break;
                case "debit_card":
                    result = "cartão de débito";
                    break;
                default:
                    result = "";
                    break;
            };

            return result;
    }


        public string COD_EMPRESA { get; set; }
        public string CNPJEmissor { get; set; }
        public string Empresa { get; set; }
        public string Status { get; set; }
        public string Modelo { get; set; }
        public string NumeroEquipamentoSAT { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string NumeroNFSe { get; set; }
        public string ChaveAcesso { get; set; }
        public string Protocolo { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string CPFCNPJDestinatario { get; set; }
        public string Destinatario { get; set; }
        public string MunicipioPrestador { get; set; }
        public string NaturezaOperacao { get; set; }
        public string RetornoOrgaoAutorizador { get; set; }
        public string ValorDocumento { get; set; }   
        public string CFOP { get; set; }
        public string DESCRICAOCFOP { get; set; }
        public string CodigoProduto { get; set; }
        public string DescrcaoProduto { get; set; }
        public string NCM { get; set; }
        public string ValorUnitarioProduto { get; set; }
        public string UNIDADEMEDIDA { get; set; }
        public int DescontoProduto { get; set; }
        public string ValorProdutoDepoisDesconto { get; set; }
        public string Quantidade { get; set; }
        public string VrTotalProduto { get; set; }
        public string BCICMS { get; set; }
        public string ValorICMS { get; set; }
        public string ValorALIQICMS { get; set; }
        public string INSS { get; set; }
        public string IRRF { get; set; }
        public string CSLL { get; set; }
        public string CstCofins { get; set; }
        public string QuantidadeBaseCalculoCOFINSPauta { get; set; }
        public string AliquotaCOFINSReaisPauta { get; set; }
        public string ValorBaseCOFINSAliquota { get; set; }
        public string AliqCofins { get; set; }
        public string COFINS { get; set; }
        public string CstPis { get; set; }
        public string QuantidadeBaseCalculoPISPauta { get; set; }
        public string AliquotaPISReaisPauta { get; set; }
        public string ValorBasePISAliquota { get; set; }
        public string AliqPis { get; set; }
        public string PISPASEP { get; set; }
        public string CONTACONTABIL { get; set; }
        public string ISSNormal { get; set; }
        public string ISSRetido { get; set; }
        public string FormaPagamento { get; set; }
    }

    public static class Extensions
    {
        public static string RemoveSpecialCharacters(this String input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)",
                RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return r.Replace(input, String.Empty);
        }
    }
}
