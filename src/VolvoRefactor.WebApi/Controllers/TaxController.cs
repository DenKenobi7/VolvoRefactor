using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolvoRefactor.WebApi.DTOs;

namespace VovlvoRefactor.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        public TaxController()
        {
        }

        [HttpGet("congestion")]
        public async Task<int> GetCongestionTax([FromQuery] CongestionTaxDTO congestionTaxDTO)
        {

            return 1;
        }
    }
}
