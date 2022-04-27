using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoRefactor.Application.DataProviders;
using VolvoRefactor.Application.Models;
using VolvoRefactor.Application.TaxCalculators;
using VolvoRefactor.WebApi.DTOs;

namespace VolvoRefactor.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxConfigurationProvider _configurationProvider;
        public TaxController(ITaxConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        [HttpGet("congestion")]
        public async Task<int> GetCongestionTax([FromQuery] CongestionTaxDTO congestionTaxDTO)
        {
            var taxConfiguration = await _configurationProvider.ImportConfigurationFromFile(congestionTaxDTO.City);
            var calculatorFactory = new CongestionTaxCalculatorFactory(taxConfiguration);
            var taxCalculator = calculatorFactory.GetCalculatorByName(congestionTaxDTO.City);

            var vehicle = new Vehicle(congestionTaxDTO.VehicleType);
            var totalTax = 0;
            foreach (var dayChecpoints in SplitIntoDays(congestionTaxDTO.Dates))
            {
                totalTax += taxCalculator.GetTax(vehicle, dayChecpoints);
            }
            return totalTax;
        }

        private IEnumerable<List<DateTime>> SplitIntoDays(DateTime[] dates)
        {
            return dates.OrderBy(x => x)
                        .GroupBy(x => x.Date)
                        .Select(g => g.ToList());
        }
    }
}
