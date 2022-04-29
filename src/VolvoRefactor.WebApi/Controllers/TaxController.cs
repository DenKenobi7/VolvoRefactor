using Microsoft.AspNetCore.Mvc;
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
            var totalTax = taxCalculator.GetTax(vehicle, congestionTaxDTO.Dates);

            return totalTax;
        }
    }
}
