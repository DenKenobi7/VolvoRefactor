using System.Threading.Tasks;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.DataProviders
{
    public class TaxConfigurationProvider : ITaxConfigurationProvider
    {
        public async Task<CongestionConfiguration> ImportConfigurationFromFile(string city)
        {
            return await Task.FromResult<CongestionConfiguration>(null);
        }
    }
}
