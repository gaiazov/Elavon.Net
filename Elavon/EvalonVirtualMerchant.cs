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
            var xml = SerializeForElavon(request);

            var result = await _baseUrl
                .AppendPathSegment("processxml.do")
                .PostUrlEncodedAsync(new
                {
                    xmldata = xml
                })
                .ReceiveStream();

            return DeserializeFromElavon<CreditCardSaleResponse>(result);
        }

        #region Serialize/Deserialize helper methods
        private static string SerializeForElavon<T>(T obj)
        {
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true };

            var serializer = new XmlSerializer(typeof(T));

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var sw = new StringWriter();
            var xmlWriter = XmlWriter.Create(sw, settings);
            serializer.Serialize(xmlWriter, obj, ns);
            xmlWriter.Close();

            return sw.ToString();
        }

        private static T DeserializeFromElavon<T>(Stream stream)
        {
            var deserializer = new XmlSerializer(typeof(T));
            var response = (T)deserializer.Deserialize(stream);
            return response;
        }
        #endregion
    }
}
