using Moq;
using MSHTest.Application.Interfaces;
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
        private readonly Mock<ITaxCalculator> _taxCalculator = new Mock<ITaxCalculator>();

        public TaxesTests()
        {
            this._taxService = new TaxService(_taxCalculator.Object);
        }

        [Fact]
        public void TaxService_ShouldReturnRatesForLocation()
        {
            _taxCalculator.Setup(x => x.GetTaxRatesByLocation("32819")).Returns(new LocationTaxRateResultsDTO() { State = "FL" });
            
            var rates = _taxService.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(rates.State.ToUpper() == "FL");
        }

        [Fact]
        public void TaxService_ShouldReturnPositiveRates()
        {
            _taxCalculator.Setup(x => x.GetTaxRatesByLocation("32819")).Returns(new LocationTaxRateResultsDTO());

            var rates = _taxService.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }
    }
}
