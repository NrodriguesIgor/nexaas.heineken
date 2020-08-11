using System;
using System.Collections.Generic;
using System.Text;

namespace nexaas.heineken.model
{
    public class EmpresaEstabelecimento
    {
        public string COD_EMPRESA { get; set; }
        public string COD_ESTAB { get; set; }
        public string CNPJ { get; set; }

        public List<EmpresaEstabelecimento> GetAll()
        {
            return new List<EmpresaEstabelecimento>
            {
                new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B001",
                    CNPJ = "50221019000136"
                },
                new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B002",
                    CNPJ = "50221019001370"
                },
                new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B003",
                    CNPJ = "50221019003828"
                },
                new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B004",
                    CNPJ = "50221019005790"
                },
                new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B005",
                    CNPJ = "50221019005448"
                },new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B010",
                    CNPJ = "50221019000489"
                },new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B011",
                    CNPJ = "50221019000802"
                },new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B012",
                    CNPJ = "50221019001027"
                },new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "B00",
                    COD_ESTAB = "B013",
                    CNPJ = "50221019001450"
                },new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "K00",
                    COD_ESTAB = "K070",
                    CNPJ = "05254957002040"
                },
                new EmpresaEstabelecimento
                {
                    COD_EMPRESA = "K00",
                    COD_ESTAB = "K070",
                    CNPJ = "08723218000186"
                }
            };
        }



    }
}
