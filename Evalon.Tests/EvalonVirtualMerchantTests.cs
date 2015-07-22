using System.Threading.Tasks;
using Elavon.Message;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elavon.Tests
{
    [TestClass]
    public class EvalonVirtualMerchantTests
    {
        [TestMethod]
        public async Task ProcessCreditCardSale_InvalidCredentials()
        {
            var client = new EvalonVirtualMerchant("https://demo.myvirtualmerchant.com/VirtualMerchantDemo/");
            var request = new CreditCardSaleRequest()
            {
                MerchantId = "Test",
                UserId = "Test",
                Pin = "Test"
            };

            var response = await client.ProcessCreditCardSale(request);

            response.Should().NotBeNull();
            response.ErrorCode.Should().HaveValue().And.Be(4025);
            response.ErrorName.Should().NotBeNullOrEmpty().And.Be("Invalid Credentials");
            response.ErrorMessage.Should().NotBeNullOrEmpty().And.Be("The credentials supplied in the authorization request are invalid.");
        }
    }
}
