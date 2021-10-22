using Infrastructure.Mapping;
using MSHTest.Application.Interfaces;
using MSHTest.Common.DTO;
using MSHTest.Infrastructure.ApiClients;
using MSHTest.Common.Utils;
using MSHTest.TaxJar.Client.Model;
using System.Threading.Tasks;

namespace MSHTest.Infrastructure
{
    public class TaxJarCalculator : ITaxCalculator
    {
        TaxJarClient _taxJarClient;

        public TaxJarCalculator()
        {
            string ApiKey = Config.Get("TaxJarKey");

            _taxJarClient = new TaxJarClient(ApiKey);
        }

        public TaxForOrderResultsDTO CalculateTaxForOrder(TaxForOrderRequestDTO taxForOrderRequestDTO)
        {
            TaxJarTaxForOrderRequest taxJarTaxForOrderRequest = Mapping.Mapper.Map<TaxJarTaxForOrderRequest>(taxForOrderRequestDTO);

            TaxJarTaxForOrderResponse taxJarTaxForOrderResponse = 
                _taxJarClient.TaxForOrder(taxJarTaxForOrderRequest);

            TaxForOrderResultsDTO locationTaxRate = Mapping.Mapper.Map<TaxForOrderResultsDTO>(taxJarTaxForOrderResponse.Tax);

            return locationTaxRate;
        }

        public LocationTaxRateResultsDTO GetTaxRatesByLocation(string zipCode)
        {
            try
            {
                TaxJarRatesForLocationResponse taxJarRatesForLocationResponse = _taxJarClient.GetTaxRatesForLocation(zipCode);

                LocationTaxRateResultsDTO locationTaxRate = Mapping.Mapper.Map<LocationTaxRateResultsDTO>(taxJarRatesForLocationResponse.Rate);

                return locationTaxRate;
            }
            catch
            {
                throw;
            }
        }

        public async Task<TaxForOrderResultsDTO> CalculateTaxForOrderAsync(TaxForOrderRequestDTO taxForOrderRequestDTO)
        {
            TaxJarTaxForOrderRequest taxJarTaxForOrderRequest = Mapping.Mapper.Map<TaxJarTaxForOrderRequest>(taxForOrderRequestDTO);

            TaxJarTaxForOrderResponse taxJarTaxForOrderResponse =
                await _taxJarClient.TaxForOrderAsyc(taxJarTaxForOrderRequest);

            TaxForOrderResultsDTO locationTaxRate = Mapping.Mapper.Map<TaxForOrderResultsDTO>(taxJarTaxForOrderResponse.Tax);

            return locationTaxRate;
        }

        public async Task<LocationTaxRateResultsDTO> GetTaxRatesByLocationAsync(string zipCode)
        {
            TaxJarRatesForLocationResponse taxJarRatesForLocationResponse = 
                await _taxJarClient.GetTaxRatesForLocationAsync(zipCode);

            LocationTaxRateResultsDTO locationTaxRate = Mapping.Mapper.Map<LocationTaxRateResultsDTO>(taxJarRatesForLocationResponse.Rate);

            return locationTaxRate;
        }
    }
}
