using MSHTest.Common.DTO;
using MSHTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHTest.Infrastructure.Services
{
    public class TaxService
    {
        private ITaxCalculator _taxCalculator;

        public TaxService(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public TaxForOrderResultsDTO CalculateTaxForOrder(TaxForOrderRequestDTO taxForOrderRequestDTO)
        {
            try
            {
                return _taxCalculator.CalculateTaxForOrder(taxForOrderRequestDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task<TaxForOrderResultsDTO> CalculateTaxForOrderAsync(TaxForOrderRequestDTO taxForOrderRequestDTO)
        {
            return await _taxCalculator.CalculateTaxForOrderAsync(taxForOrderRequestDTO);

        }

        public LocationTaxRateResultsDTO GetTaxRatesByLocation(string zipCode)
        {
            try
            {
                return _taxCalculator.GetTaxRatesByLocation(zipCode);
            }
            catch
            {
                throw;
            }
        }
    }
}
