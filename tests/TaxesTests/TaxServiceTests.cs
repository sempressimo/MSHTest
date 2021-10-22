using MSHTest.Common.DTO;
using MSHTest.Infrastructure;
using MSHTest.Infrastructure.Services;
using System;
using Xunit;

namespace TaxesTests
{
    public class TaxesTests
    {
        [Fact]
        public void TaxService_ShouldFailGettingRatesOnBadRequest()
        {
            TaxService taxJarCalculator = new TaxService(new TaxJarCalculator());

            Assert.Throws<ApplicationException>(
                    () => taxJarCalculator.GetTaxRatesByLocation("")
                );
        }

        [Fact]
        public void TaxService_ShouldFailToCalculateRatesOnBadRequest()
        {
            TaxService taxJarCalculator = new TaxService(new TaxJarCalculator());

            Assert.Throws<ApplicationException>(
                    () => taxJarCalculator.CalculateTaxForOrder(new TaxForOrderRequestDTO())
                );
        }

        [Fact]
        public void TaxService_ShouldReturnRatesForLocation()
        {
            TaxService taxJarCalculator = new TaxService(new TaxJarCalculator());

            var rates = taxJarCalculator.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(rates.State.ToUpper() == "FL");
        }

        [Fact]
        public void TaxService_ShouldReturnPositiveRates()
        {
            TaxService taxJarCalculator = new TaxService(new TaxJarCalculator());

            var rates = taxJarCalculator.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }
    }
}
