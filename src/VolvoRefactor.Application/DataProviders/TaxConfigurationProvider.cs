using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using VolvoRefactor.Application.Helpers;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.DataProviders
{
    public class TaxConfigurationProvider : ITaxConfigurationProvider
    {
        public async Task<CongestionConfiguration> ImportConfigurationFromFile(string city)
        {
            var filename = File.Exists($"../../data/{city}.json") ? city : "default";
            var json = await File.ReadAllTextAsync($"../../data/{filename}.json");
            return JsonSerializer.Deserialize<CongestionConfiguration>(json);
        }
    }
}
