using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.DataProviders
{
    public interface ITaxConfigurationProvider
    {
        Task<CongestionConfiguration> ImportConfigurationFromFile(string city);
    }
}
