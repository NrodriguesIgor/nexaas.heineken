using CsvHelper;
using nexaas.heineken.application;
using nexaas.heineken.model.Layouts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nexaas.heineken.form
{
    public partial class Form1 : Form
    {
        private string AmbienteSelecionado = "";
        private string LayoutSelecionado = "";

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
            if (string.IsNullOrEmpty(status.Text) ||
                string.IsNullOrEmpty(AmbienteSelecionado) ||
                string.IsNullOrEmpty(LayoutSelecionado))
            {

                MessageBox.Show("Você esqueceu de selecionar algum item.", "Informação");
                return;
            }

            DataApplication dataApplication = new DataApplication(AmbienteSelecionado);

            if (LayoutSelecionado.Equals("201"))
            {
                var listToFile = dataApplication.SAFX201();

                string filename = $@"{status.Text}\{listToFile.First().COD_EMPRESA}201_{DateTime.Now.ToString("yyyymmdd")}.txt";

                if (!File.Exists(filename))
                {
                    try
                    {
                        using StreamWriter sw = File.CreateText(filename);
                        foreach (var item in listToFile)
                        {
                            sw.WriteLine($"{item.COD_EMPRESA}  {item.COD_ESTAB}  {item.NUM_EQUIP} {item.NUM_CUPOM} {item.DATA_EMISSAO} {item.COD_MODELO} {item.IND_SITUACAO_CUPOM} {item.NOME_CLIENTE} {item.CPF_CNPJ_CLIENTE} {item.NUM_AUTENTIC_NFE} {item.VLR_TOT} {item.VLR_DESC} {item.VLR_ACRES} {item.VLR_TOT_LIQ} {item.VLR_DESP_ACS}");
                        }


                        MessageBox.Show($"Arquivo { filename } foi gerado com sucesso.", "Informação");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro na geração do arquivo.", "Error");
                    }

                }


            }

            if (LayoutSelecionado.Equals("202"))
            {
                var listToFile = dataApplication.SAFX202();
                string filename = $@"{status.Text}\{listToFile.First().COD_EMPRESA}202_{DateTime.Now.ToString("yyyymmdd")}.txt";
                if (!File.Exists(filename))
                {
                    try
                    {
                        using StreamWriter sw = File.CreateText(filename);
                        foreach (var resultItem in dataApplication.SAFX202())
                        {
                            sw.WriteLine($"{resultItem.COD_EMPRESA}  {resultItem.COD_ESTAB} {resultItem.NUM_EQUIP} {resultItem.NUM_CUPOM} {resultItem.DATA_EMISSAO} {resultItem.NUM_ITEM} {resultItem.IND_PRODUTO} {resultItem.COD_PRODUTO} {resultItem.COD_SERVICO} {resultItem.COD_CFO} {resultItem.COD_CONTA} {resultItem.COD_SITUACAO_A} {resultItem.COD_SITUACAO_B} {resultItem.QTDE} {resultItem.VLR_UNIT} {resultItem.VLR_ITEM} {resultItem.VLR_DESC} {resultItem.VLR_ACRES} {resultItem.VLR_TOT_LIQ} {resultItem.VLR_BASE_ICMS} {resultItem.VLR_ICMS} {resultItem.VLR_ALIQ_ICMS} {resultItem.COD_SIT_TRIB_PIS} {resultItem.QTD_BASE_PIS} {resultItem.VLR_ALIQ_PIS_R} {resultItem.VLR_BASE_PIS} {resultItem.VLR_PIS} {resultItem.VLR_ALIQ_PIS} {resultItem.COD_SIT_TRIB_COFINS} {resultItem.QTD_BASE_COFINS} {resultItem.VLR_ALIQ_COFINS_R} {resultItem.VLR_BASE_COFINS} {resultItem.VLR_COFINS} {resultItem.VLR_ALIQ_COFINS} {resultItem.VLR_BASE_PIS_ST} {resultItem.VLR_PIS_ST} {resultItem.VLR_BASE_COFINS_ST} {resultItem.VLR_COFINS_ST} {resultItem.VLR_ALIQ_COFINS_ST} {resultItem.VLR_DESP_ACS} {resultItem.COD_OBSERVACAO} {resultItem.COD_NAT_REC} {resultItem.VLR_EXC_BASE_PISCOFINS}");
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

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string layout = (((ComboBox)sender).SelectedItem as string) switch
            {
                "201" => "201",
                "202" => "202",
                _ => "201"
            };

            LayoutSelecionado = layout;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ambiente = (((ComboBox)sender).SelectedItem as string) switch
            {
                "Produção" => "producao",
                "homologação" => "homologacao",
                _ => "desenvolvimento",
            };

            AmbienteSelecionado = ConfigurationManager.AppSettings[ambiente];
        }

        public void WriteCSVFile(string path, List<SAFX201> list)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter((ISerializer)sw))
            {
                cw.WriteHeader<SAFX201>();
                cw.NextRecord();
                foreach (SAFX201 stu in list)
                {
                    cw.WriteRecord<SAFX201>(stu);
                    cw.NextRecord();
                }
            }
        }
    }
}
