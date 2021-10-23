using Moq;
using MSHTest.Application.Interfaces;
using MSHTest.Common.DTO;
using MSHTest.Infrastructure;
using MSHTest.Infrastructure.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TaxesTests
{
    public class TaxesTests
    {
        private readonly TaxService _taxService;
        private readonly Mock<ITaxCalculator> _taxCalculator;

        public TaxesTests()
        {
            this._taxCalculator = new Mock<ITaxCalculator>();
            this._taxService = new TaxService(_taxCalculator.Object);
        }

        [Fact]
        public void ShouldReturnPositiveRates()
        {
            _taxCalculator.Setup(x => x.GetTaxRatesByLocation("32819")).Returns(new LocationTaxRateResultsDTO());

            var rates = _taxService.GetTaxRatesByLocation("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }

        [Fact]
        public async void ShouldReturnPositiveRatesAsync()
        {
            _taxCalculator.Setup(x => x.GetTaxRatesByLocationAsync("32819")).Returns(Task.FromResult(new LocationTaxRateResultsDTO()));

            var rates = await _taxService.GetTaxRatesByLocationAsync("32819");

            Assert.NotNull(rates);

            Assert.True(
                rates.CityRate >= 0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >= 0 && rates.CountyRate >= 0 && rates.StateRate >= 0
                );
        }

        [Fact]
        public void ShouldCalculateTaxForOrder()
        {
            TaxForOrderRequestDTO taxForOrderRequestDTO = new TaxForOrderRequestDTO();

            _taxCalculator.Setup(x => x.CalculateTaxForOrder(taxForOrderRequestDTO)).Returns(new TaxForOrderResultsDTO());

            TaxForOrderResultsDTO taxes = _taxService.CalculateTaxForOrder(taxForOrderRequestDTO);

            Assert.NotNull(taxes);

            Assert.True(taxes.TaxableAmount >= 0);
        }

        [Fact]
        public async void ShouldCalculateTaxForOrderAsync()
        {
            TaxForOrderRequestDTO taxForOrderRequestDTO = new TaxForOrderRequestDTO();

            _taxCalculator.Setup(x => x.CalculateTaxForOrderAsync(taxForOrderRequestDTO)).Returns(Task.FromResult(new TaxForOrderResultsDTO()));

            TaxForOrderResultsDTO taxes = await _taxService.CalculateTaxForOrderAsync(taxForOrderRequestDTO);

            Assert.NotNull(taxes);

            Assert.True(taxes.TaxableAmount >= 0);
        }
    }
}
