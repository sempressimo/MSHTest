using MSHTest.Common.DTO;
using MSHTest.Infrastructure;
using MSHTest.Infrastructure.Services;
using System;
using Xunit;

namespace TaxesTests
{
    public class TaxJarCalculatorTests
    {
        private readonly TaxJarCalculator _taxJarCalculator;

        public TaxJarCalculatorTests()
        {
            _taxJarCalculator = new TaxJarCalculator();
        }

        [Fact]
        public void GetRatesShouldFailOnBadRequest()
        {
            Assert.Throws<ApplicationException>(
                    () => _taxJarCalculator.GetTaxRatesByLocation("")
                );
        }

        [Fact]
        public void CalculateTaxeshouldFailOnBadRequest()
        {
            Assert.Throws<ApplicationException>(
                    () => _taxJarCalculator.CalculateTaxForOrder(new TaxForOrderRequestDTO()) // Empty params
                );
        }

        [Fact]
        public void ShouldReturnRatesForLocation()
        {
            var rates = _taxJarCalculator.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(rates.State.ToUpper() == "FL");
        }

        [Fact]
        public void ShouldReturnPositiveRates()
        {
            var rates = _taxJarCalculator.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }

        [Fact]
        public void ShouldCalculateTaxesForAnOrder()
        {
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

            var taxes = _taxJarCalculator.CalculateTaxForOrder(TaxForOrderRequest);

            Assert.NotNull(taxes);

            Assert.True(taxes.TaxableAmount > 0);
        }
    }
}
