using MSHTest.Common.DTO;
using MSHTest.Infrastructure.Services;
using System;
using MSHTest.Infrastructure;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using RestSharp;
using RestSharp.Serialization.Json;

namespace ConsoleUI
{
    class Program
    {
        private static async Task<TaxForOrderResultsDTO> RunCalculateTaxForOrderAsync(TaxForOrderRequestDTO taxForOrderRequest)
        {
            TaxService taxService = new TaxService(new TaxJarCalculator());

            return  await taxService.CalculateTaxForOrderAsync(taxForOrderRequest);
        }

        private static void GetTaxRatesFromMicroService()
        {
            string _apiBaseUrl = MSHTest.Common.Utils.Config.Get("TaxApiBaseUrl");

            IRestClient _client = new RestClient(_apiBaseUrl);

            IRestRequest request = new RestRequest($"taxservice/taxrates/32819", Method.GET);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                JsonDeserializer deserial = new JsonDeserializer();

                LocationTaxRateResultsDTO locationTaxRateResultsDTO = deserial.Deserialize<LocationTaxRateResultsDTO>(response);

                Console.WriteLine($"State rate from micro service: {locationTaxRateResultsDTO.StateRate}");
            }
            else
            {
                Console.WriteLine($"Couldn't retrieve rates for location. Details: {response.StatusDescription} {response.ErrorMessage}");
            }
        }

        static void Main(string[] args)
        {
            TaxService taxService = new TaxService(new TaxJarCalculator());

            try
            {
                LocationTaxRateResultsDTO taxRates = taxService.GetTaxRatesByLocation("32819");

                Console.WriteLine($"State rate {taxRates.StateRate}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't retrieve rates for location. Details: {ex.Message}");
            }

            try
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

                TaxForOrderResultsDTO taxForOrderDTO = taxService.CalculateTaxForOrder(TaxForOrderRequest);

                Console.WriteLine($"Taxable amount: {taxForOrderDTO.TaxableAmount}");

                TaxForOrderResultsDTO taxForOrderDTOAsync = RunCalculateTaxForOrderAsync(TaxForOrderRequest).GetAwaiter().GetResult();

                Console.WriteLine($"Taxable amount from Asyc: {taxForOrderDTOAsync.TaxableAmount}");

                GetTaxRatesFromMicroService();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't calculate taxes for location. Details: {ex.Message}");
            }
        }
    }
}
