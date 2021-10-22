﻿using MSHTest.Common.DTO;
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

            Console.WriteLine($"Taxable amount: {taxForOrderDTO.taxable_amount}");
        }
    }
}
