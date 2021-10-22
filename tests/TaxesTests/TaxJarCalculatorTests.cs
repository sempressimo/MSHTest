using MSHTest.Common.DTO;
using MSHTest.Infrastructure;
using MSHTest.Infrastructure.Services;
using System;
using Xunit;

namespace TaxesTests
{
    public class TaxJarCalculatorTests
    {
        [Fact]
        public void TaxJarCalculator_GetRatesShouldFailOnBadRequest()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            Assert.Throws<ApplicationException>(
                    () => taxJarCalculator.GetTaxRatesByLocation("")
                );
        }

        [Fact]
        public void TaxJarCalculator_CalculateTaxeshouldFailOnBadRequest()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            Assert.Throws<ApplicationException>(
                    () => taxJarCalculator.CalculateTaxForOrder(new TaxForOrderRequestDTO()) // Empty params
                );
        }

        [Fact]
        public void TaxJarCalculator_ShouldReturnRatesForLocation()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            var rates = taxJarCalculator.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(rates.State.ToUpper() == "FL");
        }

        [Fact]
        public void TaxJarCalculator_ShouldReturnPositiveRates()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            var rates = taxJarCalculator.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }

        [Fact]
        public void TaxJarCalculator_ShouldCalculateTaxesForAnOrder()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            TaxForOrderRequestDTO TaxForOrderRequest = new TaxForOrderRequestDTO()
            {
                Amount = 16,
                FromCountry = "US",
                ToCountry = "US",
                FromState = "NJ",
                FromZip = "07001",
                ToZip = "07446",
                ToState = "NJ",
                Shipping = 1
            };

            var taxes = taxJarCalculator.CalculateTaxForOrder(TaxForOrderRequest);

            Assert.NotNull(taxes);

            Assert.True(taxes.TaxableAmount > 0);
        }
    }
}
