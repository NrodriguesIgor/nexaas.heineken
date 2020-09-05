using CsvHelper;
using nexaas.heineken.application;
using nexaas.heineken.model.Layouts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nexaas.heineken.form
{
    public partial class Form1 : Form
    {
        private string AmbienteSelecionado = ConfigurationManager.AppSettings["desenvolvimento"];
        private string LayoutSelecionado = "201";
        private string DataBaseName = ConfigurationManager.AppSettings["dev_database"];
        private string TipoArquivo = "csv";
        private string Company = ConfigurationManager.AppSettings["dev_company"];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            folderBrowserDialog1.Description = "Selecione uma pasta para salvar o arquivo.";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (result == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                status.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(status.Text) ||
                string.IsNullOrEmpty(AmbienteSelecionado) ||
                string.IsNullOrEmpty(LayoutSelecionado)) && string.IsNullOrEmpty(DataBaseName))
            {

                MessageBox.Show("Você esqueceu de selecionar algum item.", "Informação");
                return;
            }

            DataApplication dataApplication = new DataApplication(AmbienteSelecionado, DataBaseName);
            dataApplication.Inicio = dtInicio.Value;
            dataApplication.Fim = dtFim.Value;
            dataApplication.Company = Company;

            if (LayoutSelecionado.Equals("201"))
            {
                var listToFile = dataApplication.SAFX201();

                if (!listToFile.Any())
                {
                    MessageBox.Show("Nenhuma informação foi encontrada.", "Informação");
                }
                else
                {
                    string filename = $@"{status.Text}\safx201_{dtFim.Value:yyyyMMdd}.txt";

                    if (!File.Exists(filename))
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();


                            foreach (var item in listToFile)
                            {
                                sb.Append(item.COD_EMPRESA?.PadLeft(3, ' ') + "\t");
                                sb.Append(item.COD_ESTAB?.PadRight(6, ' ') + "\t");
                                sb.Append(item.NUM_EQUIP?.PadLeft(9, '0') + "\t");
                                sb.Append(item.NUM_CUPOM?.PadRight(6, ' ') + "\t");
                                sb.Append(item.DATA_EMISSAO?.PadLeft(8, ' ') + "\t");
                                sb.Append(item.COD_MODELO?.PadLeft(2, '0') + "\t");
                                sb.Append(item.IND_SITUACAO_CUPOM?.PadLeft(2, '0') + "\t");
                                sb.Append(item.NOME_CLIENTE?.PadRight(40, ' ') + "\t");
                                sb.Append(item.CPF_CNPJ_CLIENTE?.PadRight(14, ' ') + "\t");
                                sb.Append(item.NUM_AUTENTIC_NFE.PadRight(80, ' ') + "\t");
                                sb.Append(item.VLR_TOT?.PadLeft(17, '0') + "\t");
                                sb.Append(item.VLR_DESC?.PadLeft(17, '0') + "\t");
                                sb.Append(item.VLR_ACRES?.PadLeft(17, '0') + "\t");
                                sb.Append(item.VLR_TOT_LIQ?.PadLeft(17, '0') + "\t");
                                sb.Append(item.VLR_DESP_ACS?.PadLeft(17, '0'));
                                sb.Append(Environment.NewLine);
                            }

                            using StreamWriter sw = File.CreateText(filename);
                            sw.Write(sb.ToString());

                            MessageBox.Show($"Arquivo { filename } foi gerado com sucesso.", "Informação");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocorreu um erro na geração do arquivo.", "Error");
                        }

                    }
                }
            }

            if (LayoutSelecionado.Equals("202"))
            {
                if (!TipoArquivo.Equals("csv"))
                {
                    var listToFile = dataApplication.SAFX202();

                    if (!listToFile.Any())
                    {
                        MessageBox.Show("Nenhuma informação foi encontrada.", "Informação");
                    }
                    else
                    {
                        string filename = $@"{status.Text}\safx202_{dtFim.Value:yyyyMMdd}.txt";
                        if (!File.Exists(filename))
                        {
                            try
                            {
                                StringBuilder sb = new StringBuilder();

                                foreach (var resultItem in listToFile)
                                {
                                    if (string.IsNullOrEmpty(resultItem.COD_EMPRESA))
                                        continue;

                                    var cod_empresa = resultItem.COD_EMPRESA.PadLeft(3, ' ');
                                    var cod_estab = resultItem.COD_ESTAB?.PadRight(6, ' ');
                                    var num_equip = resultItem.NUM_EQUIP?.PadLeft(9, '0');
                                    var num_cupom = resultItem.NUM_CUPOM?.PadRight(6, ' ');
                                    var data_emissao = resultItem.DATA_EMISSAO;
                                    var num_item = resultItem.NUM_ITEM?.PadLeft(5, '0');
                                    var ind_produto = resultItem.IND_PRODUTO?.PadLeft(1, ' ');
                                    var cod_produto = resultItem.COD_PRODUTO?.PadRight(35, ' ');
                                    var cod_serv = resultItem.COD_SERVICO?.PadRight(4, ' ');
                                    var cod_cfo = resultItem.COD_CFO?.PadLeft(4, ' ');
                                    var cod_conta = resultItem.COD_CONTA?.PadLeft(10, '0');
                                    cod_conta = cod_conta.PadRight(70, ' ');

                                    var cod_situacao_a = resultItem.COD_SITUACAO_A?.PadLeft(1, '0');
                                    var cod_situacao_b = resultItem.COD_SITUACAO_B?.PadLeft(2, '0');
                                    var qtde = resultItem.QTDE?.PadLeft(11, '0');
                                    qtde = qtde.PadRight(11 + 6, '0');

                                    var vlr_unit = resultItem.VLR_UNIT?.PadLeft(17, '0');
                                    vlr_unit = vlr_unit.PadRight(17 + 2, '0');

                                    var vlr_item = resultItem.VLR_ITEM?.PadLeft(17, '0');

                                    var vlr_desc = resultItem.VLR_DESC?.PadLeft(15, '0');
                                    vlr_desc = vlr_desc.PadRight(15 + 2, '0');

                                    var vlr_acres = resultItem.VLR_ACRES?.PadLeft(15, '0').PadRight(2, '0');
                                    vlr_acres = vlr_acres.PadRight(15 + 2, '0');

                                    var vlr_tot_liq = resultItem.VLR_TOT_LIQ?.PadLeft(17, '0');

                                    var vlr_base_icms = resultItem.VLR_BASE_ICMS?.PadLeft(17, '0');

                                    var vlr_icms = resultItem.VLR_ICMS?.PadLeft(17, '0');

                                    var vlr_aliq_icms = resultItem.VLR_ALIQ_ICMS?
                                        .PadLeft(resultItem.VLR_ALIQ_ICMS.Length + 1, '0');
                                    vlr_aliq_icms = vlr_aliq_icms.PadRight(3 + 4, '0');

                                    var cod_sit_trib_pis = resultItem.COD_SIT_TRIB_PIS?.PadLeft(2, '0');
                                    var qtd_base_pis = resultItem.QTD_BASE_PIS?.PadLeft(15, '0');
                                    qtd_base_pis = qtd_base_pis.PadRight(15 + 3, '0');

                                    var vlr_aliq_pis_r = resultItem.VLR_ALIQ_PIS_R?.PadLeft(15, '0');
                                    vlr_aliq_pis_r = vlr_aliq_pis_r.PadRight(15 + 4, '0');

                                    var vlr_base_pis = resultItem.VLR_BASE_PIS?.PadLeft(17, '0');

                                    var vlr_pis = resultItem.VLR_PIS?.PadLeft(17, '0');

                                    var vlr_aliq_pis = resultItem.VLR_ALIQ_PIS?.PadLeft(3, '0');
                                    vlr_aliq_pis = vlr_aliq_pis.PadRight(3 + 4, '0');

                                    var cod_sit_trib_confins = resultItem.COD_SIT_TRIB_COFINS?.PadLeft(2, '0');

                                    var qtd_base_confins = resultItem.QTD_BASE_COFINS?.PadLeft(15, '0');
                                    qtd_base_confins = qtd_base_confins.PadRight(15 + 3, '0');

                                    var vlr_aliq_confins_r = resultItem.VLR_ALIQ_COFINS_R?.PadLeft(15, '0');
                                    vlr_aliq_confins_r = vlr_aliq_confins_r.PadRight(15 + 4, '0');

                                    var vlr_base_confins = resultItem.VLR_BASE_COFINS?.PadLeft(17, '0');

                                    var vlr_confins = resultItem.VLR_COFINS?.PadLeft(17, '0');

                                    var vlr_aliq_confins = resultItem.VLR_ALIQ_COFINS?.PadLeft(3, '0');
                                    vlr_aliq_confins = vlr_aliq_confins.PadRight(3 + 4, '0');

                                    var vlr_base_pis_st = resultItem.VLR_BASE_PIS_ST?.PadLeft(15, '0');
                                    vlr_base_pis_st = vlr_base_pis_st.PadRight(15 + 2, '0');

                                    var vlr_tributo_pis_st = resultItem.VLR_PIS_ST?.PadLeft(15, '0');
                                    vlr_tributo_pis_st = vlr_tributo_pis_st.PadRight(15 + 2, '0');

                                    var vlr_pis_st = resultItem.VLR_ALIQ_PIS_ST?.PadLeft(3, '0');
                                    vlr_pis_st = vlr_pis_st.PadRight(3 + 4, '0');

                                    var vlr_base_confins_st = resultItem.VLR_BASE_COFINS_ST?.PadLeft(15, '0');
                                    vlr_base_confins_st = vlr_base_confins_st.PadRight(15 + 2, '0');

                                    var vlr_confins_st = resultItem.VLR_COFINS_ST?.PadLeft(15, '0');
                                    vlr_confins_st = vlr_confins_st.PadRight(15 + 2, '0');

                                    var vlr_aliq_confins_st = resultItem.VLR_ALIQ_COFINS_ST?.PadLeft(3, '0');
                                    vlr_aliq_confins_st = vlr_aliq_confins_st.PadRight(3 + 4, '0');

                                    var vlr_desp_acs = resultItem.VLR_DESP_ACS?.PadLeft(15, '0');
                                    vlr_desp_acs = vlr_desp_acs.PadRight(15 + 2, '0');

                                    var cod_observacao = resultItem.COD_OBSERVACAO?.PadLeft(8, ' ');
                                    var cod_nat_rec = resultItem.COD_NAT_REC?.PadLeft(3, ' ');

                                    var vlr_exc_base_piscofins = resultItem.VLR_EXC_BASE_PISCOFINS?.PadLeft(15, '0');
                                    vlr_exc_base_piscofins = vlr_exc_base_piscofins.PadRight(15 + 2, '0');

                                    sb.Append(cod_empresa + "\t");
                                    sb.Append(cod_estab + "\t");
                                    sb.Append(num_equip + "\t");
                                    sb.Append(num_cupom + "\t");
                                    sb.Append(data_emissao + "\t");
                                    sb.Append(num_item + "\t");
                                    sb.Append(ind_produto + "\t");
                                    sb.Append(cod_produto + "\t");
                                    sb.Append(cod_serv + "\t");
                                    sb.Append(cod_cfo + "\t");
                                    sb.Append(cod_conta + "\t");
                                    sb.Append(cod_situacao_a + "\t");
                                    sb.Append(cod_situacao_b + "\t");
                                    sb.Append(qtde + "\t");
                                    sb.Append(vlr_unit + "\t");
                                    sb.Append(vlr_item + "\t");
                                    sb.Append(vlr_desc + "\t");
                                    sb.Append(vlr_acres + "\t");
                                    sb.Append(vlr_tot_liq + "\t");
                                    sb.Append(vlr_base_icms + "\t");
                                    sb.Append(vlr_icms + "\t");
                                    sb.Append(vlr_aliq_icms + "\t");
                                    sb.Append(cod_sit_trib_pis + "\t");
                                    sb.Append(qtd_base_pis + "\t");
                                    sb.Append(vlr_aliq_pis_r + "\t");
                                    sb.Append(vlr_base_pis + "\t");
                                    sb.Append(vlr_pis + "\t");
                                    sb.Append(vlr_aliq_pis + "\t");
                                    sb.Append(cod_sit_trib_confins + "\t");
                                    sb.Append(qtd_base_confins + "\t");
                                    sb.Append(vlr_aliq_confins_r + "\t");
                                    sb.Append(vlr_base_confins + "\t");
                                    sb.Append(vlr_confins + "\t");
                                    sb.Append(vlr_aliq_confins + "\t");
                                    sb.Append(vlr_base_pis_st + "\t");
                                    sb.Append(vlr_tributo_pis_st + "\t");
                                    sb.Append(vlr_pis_st + "\t");
                                    sb.Append(vlr_base_confins_st + "\t");
                                    sb.Append(vlr_confins_st + "\t");
                                    sb.Append(vlr_aliq_confins_st + "\t");
                                    sb.Append(vlr_desp_acs + "\t");
                                    sb.Append(cod_observacao + "\t");
                                    sb.Append(cod_nat_rec + "\t");
                                    sb.Append(vlr_exc_base_piscofins);
                                    sb.Append(Environment.NewLine);
                                }

                                using (FileStream fs = File.Create(filename))
                                {
                                    // Add some text to file    
                                    byte[] title = new UTF8Encoding(true).GetBytes(sb.ToString());
                                    fs.Write(title, 0, title.Length);
                                }

                                MessageBox.Show($"Arquivo { filename } foi gerado com sucesso.", "Informação");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocorreu um erro na geração do arquivo.", "Error");
                            }
                        }
                    }
                }
                else // Gerar arquivo csv
                {
                    try
                    {
                        string delimiter = ";";
                        var listToFile = dataApplication.SAFX202CSV().Result;

                        if (!listToFile.Any())
                        {
                            MessageBox.Show("Nenhuma informação foi encontrada.", "Informação");
                        }
                        else
                        {
                            string filename = $@"{status.Text}\202_Relat_fiscal_{dtFim.Value:yyyymmdd}.csv";
                            if (!File.Exists(filename))
                            {
                                try
                                {
                                    IList<string> headers = new List<string>
                                    {
                                        "CNPJ Emissor", "Empresa", "Status", "Modelo","Numero do Equipamento SAT",
                                        "Numero", "Serie", "Chave de acesso","Protocolo",
                                        "Data de emissao", "CPF/CNPJ do destinatario","Destinatario",
                                        "Municipio Prestador", "Natureza de Operacao", "Retorno do orgao autorizador",
                                        "Valor do documento", "CFOP", "DESCRICAO CFOP", "codigo produto",
                                        "descricao do produto", "NCM", "valor unitario do produto", "UNIDADE MEDIDA",
                                        "desconto produto", "valor do produto depois do desconto",
                                        "quantidade", "vr total produto", "Aliquota ICMS", "BC ICMS", "Valor do ICMS",
                                        "INSS", "IRRF", "CSLL", "cst cofins",
                                        "Quantidade - Base de Calculo COFINS (Pauta)",
                                        "Aliquota COFINS (em Reais) - (Pauta)",
                                        "Valor Base COFINS (Aliquota)", "aliq cofins","COFINS",
                                        "cst pis", "Quantidade - Base de Calculo PIS - (Pauta)",
                                        "Aliquota PIS (em Reais) - (Pauta)", "Valor Base PIS (Aliquota)",
                                        "aliq pis", "PIS/PASEP", "CONTA CONTABIL", "Forma de Pagamento"
                                    };

                                    StringBuilder sb = new StringBuilder();

                                    int count = 0;
                                    foreach (string head in headers)
                                    {
                                        if (count == headers.Count - 1)
                                        {
                                            sb.Append(head);
                                        }
                                        else
                                        {
                                            sb.Append($"{head}{delimiter}");
                                        }

                                        count++;
                                    }

                                    sb.Append(Environment.NewLine);

                                    foreach (var resultItem in listToFile)
                                    //Parallel.ForEach(listToFile, resultItem =>
                                    {
                                        sb.Append(resultItem.CNPJEmissor);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Empresa);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Status);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Modelo);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.NumeroEquipamentoSAT);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Numero);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Serie);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ChaveAcesso);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Protocolo);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.DataEmissao);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CPFCNPJDestinatario);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Destinatario);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.MunicipioPrestador);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.NaturezaOperacao);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.RetornoOrgaoAutorizador);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorDocumento);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CFOP);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.DESCRICAOCFOP);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CodigoProduto);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.DescrcaoProduto);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.NCM);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorUnitarioProduto);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.UNIDADEMEDIDA);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.DescontoProduto);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorProdutoDepoisDesconto);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.Quantidade);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.VrTotalProduto);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorALIQICMS);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.BCICMS);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorICMS);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.INSS);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.IRRF);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CSLL);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CstCofins);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.QuantidadeBaseCalculoCOFINSPauta);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.AliquotaCOFINSReaisPauta);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorBaseCOFINSAliquota);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.AliqCofins);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.COFINS);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CstPis);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.QuantidadeBaseCalculoPISPauta);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.AliquotaPISReaisPauta);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.ValorBasePISAliquota);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.AliqPis);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.PISPASEP);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.CONTACONTABIL);
                                        sb.Append(delimiter);
                                        sb.Append(resultItem.FormaPagamento);
                                        sb.Append(Environment.NewLine);
                                    }//);

                                    using StreamWriter sw = File.CreateText(filename);

                                    sw.WriteAsync(sb.ToString());

                                    MessageBox.Show($"Arquivo { filename } foi gerado com sucesso.", "Informação");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocorreu um erro na geração do arquivo.", "Error");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro na geração do arquivo.", "Error");
                    }
                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string data = ((ComboBox)sender).SelectedItem as string;

            switch (data)
            {
                case "202":
                    LayoutSelecionado = "202";
                    comboBox3.Enabled = true;
                    label1.Enabled = true;
                    break;
                default:
                    LayoutSelecionado = "201";
                    comboBox3.Enabled = false;
                    label1.Enabled = false;
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = ((ComboBox)sender).SelectedItem as string;

            switch (data)
            {
                case "Produção":
                    AmbienteSelecionado = ConfigurationManager.AppSettings["producao"];
                    DataBaseName = ConfigurationManager.AppSettings["prod_database"];
                    Company = ConfigurationManager.AppSettings["prod_company"];
                    break;
                case "Homologação":
                    AmbienteSelecionado = ConfigurationManager.AppSettings["homologacao"];
                    DataBaseName = ConfigurationManager.AppSettings["hom_database"];
                    Company = ConfigurationManager.AppSettings["hom_company"];
                    break;
                default:
                    AmbienteSelecionado = ConfigurationManager.AppSettings["desenvolvimento"];
                    DataBaseName = ConfigurationManager.AppSettings["dev_database"];
                    Company = ConfigurationManager.AppSettings["dev_company"];
                    break;
            }
        }

        public void WriteCSVFile(string path, List<SAFX201> list)
        {
            using StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true));
            using CsvWriter cw = new CsvWriter((ISerializer)sw);
            cw.WriteHeader<SAFX201>();
            cw.NextRecord();
            foreach (SAFX201 stu in list)
            {
                cw.WriteRecord<SAFX201>(stu);
                cw.NextRecord();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string data = ((ComboBox)sender).SelectedItem as string;

            TipoArquivo = data switch
            {
                "csv" => "csv",
                _ => "txt",
            };
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) { }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) { }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) { }
    }
}
