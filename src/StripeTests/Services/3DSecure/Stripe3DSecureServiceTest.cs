namespace StripeTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Stripe;
    using Xunit;

    public class Stripe3DSecureServiceTest : BaseStripeTest
    {
        private Stripe3DSecureService service;
        private Stripe3DSecureCreateOptions createOptions;

        public Stripe3DSecureServiceTest()
        {
            this.service = new Stripe3DSecureService();

            this.createOptions = new Stripe3DSecureCreateOptions()
            {
                Amount = 25,
                Currency = "eur",
                ReturnUrl = "https://stripe.com",
            };
        }

        [Fact]
        public void Create()
        {
            var threeDSecure = this.service.Create(this.createOptions);
            Assert.NotNull(threeDSecure);
            Assert.Equal("three_d_secure", threeDSecure.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var threeDSecure = await this.service.CreateAsync(this.createOptions);
            Assert.NotNull(threeDSecure);
            Assert.Equal("three_d_secure", threeDSecure.Object);
        }
    }
}
