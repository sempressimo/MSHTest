using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSHTest.Application.Interfaces;
using MSHTest.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxServiceController : ControllerBase
    {
        private readonly ILogger<TaxServiceController> _logger;
        private readonly ITaxCalculator _taxCalculator;

        public TaxServiceController(ILogger<TaxServiceController> logger, ITaxCalculator taxCalculator)
        {
            _logger = logger;

            _taxCalculator = taxCalculator;
        }

        [HttpGet("TaxRates/{zipCode}")]
        public async Task<LocationTaxRateResultsDTO> GetTaxRatesAsync(string zipCode)
        {
            return await _taxCalculator.GetTaxRatesByLocationAsync(zipCode);
        }
    }
}
