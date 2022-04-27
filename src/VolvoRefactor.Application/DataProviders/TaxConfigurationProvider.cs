using System.Collections.Generic;
using System.Threading.Tasks;
using VolvoRefactor.Application.Helpers;
using VolvoRefactor.Application.Models;

namespace VolvoRefactor.Application.DataProviders
{
    public class TaxConfigurationProvider : ITaxConfigurationProvider
    {
        public async Task<CongestionConfiguration> ImportConfigurationFromFile(string city)
        {
            var tempval = new CongestionConfiguration
            {
                City = "Kyiv",
                MaxDailyFee = 60,
                SingleChargeTime = 60,
                TollFreeVehicles = new List<string>
                {
                    "Emergency",
                    "Diplomat",
                    "Military",
                    "Foreign",
                    "Motorbike"
                },
                CongestionIntervalCosts = new List<CongestionIntervalCost>
                {
                    new("06:00","06:30",8),
                    new("06:30","07:00",13),
                    new("07:00","08:00",18),
                    new("08:00","08:30",13),
                    new("08:30","15:00",8),
                    new("15:00","15:30",13),
                    new("15:30","17:00",18),
                    new("17:00","18:00",13),
                    new("18:00","18:30",8),
                    new("18:30","06:00",0),
                },
                HolidaysSet = new()
                {
                    DaysOfWeek = new()
                    {
                        "Saturday",
                        "Sunday"
                    },
                    Months = new()
                    {
                        7
                    },
                    HolidayDates = new()
                    {
                        DateHelper.DateFromString("01.01.2013"),
                        DateHelper.DateFromString("06.01.2013"),
                        DateHelper.DateFromString("29.03.2013"),
                        DateHelper.DateFromString("31.03.2013"),
                        DateHelper.DateFromString("01.04.2013"),
                        DateHelper.DateFromString("01.05.2013"),
                        DateHelper.DateFromString("09.05.2013"),
                        DateHelper.DateFromString("19.05.2013"),
                        DateHelper.DateFromString("06.06.2013"),
                        DateHelper.DateFromString("22.06.2013"),
                        DateHelper.DateFromString("02.11.2013"),
                        DateHelper.DateFromString("24.12.2013"),
                        DateHelper.DateFromString("25.12.2013"),
                        DateHelper.DateFromString("26.12.2013"),
                        DateHelper.DateFromString("31.12.2013"),
                    }
                }
            };
            return await Task.FromResult<CongestionConfiguration>(tempval);
        }
    }
}
