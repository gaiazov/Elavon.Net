using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Elavon.Message;
using Flurl;
using Flurl.Http;

namespace Elavon
{
    public class EvalonVirtualMerchant
    {
        private readonly string _baseUrl;

        public EvalonVirtualMerchant(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<CreditCardSaleResponse> ProcessCreditCardSale(CreditCardSaleRequest request)
        {
            var settings = new XmlWriterSettings {OmitXmlDeclaration = true};

            var serializer = new XmlSerializer(typeof(CreditCardSaleRequest));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var sw = new StringWriter();
            var xmlWriter = XmlWriter.Create(sw, settings);
            serializer.Serialize(xmlWriter, request, ns);
            xmlWriter.Close();

            var requestString = sw.ToString();

            var result = await _baseUrl
                .AppendPathSegment("processxml.do")
                .PostUrlEncodedAsync(new
                {
                    xmldata = requestString
                })
                .ReceiveStream();

            var deserializer = new XmlSerializer(typeof (CreditCardSaleResponse));
            var response = (CreditCardSaleResponse)deserializer.Deserialize(result);

            return response;
        }
    }
}
