namespace StripeTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Stripe;
    using Xunit;

    public class StripeBankAccountTest : BaseStripeTest
    {
        [Fact]
        public void DeserializeForAccount()
        {
            string json = GetFixture("/v1/accounts/acct_123/external_accounts/ba_123");
            var bankAccount = Mapper<StripeBankAccount>.MapFromJson(json);
            Assert.NotNull(bankAccount);
            Assert.IsType<StripeBankAccount>(bankAccount);
            Assert.NotNull(bankAccount.Id);
            Assert.Equal("bank_account", bankAccount.Object);
        }

        [Fact]
        public void DeserializeForCustomer()
        {
            string json = GetFixture("/v1/customers/cus_123/bank_accounts/ba_123");
            var bankAccount = Mapper<StripeBankAccount>.MapFromJson(json);
            Assert.NotNull(bankAccount);
            Assert.IsType<StripeBankAccount>(bankAccount);
            Assert.NotNull(bankAccount.Id);
            Assert.Equal("bank_account", bankAccount.Object);
        }

        [Fact]
        public void DeserializeWithExpansionsForCustomer()
        {
            string[] expansions =
            {
              "customer",
            };

            string json = GetFixture("/v1/customers/cus_123/bank_accounts/ba_123", expansions);
            var bankAccount = Mapper<StripeBankAccount>.MapFromJson(json);
            Assert.NotNull(bankAccount);
            Assert.IsType<StripeBankAccount>(bankAccount);
            Assert.NotNull(bankAccount.Id);
            Assert.Equal("bank_account", bankAccount.Object);

            Assert.NotNull(bankAccount.Customer);
            Assert.Equal("customer", bankAccount.Customer.Object);
        }
    }
}
