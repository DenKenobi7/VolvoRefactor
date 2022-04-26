using System.Threading.Tasks;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.Helpers
{
    public static class ConfigurationImporter
    {
        public static async Task<CongestionConfiguration> ImportConfigurationFromFile(string city)
        {
            return await Task.FromResult<CongestionConfiguration>(null);
        }
    }
}
