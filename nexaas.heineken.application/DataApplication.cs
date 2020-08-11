using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using nexaas.heineken.model;
using nexaas.heineken.model.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nexaas.heineken.application
{
    public class DataApplication
    {
        private readonly MongoClient client;

        private readonly IMongoDatabase database;

        private readonly IMongoCollection<BsonDocument> collection;

        public DateTime Inicio { get; set; } = DateTime.Today;

        public DateTime Fim { get; set; } = DateTime.Today;

        public string Company { get; set; }

        public DataApplication(string connectionString, string dbname)
        {
            MongoUrl url = new MongoUrl(connectionString);
            client = new MongoClient(url);
            database = client.GetDatabase(dbname);
            collection = database.GetCollection<BsonDocument>("sales");
        }

        public IList<SAFX201> SAFX201()
        {
            var hora_inicio = "00:00:00";
            var hora_fim = "23:59:59";
            var data_inicio = Inicio.ToString("yyyy-MM-dd");
            var data_fim = Fim.ToString("yyyy-MM-dd");

            var filter = new BsonDocument() {
                { "$match", new BsonDocument(){
                    { "activated_at", new BsonDocument(){
                        { "$gte", DateTime.Parse($"{data_inicio}T{hora_inicio}.000-03:00") },
                        { "$lt", DateTime.Parse($"{data_fim}T{hora_fim}.000-03:00") }
                    } },
                    { "company_uuid", Company }
                }}
            };

            var pipeline = new[] { filter, new BsonDocument() {
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
                            {"document.access_key" , 1},
                            {"document.type" , 1},
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
                var hasType = false;
                BsonElement documentStatus;
                BsonElement documentQrCode;
                BsonElement documentNumber;
                BsonElement documentAccessKey;
                BsonElement documentType;
                if (hasDocument)
                {
                    var documentDoc = document.GetElement("document").Value.AsBsonDocument;
                    hasDocStatus = documentDoc.TryGetElement("status", out documentStatus);
                    hasDocQrCode = documentDoc.TryGetElement("qrcode_url", out documentQrCode);
                    hasDocNumber = documentDoc.TryGetElement("number", out documentNumber);
                    hasDocAccessKey = documentDoc.TryGetElement("access_key", out documentAccessKey);
                    hasType = documentDoc.TryGetElement("type", out documentType);
                }

                if (hasType && documentType.Value.BsonType != BsonType.Null) {
                    var type = documentType.Value.ToString();
                    if (type.Equals("devolution")) continue;
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

                //cart_item
                var hasCartItems = document.TryGetElement("cart_items", out BsonElement cartItens);
                BsonArray itemList;
                double valorDiscount = 0;
                if(hasCartItems)
                {
                    itemList = cartItens.Value.AsBsonArray;
                    var s = itemList
                        .GroupBy(x => Convert.ToDouble(x.AsBsonDocument.GetElement("discount").Value))
                        .Select(n => n.Sum(s => Convert.ToDouble(s.AsBsonDocument.GetElement("discount").Value))).ToList();

                    if (s.Any()) valorDiscount = s.FirstOrDefault();
                }

                var empresaEstabelecimento = estabelecimentos.FirstOrDefault(x => x.CNPJ == company.fiscal_informations.cnpj);

                if (empresaEstabelecimento != null)
                {
                    var model = new SAFX201
                    {
                        COD_EMPRESA = empresaEstabelecimento != null ? empresaEstabelecimento.COD_EMPRESA : "H00",
                        COD_ESTAB = empresaEstabelecimento != null ? empresaEstabelecimento.COD_ESTAB : "H001",
                        NUM_EQUIP = hasPosId ? numEquip.Value.ToString().Replace("-", "") : "0",
                        NUM_CUPOM = hasDocNumber ? documentNumber.Value.ToString() : "0",
                        DATA_EMISSAO = document.GetElement("activated_at").Value.BsonType == BsonType.Null ? DateTime.Now.ToString("yyyyMMdd") : DateTime.Parse(document.GetElement("activated_at").Value.ToString()).ToString("yyyyMMdd"),
                        COD_MODELO = "59",
                        IND_SITUACAO_CUPOM = hasDocStatus ? (documentStatus.Value.ToString().Equals("cancelled") ? "02" : documentStatus.Value.ToString().Equals("rejected") ? "04" : "00") : "00",
                        NOME_CLIENTE = (hasCustomerName ? customerName.Value.ToString() : ""),
                        CPF_CNPJ_CLIENTE = (hasCustomerIdentification ? customerIdentification.Value.ToString() : "").PadLeft(14, ' '),
                        NUM_AUTENTIC_NFE = "0",
                        VLR_TOT_LIQ = (hasAmount ? paymentAmount.Value.ToString() : "0"),
                        VLR_ACRES = "0",
                        VLR_DESC = valorDiscount.ToString(),
                        VLR_DESP_ACS = "0",
                    };

                    model.VLR_TOT = (double.Parse(model.VLR_TOT_LIQ) + valorDiscount).ToString();

                    if (hasDocAccessKey && documentAccessKey.Value.BsonType != BsonType.Null)
                    {
                        var key = documentAccessKey.Value.ToString();
                        if (key.Contains("CFe"))
                        {
                            if (key.Length > 3)
                                model.NUM_AUTENTIC_NFE = key.Remove(0, 3);
                        }
                        else
                            model.NUM_AUTENTIC_NFE = key;
                    }

                    model.NUM_AUTENTIC_NFE.PadLeft(44, '0');
                    list.Add(model);
                }
            }

            return list;
        }

        public IList<SAFX202> SAFX202()
        {
            var hora_inicio = "00:00:00";
            var hora_fim = "23:59:59";
            var data_inicio = Inicio.ToString("yyyy-MM-dd");
            var data_fim = Fim.ToString("yyyy-MM-dd");

            var filter = new BsonDocument() {
                { "$match", new BsonDocument(){
                    { "activated_at", new BsonDocument(){
                        { "$gte", DateTime.Parse($"{data_inicio}T{hora_inicio}.000-03:00") },
                        { "$lt", DateTime.Parse($"{data_fim}T{hora_fim}.000-03:00") }
                    } },
                    { "company_uuid", Company }
                }}
            };

            var pipeline = new[] { filter, new BsonDocument() {
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

            var data = results.Where(x => x.company != null && x.document != null && x.document.xml != null).ToList();


            foreach (var itemSale in data)
            { 
                var estabelecimento = estabelecimentos.FirstOrDefault(x => x.CNPJ == itemSale.company[0].fiscal_informations.cnpj);

                if (estabelecimento != null)
                {
                    itemSale.document.DealXml();

                    foreach (var cartItem in itemSale.cart_items)
                    {
                        //listToFile.Add(new SAFX202(itemSale, cartItem, estabelecimento));

                        var model = new SAFX202();
                        var list = model.DataGen(itemSale, cartItem, estabelecimento);
                        if (list.Any()) list.ToList().ForEach(x => listToFile.Add(x));
                    }
                }
            }

            return listToFile;
        }

        public async Task<IList<SAFX202Csv>> SAFX202CSV()
        {
            var hora_inicio = "00:00:00";
            var hora_fim = "23:59:59";
            var data_inicio = Inicio.ToString("yyyy-MM-dd");
            var data_fim = Fim.ToString("yyyy-MM-dd");

            var filter = new BsonDocument() {
                { "$match", new BsonDocument(){
                    { "activated_at", new BsonDocument(){
                        { "$gte", DateTime.Parse($"{data_inicio}T{hora_inicio}.000-03:00") },
                        { "$lt", DateTime.Parse($"{data_fim}T{hora_fim}.000-03:00") }
                    } },
                    { "company_uuid", Company }
                }}
            };

            //var pipeline = new[] { filter, new BsonDocument() {
            var pipeline = new[] { filter, new BsonDocument() {
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

            var results = await collection.Aggregate<SAFX202Model>(pipeline).ToListAsync();
            var estabelecimentos = new EmpresaEstabelecimento().GetAll();

            List<SAFX202Csv> listToFile = new List<SAFX202Csv>();
            var data = results.Where(x => x.company != null && x.document != null && x.document.xml != null);

            foreach (var itemSale in data)
            //Parallel.ForEach(data, itemSale =>
            {
                var estabelecimento = estabelecimentos
                    .FirstOrDefault(x => x.CNPJ == itemSale.company[0].fiscal_informations.cnpj);

                if (estabelecimento != null)
                {
                    itemSale.document.DealXml();

                    foreach (var cartItem in itemSale.cart_items)
                    {
                        //var model = new SAFX202Csv(itemSale, cartItem, estabelecimento);

                        var model = new SAFX202Csv();
                        var list = model.DataGen(itemSale, cartItem, estabelecimento);
                        if (list.Any())
                            if (list.Any()) list.ToList().ForEach(x => listToFile.Add(x));
                    }
                }
            }//);

            return listToFile;
        }
    }
}
