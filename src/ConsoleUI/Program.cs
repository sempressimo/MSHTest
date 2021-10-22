using MSHTest.Common.DTO;
using MSHTest.Infrastructure.Services;
using System;
using MSHTest.Infrastructure;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
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
                Console.WriteLine($"Couldn't retrieve taxes for location. Details: {ex.Message}");
            }

            TaxForOrderRequestDTO TaxForOrderRequest = new TaxForOrderRequestDTO()
            {
                amount = 16.60M,
                from_country = "US",
                to_country = "US",
                from_state = "NJ",
                from_zip = "07001",
                to_zip = "07446",
                to_state = "NJ",
                shipping = 1.5M
            };

            Task<TaxForOrderResultsDTO> taxForOrderDTO = taxService.CalculateTaxForOrderAsync(TaxForOrderRequest);

            if (taxForOrderDTO.IsCompletedSuccessfully)
            {
                Console.WriteLine($"Taxable amount: {taxForOrderDTO.Result.taxable_amount}");
            }
        }
    }
}
