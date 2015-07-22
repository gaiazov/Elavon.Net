using System.Configuration;
using System.Threading.Tasks;
using Elavon.Message;
using FluentAssertions;
using NUnit.Framework;

namespace Elavon.Tests
{
    [TestFixture]
    public class EvalonVirtualMerchantTests
    {
        private readonly string _baseUrl;

        public EvalonVirtualMerchantTests()
        {
            _baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        }

        [Test]
        public async Task ProcessCreditCardSale_EmptyRequest()
        {
            var client = new EvalonVirtualMerchant(_baseUrl);
            var request = new CreditCardSaleRequest();

            var response = await client.ProcessCreditCardSale(request);

            response.Should().NotBeNull();
            response.ErrorCode.Should().NotBeNullOrEmpty().And.Be("6042");
            response.ErrorName.Should().NotBeNullOrEmpty().And.Be("Invalid Request Format");
            response.ErrorMessage.Should().NotBeNullOrEmpty().And.Be("XML request is not well-formed or request is incomplete.");
        }

        [Test]
        public async Task ProcessCreditCardSale_InvalidCredentials()
        {
            var client = new EvalonVirtualMerchant(_baseUrl);
            var request = new CreditCardSaleRequest()
            {
                MerchantId = "Test",
                UserId = "Test",
                Pin = "Test"
            };

            var response = await client.ProcessCreditCardSale(request);

            response.Should().NotBeNull();
            response.ErrorCode.Should().NotBeNullOrEmpty().And.Be("4025");
            response.ErrorName.Should().NotBeNullOrEmpty().And.Be("Invalid Credentials");
            response.ErrorMessage.Should().NotBeNullOrEmpty().And.Be("The credentials supplied in the authorization request are invalid.");
        }
    }
}
