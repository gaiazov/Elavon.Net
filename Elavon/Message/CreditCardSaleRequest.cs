using System.Xml.Serialization;

namespace Elavon.Message
{
    [XmlType("txn")]
    public class CreditCardSaleRequest
    {
        public enum Cvv2Cvc2Type
        {
            Bypassed = 0,
            Present = 1,
            Illegible = 2,
            NotPresent = 9
        }

        [XmlElement("ssl_transaction_type")]
        public string TransactionType;

        [XmlElement("ssl_merchant_id")]
        public string MerchantId;

        [XmlElement("ssl_user_id")]
        public string UserId;

        [XmlElement("ssl_pin")]
        public string Pin;

        [XmlElement("ssl_show_form")]
        public string ShowForm;

        [XmlElement("ssl_track_data")]
        public string TrackData;

        [XmlElement("ssl_ksn")]
        public string Ksn;

        [XmlElement("ssl_card_number")]
        public string CardNumber;

        [XmlElement("ssl_token")]
        public string Token;

        [XmlElement("ssl_exp_date")]
        public string ExpDate;

        [XmlElement("ssl_amount")]
        public string Amount;

        [XmlElement("ssl_pos_mode")]
        public string PosMode;

        [XmlElement("ssl_entry_mode")]
        public string EntryMode;

        [XmlElement("ssl_card_present")]
        public string CardPresent;

        [XmlElement("ssl_avs_zip")]
        public string AvsZip;

        [XmlElement("ssl_avs_address")]
        public string AvsAddress;

        [XmlElement("ssl_cvv2cvc2")]
        public string Cvv2Cvc2;

        [XmlElement("ssl_cvv2cvc2_indicator")]
        public string Cvv2Cvc2Indicator;

        [XmlElement("ssl_invoice_number")]
        public string InvoiceNumber;

        [XmlElement("ssl_description")]
        public string Description;

        [XmlElement("ssl_customer_code")]
        public string CustomerCode;

        [XmlElement("ssl_salestax")]
        public string Salestax;

        [XmlElement("ssl_tip_amount")]
        public string TipAmount;

        [XmlElement("ssl_server")]
        public string Server;

        [XmlElement("ssl_shift")]
        public string Shift;

        [XmlElement("ssl_dynamic_dba")]
        public string DynamicDba;

        [XmlElement("ssl_partial_auth_indicator")]
        public string PartialAuthIndicator;

        [XmlElement("ssl_recurring_flag")]
        public string RecurringFlag;

        [XmlElement("ssl_payment_number")]
        public string PaymentNumber;

        [XmlElement("ssl_payment_count")]
        public string PaymentCount;

        [XmlElement("ssl_departure_Date")]
        public string DepartureDate;

        [XmlElement("ssl_completion_Date")]
        public string CompletionDate;

        [XmlElement("ssl_transaction_currency")]
        public string TransactionCurrency;

        [XmlElement("ssl_get_token")]
        public string GetToken;

        [XmlElement("ssl_add_token")]
        public string AddToken;

    }
}
