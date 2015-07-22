using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;

namespace Elavon
{
    public static class FlurlXmlExtensions
    {

        public static async Task<HttpResponseMessage> PostXmlAsync(this FlurlClient fc, string xml)
        {
            try
            {
                var content = new CapturedStringContent(xml, Encoding.UTF8, "application/xml");
                return await fc.HttpClient.PostAsync(fc.Url, content);
            }
            finally
            {
                if (fc.AutoDispose)
                {
                    fc.Dispose();
                }
            }
        }

        // chain off a Url object:
        public static Task<HttpResponseMessage> PostXmlAsync(this Url url, string xml)
        {
            return new FlurlClient(url, true).PostXmlAsync(xml);
        }

        // chain off a url string:
        public static Task<HttpResponseMessage> PostXmlAsync(this string url, string xml)
        {
            return new FlurlClient(url, true).PostXmlAsync(xml);
        }
    }
}