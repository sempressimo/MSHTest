using MSHTest.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHTest.Application.Interfaces
{
    public interface ITaxCalculator
    {
        public LocationTaxRateResultsDTO GetTaxRatesByLocation(string zipCode);

        public Task<LocationTaxRateResultsDTO> GetTaxRatesByLocationAsync(string zipCode);

        public TaxForOrderResultsDTO CalculateTaxForOrder(TaxForOrderRequestDTO taxForOrderRequestDTO);

        public Task<TaxForOrderResultsDTO> CalculateTaxForOrderAsync(TaxForOrderRequestDTO taxForOrderRequestDTO);
    }
}