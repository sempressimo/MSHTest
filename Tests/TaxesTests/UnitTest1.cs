using MSHTest.Infrastructure;
using System;
using Xunit;

namespace TaxesTests
{
    public class TaxesTests
    {
        #region TaxJarCalculator

        [Fact]
        public void TaxJarCalculator_ShouldFailOnBadRequest()
        {
            TaxJarCalculator taxJarCalculator = new TaxJarCalculator();

            Assert.Throws<ApplicationException>(
                    ()=> taxJarCalculator.GetTaxRatesByLocation("")
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
                rates.CityRate >=0 && rates.CombinedDistrictRate >= 0 && rates.CombinedRate >= 0 && rates.Country_Rate >=0 && rates.CountyRate >= 0 && rates.StateRate >=0
                );
        }

        #endregion
    }
}
