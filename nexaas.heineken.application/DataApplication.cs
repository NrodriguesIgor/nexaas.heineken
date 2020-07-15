using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using nexaas.heineken.model;
using nexaas.heineken.model.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace nexaas.heineken.application
{
    public class DataApplication
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<BsonDocument> collection;

        public DataApplication(string connectionString)
        {
            MongoUrl url = new MongoUrl(connectionString);
            client = new MongoClient(url);
            database = client.GetDatabase("app-pdvend-sandbox");
            collection = database.GetCollection<BsonDocument>("sales");
        }

        public IList<SAFX201> SAFX201()
        {
            var pipeline = new[] { new BsonDocument() {
                {"$lookup",
                    new BsonDocument(){
                        {"from","companies"},
                        {"localField","company_uuid"},
                        {"foreignField","uuid" },
                        {"as", "company" } } }
            },new BsonDocument() { { "$project",new BsonDocument(){
                            {"device_info.pos_id" , 1},
                            {"document.number" , 1},
                            {"activated_at" , 1},
                            {"document.status",1 },
                            {"customer.name" , 1},
                            {"customer.identification.cnpj" , 1},
                            {"document.qrcode_url" , 1},
                            {"payments" , 1},
                            {"company" , 1},
                            {"cart_items" , 1}
                        } } }};

            var results = collection.Aggregate<BsonDocument>(pipeline).ToList();

            var list = new List<SAFX201>();

            var estabelecimentos = new EmpresaEstabelecimento().GetAll();


            foreach (var document in results)
            {
                //device info
                var hasNumEquip = document.TryGetElement("device_info", out BsonElement numEquip);
                var hasPosId = false;
                if (hasNumEquip)
                {
                    var deviceInfoDoc = document.GetElement("device_info").Value.AsBsonDocument;
                    hasPosId = deviceInfoDoc.TryGetElement("pos_id", out numEquip);
                }

                //device info
                var hasCompany = document.TryGetElement("company", out BsonElement comnpany);
                Company company = null;
                if (hasCompany)
                {
                    company = BsonSerializer.Deserialize<Company>(document.GetElement("company").Value.AsBsonArray.First().AsBsonDocument);
                }

                //document
                var hasDocument = document.TryGetElement("document", out BsonElement documentElement);
                var hasDocStatus = false;
                var hasDocQrCode = false;
                var hasDocNumber = false;
                var hasDocAccessKey = false;
                BsonElement documentStatus;
                BsonElement documentQrCode;
                BsonElement documentNumber;
                BsonElement documentAccessKey;
                if (hasDocument)
                {
                    var documentDoc = document.GetElement("document").Value.AsBsonDocument;
                    hasDocStatus = documentDoc.TryGetElement("status", out documentStatus);
                    hasDocQrCode = documentDoc.TryGetElement("qrcode_url", out documentQrCode);
                    hasDocNumber = documentDoc.TryGetElement("number", out documentNumber);
                    hasDocAccessKey = documentDoc.TryGetElement("access_key", out documentAccessKey);
                }

                //customer
                var hasCustomer = document.TryGetElement("customer", out BsonElement customerElement);
                var hasCustomerName = false;
                var hasCustomerIdentification = false;
                BsonElement customerName;
                BsonElement customerIdentification;


                if (hasCustomer)
                {
                    var customerDoc = document.GetElement("customer").Value.AsBsonDocument;
                    hasCustomerName = customerDoc.TryGetElement("name", out customerName);
                    hasCustomerIdentification = customerDoc.TryGetElement("identification", out customerIdentification);
                }

                //payments
                var hasPayments = document.TryGetElement("payments", out BsonElement payments);
                var hasRealAmount = false;
                var hasAmount = false;
                BsonArray paymentsList;
                BsonElement paymentRealAmount;
                BsonElement paymentAmount;
                if (hasPayments)
                {
                    paymentsList = payments.Value.AsBsonArray;
                    hasRealAmount = paymentsList.First().AsBsonDocument.TryGetElement("real_amount", out paymentRealAmount);
                    hasAmount = paymentsList.First().AsBsonDocument.TryGetElement("amount", out paymentAmount);
                }

                var empresaEstabelecimento = estabelecimentos.FirstOrDefault(x => x.CNPJ == company.fiscal_informations.cnpj);

                if (empresaEstabelecimento != null)
                {
                    list.Add(new SAFX201
                    {
                        COD_EMPRESA = empresaEstabelecimento != null ? empresaEstabelecimento.COD_EMPRESA : "H00",
                        COD_ESTAB = empresaEstabelecimento != null ? empresaEstabelecimento.COD_ESTAB : "H001",
                        NUM_EQUIP = hasPosId ? numEquip.Value.ToString().Replace("-", "") : "000000000",
                        NUM_CUPOM = hasDocNumber ? documentNumber.Value.ToString().PadLeft(6, '0') : "000000",
                        DATA_EMISSAO = document.GetElement("activated_at").Value.BsonType == BsonType.Null ? DateTime.Now.ToString("yyyymmdd") : DateTime.Parse(document.GetElement("activated_at").Value.ToString()).ToString("yyyymmdd"),
                        COD_MODELO = "59",
                        IND_SITUACAO_CUPOM = hasDocStatus ? (documentStatus.Value.ToString().Equals("cancelled") ? "02" : documentStatus.Value.ToString().Equals("rejected") ? "04" : "00") : "00",
                        NOME_CLIENTE = (hasCustomerName ? customerName.Value.ToString() : "").PadLeft(60, ' '),
                        CPF_CNPJ_CLIENTE = (hasCustomerIdentification ? customerIdentification.Value.ToString() : "").PadLeft(14, ' '),
                        NUM_AUTENTIC_NFE = hasDocAccessKey && documentAccessKey.Value.BsonType != BsonType.Null ? documentAccessKey.Value.ToString().PadLeft(80, ' ') : "".PadLeft(80, ' '),
                        VLR_TOT = (hasAmount ? paymentAmount.Value.ToString() : "").PadLeft(17, '0'),
                        VLR_ACRES = "00000000000000000",
                        VLR_DESC = "00000000000000000",
                        VLR_DESP_ACS = "00000000000000000",
                        VLR_TOT_LIQ = (hasRealAmount ? paymentRealAmount.Value.ToString() : "").PadLeft(17, '0'),

                    });
                }
            }

            return list;
        }

        public IList<SAFX202> SAFX202()
        {
            var pipeline = new[] { new BsonDocument() {
                {"$lookup",
                    new BsonDocument(){
                        {"from","companies"},
                        {"localField","company_uuid"},
                        {"foreignField","uuid" },
                        {"as", "company" } } }
            },new BsonDocument() { { "$project",new BsonDocument(){
                            {"device_info.pos_id" , 1},
                            {"document.number" , 1},
                            {"activated_at" , 1},
                            {"document.status",1 },
                            {"customer.name" , 1},
                            {"customer.identification.cnpj" , 1},
                            {"document.qrcode_url" , 1},
                            {"document.xml" , 1},
                            {"payments" , 1},
                            {"company" , 1},
                            {"cart_items" , 1}
                        } } }};

            var results = collection.Aggregate<SAFX202Model>(pipeline).ToList();

            var estabelecimentos = new EmpresaEstabelecimento().GetAll();

            List<SAFX202> listToFile = new List<SAFX202>();

            foreach (var itemSale in results.Where(x => x.company != null && x.document != null && x.document.xml != null))
            {
                var estabelecimento = estabelecimentos.FirstOrDefault(x => x.CNPJ == itemSale.company[0].fiscal_informations.cnpj);

                if (estabelecimento != null)
                {
                    itemSale.document.DealXml();

                    foreach (var cartItem in itemSale.cart_items)
                    {
                        listToFile.Add(new SAFX202(itemSale, cartItem, estabelecimento));
                    }
                }


            }

            return listToFile;
        }
    }
}
