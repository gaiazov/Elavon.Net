using System.Collections.Generic;
using System.Xml.Serialization;

namespace Elavon.Message
{
    [XmlType("txn")]
    public class CreditCardSaleResponse
    {
        [XmlElement("ssl_result")]
        public bool Result;

        [XmlElement("ssl_result_message")]
        public string ResultMessage;

        [XmlElement("ssl_txn_id")]
        public string TransactionId;

        [XmlElement("ssl_txn_time")]
        public string TransactionTime;

        [XmlElement("ssl_approval_code")]
        public string ApprovalCode;
        
        [XmlElement("ssl_amount")]
        public string Amount;
        
        [XmlElement("ssl_base_amount")]
        public string BaseAmount;
        
        [XmlElement("ssl_tip_amount")]
        public string TipAmount;
        
        [XmlElement("ssl_requested_amount")]
        public string RequestedAmount;
        
        [XmlElement("ssl_balance_due")]
        public string BalanceDue;
        
        [XmlElement("ssl_account_balance")]
        public string AccountBalance;
        
        [XmlElement("ssl_card_number")]
        public string CardNumber;
        
        [XmlElement("ssl_avs_response")]
        public string AvsResponse;
        
        [XmlElement("ssl_cvv2_response")]
        public string Cvv2Response;
        
        [XmlElement("ssl_invoice_number")]
        public string InvoiceNumber;
        
        [XmlElement("ssl_conversion_rate")]
        public string ConversionRate;
        
        [XmlElement("ssl_cardholder_currency")]
        public string CardholderCurrency;
        
        [XmlElement("ssl_cardholder_amount")]
        public string CardholderAmount;
        
        [XmlElement("ssl_cardholder_base_amount")]
        public string CardholderBaseAmount;

        [XmlElement("ssl_cardholder_tip_amount")]
        public string CardholderTipAmount;

        [XmlElement("ssl_server")]
        public string Server;

        [XmlElement("ssl_shift")]
        public string Shift;

        [XmlElement("ssl_eci_ind")]
        public string EciInd;

        [XmlElement("ssl_transaction_currency")]
        public string TransactionCurrency;

        [XmlElement("ssl_token")]
        public string Token;

        [XmlElement("ssl_token_response")]
        public string TokenResponse;

        [XmlElement("ssl_add_token_response")]
        public string AddTokenResponse;

        [XmlArrayAttribute("ssl_promo_list")]
        public List<PromoProduct> PromoList;

        [XmlType("ssl_promo_product")]
        public class PromoProduct
        {
            [XmlElement("ssl_promo_code")]
            public string PromoCode;

            [XmlElement("ssl_promo_code_name")]
            public string PromoCodeName;

            [XmlElement("ssl_promo_code_description")]
            public string PromoCodeDescription;

            [XmlElement("ssl_promo_code_issue_points")]
            public string PromoCodeIssuePoints;
        }

        [XmlElement("errorCode")]
        public int? ErrorCode;

        [XmlElement("errorMessage")]
        public string ErrorMessage;

        [XmlElement("errorName")]
        public string ErrorName;
    }
}
