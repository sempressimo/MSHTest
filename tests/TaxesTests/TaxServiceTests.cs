using MSHTest.Common.DTO;
using MSHTest.Infrastructure;
using MSHTest.Infrastructure.Services;
using System;
using Xunit;

namespace TaxesTests
{
    public class TaxesTests
    {
        private readonly TaxService _taxService;

        public TaxesTests()
        {
            this._taxService = new TaxService(new TaxJarCalculator());
        }

        [Fact]
        public void TaxService_ShouldFailGettingRatesOnBadRequest()
        {
            Assert.Throws<ApplicationException>(
                    () => _taxService.GetTaxRatesByLocation("")
                );
        }

        [Fact]
        public void TaxService_ShouldFailToCalculateRatesOnBadRequest()
        {
            Assert.Throws<ApplicationException>(
                    () => _taxService.CalculateTaxForOrder(new TaxForOrderRequestDTO())
                );
        }

        [Fact]
        public void TaxService_ShouldReturnRatesForLocation()
        {
            var rates = _taxService.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(rates.State.ToUpper() == "FL");
        }

        [Fact]
        public void TaxService_ShouldReturnPositiveRates()
        {
            var rates = _taxService.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }
    }
}
