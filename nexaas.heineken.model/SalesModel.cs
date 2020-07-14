using MongoDB.Bson.Serialization.Attributes;
using nexaas.heineken.model.XMLModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace nexaas.heineken.model
{
    [BsonIgnoreExtraElements]
    public class Barcode
    {
        public bool synced { get; set; }
        public string code { get; set; }
        public string company_uuid { get; set; }
        public string sellable_uuid { get; set; }
        public string type { get; set; }
        public DateTime updated_at { get; set; }
        public string uuid { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Metadata
    {
    }

    [BsonIgnoreExtraElements]
    public class ProductsUuids
    {
    }

    [BsonIgnoreExtraElements]
    public class Taxes
    {
        public string cest { get; set; }
        public bool use_default_configuration { get; set; }
        public string ncm { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Sellable
    {
        public IList<Barcode> barcodes { get; set; }
        public string category_uuid { get; set; }
        public string code { get; set; }
        public string company_uuid { get; set; }
        public IList<object> featured_images { get; set; }
        public string stock_count { get; set; }
        public Metadata metadata { get; set; }
        public string name { get; set; }
        public IList<object> optional_groups_uuids { get; set; }
        public IList<object> optional_groups { get; set; }
        public ProductsUuids products_uuids { get; set; }
        public int sell_value { get; set; }
        public bool is_snapshot { get; set; }
        public Taxes taxes { get; set; }
        public string type { get; set; }
        public string unit_label { get; set; }
        public DateTime updated_at { get; set; }
        public string uuid { get; set; }
        public IList<object> variations { get; set; }
        public object image_url { get; set; }
        public bool custom_sell_value { get; set; }
        public bool deleted { get; set; }
        public DateTime created_at { get; set; }
        public string account_uuid { get; set; }
        public IList<object> variations_uuids { get; set; }
        public int? cost_value { get; set; }
        public string origin { get; set; }
        public int stock_value { get; set; }
        public object sku_uuid { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class CartItem
    {
        public int discount { get; set; }
        public string quantity { get; set; }
        public Sellable sellable { get; set; }
        public double? returned_quantity { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Sale
    {
        public string type { get; set; }
        public int number { get; set; }
        public string status { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Payment
    {
        public int amount { get; set; }
        public string company_uuid { get; set; }
        public int installments { get; set; }
        public Metadata metadata { get; set; }
        public string type { get; set; }
        public DateTime processed_at { get; set; }
        public string status { get; set; }
        public string uuid { get; set; }
        public string sale_uuid { get; set; }
        public string account_uuid { get; set; }
        public int real_amount { get; set; }
        public Sale sale { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Document
    {
        public int number { get; set; }
        public object qrcode_url { get; set; }
        public string status { get; set; }
        public string xml { get; set; }
        public NfeProc NFe { get; set; }

        public void DealXml()
        {
            if(!string.IsNullOrEmpty(xml))
            {
                NFeSerialization serializable = new NFeSerialization();
                this.NFe= serializable.GetObjectFromFile<NfeProc>(xml);
            }
        }
    }

    [BsonIgnoreExtraElements]
    public class DeviceInfo
    {
        public string pos_id { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Address
    {
        public string uf_code { get; set; }
        public string zipcode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string address_type { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class FiscalInformations
    {
        public string cnpj { get; set; }
        public string legal_name { get; set; }
        public string ie { get; set; }
        public string im { get; set; }
        public string accountant_email { get; set; }
        public string municipal_code { get; set; }
        public string crt_code { get; set; }
        public string iest_code { get; set; }
        public string cnae_code { get; set; }
        public string csc { get; set; }
        public string csc_id { get; set; }
        public string sat_association_code { get; set; }
        public string picms { get; set; }
        public string modbc { get; set; }
        public string predbc { get; set; }
        public string vicmsdeson { get; set; }
        public string motdesicms { get; set; }
        public string vbcstret { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Napp
    {
        public string name { get; set; }
        public dynamic id { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public bool enabled { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class MyFinance
    {
    }

    [BsonIgnoreExtraElements]
    public class MercadoPago
    {
        public bool enabled { get; set; }
        public string token { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Integrations
    {
        public Napp napp { get; set; }
        public MyFinance my_finance { get; set; }
        public MercadoPago mercado_pago { get; set; }
        public DateTime updated_at { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class DefaultTip
    {
        public string code { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public object taxes { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class CertificateInfo
    {
    }
    [BsonIgnoreExtraElements]
    public class DefaultTaxes
    {
    }
    [BsonIgnoreExtraElements]
    public class EmailTexts
    {
        public string sale_document { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Billing
    {
    }

    [BsonIgnoreExtraElements]
    public class CustomOtherPayment
    {
        public string uuid { get; set; }
        public string label { get; set; }
        public string payment_type { get; set; }
        public bool enabled { get; set; }
        public bool use_note { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Company
    {
        public string _id { get; set; }
        public string uuid { get; set; }
        public string account_uuid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
        public FiscalInformations fiscal_informations { get; set; }
        public bool deleted { get; set; }
        public int max_devices { get; set; }
        public IList<string> features { get; set; }
        public object emission_token { get; set; }
        public object crypto_key { get; set; }
        public string email { get; set; }
        public Integrations integrations { get; set; }
        public Metadata metadata { get; set; }
        public int max_installments { get; set; }
        public DefaultTip default_tip { get; set; }
        public bool can_issue_invoice { get; set; }
        public CertificateInfo certificate_info { get; set; }
        public DateTime updated_at { get; set; }
        public DefaultTaxes default_taxes { get; set; }
        public IList<object> customer_custom_fields { get; set; }
        public int min_installments_value { get; set; }
        public bool ecommerce_only { get; set; }
        public EmailTexts email_texts { get; set; }
        public string receipt_additional_message { get; set; }
        public string timezone { get; set; }
        public bool blocked { get; set; }
        public DateTime created_at { get; set; }
        public object stock_management_strategy { get; set; }
        public Billing billing { get; set; }
        public string notify_email { get; set; }
        public IList<object> customer_fields { get; set; }
        public IList<CustomOtherPayment> custom_other_payments { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class SAFX202Model
    {
        public string _id { get; set; }
        public DateTime? activated_at { get; set; }
        public IList<CartItem> cart_items { get; set; }
        public IList<Payment> payments { get; set; }
        public Document document { get; set; }
        public DeviceInfo device_info { get; set; }
        public IList<Company> company { get; set; }
        public dynamic customer { get; set; }
    }
}
